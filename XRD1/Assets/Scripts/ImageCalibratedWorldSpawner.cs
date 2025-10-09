using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageCalibratedWorldSpawner : MonoBehaviour
{
    [Header("AR")]
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private string referenceImageName = "WallMarker";

    [Header("Content")]
    [SerializeField] private GameObject worldRootPrefab; // Your prefab with environment & targets
    [SerializeField] private string markerOriginChildName = "MarkerOrigin"; // optional offset child in the prefab

    [Header("Behavior")]
    [SerializeField] private bool spawnOnce = true;       // only spawn the first time we see the marker
    [SerializeField] private bool keepVisibleIfTrackingLost = true; // keep content after first lock
    [SerializeField] private bool reAlignOnEveryGoodTrack = false;  // re-snap on each strong update

    [Header("Navigation")]
    [SerializeField] private string targetObjectName = "Kani";
    [SerializeField] private M16Navigation navigationArrow;

    private Transform navigationTarget;

    [Header("Visibility")]
    [SerializeField] private bool hideWorldExceptTarget = false;

    private GameObject worldInstance;
    private Transform markerOriginInInstance;
    private bool alignedOnce;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        Debug.Log($"Images Changed - Added: {args.added.Count}, Updated: {args.updated.Count}, Removed: {args.removed.Count}");

        foreach (var img in args.added) Handle(img);
        foreach (var img in args.updated) Handle(img);
        foreach (var img in args.removed) HandleRemoved(img);
    }

    private void Handle(ARTrackedImage arImg)
    {
        Debug.Log($"Handle called - Name: {arImg.referenceImage.name}, TrackingState: {arImg.trackingState}");

        if (arImg.referenceImage.name != referenceImageName)
        {
            Debug.LogWarning($"Name mismatch! Expected: {referenceImageName}");
            return;
        }

        if (arImg.trackingState == TrackingState.Tracking)
        {
            Debug.Log($"TRACKING! spawnOnce={spawnOnce}, alignedOnce={alignedOnce}, worldInstance={(worldInstance == null ? "NULL" : "EXISTS")}");

            if (spawnOnce && alignedOnce)
            {
                Debug.Log("Skipping - already aligned once");
                return;
            }

            if (worldInstance == null)
            {
                Debug.Log("Spawning world instance!");
                SpawnWorldInstance();
            }

            Debug.Log($"Aligning world to image position: {arImg.transform.position}");
            AlignWorldToImage(arImg);

            if (!alignedOnce) alignedOnce = true;

            SetWorldActive(true);
            Debug.Log("World should now be visible!");
        }
        else
        {
            Debug.Log($"Tracking state is: {arImg.trackingState} (not Tracking)");
            if (!keepVisibleIfTrackingLost)
                SetWorldActive(false);
        }
    }

    private void HandleRemoved(ARTrackedImage arImg)
    {
        // Marker removed from tracking set
        if (!keepVisibleIfTrackingLost)
            SetWorldActive(false);
    }

    private void SpawnWorldInstance()
    {
        Debug.Log("[Spawner] Creating world instance...");
        worldInstance = Instantiate(worldRootPrefab);
        markerOriginInInstance = FindMarkerOrigin(worldInstance, markerOriginChildName);

        // Search recursively through all descendants
        Debug.Log($"[Spawner] Searching for target: '{targetObjectName}'");
        navigationTarget = FindDeepChild(worldInstance.transform, targetObjectName);

        if (navigationTarget == null)
            Debug.LogError($"[Spawner] Navigation target '{targetObjectName}' NOT FOUND in world prefab!");
        else
        {
            Debug.Log($"[Spawner] ✓ Navigation target found: {navigationTarget.name} at {navigationTarget.position}");
            if (navigationArrow != null)
            {
                Debug.Log("[Spawner] Setting arrow target...");
                navigationArrow.SetTarget(navigationTarget);
            }
            else
            {
                Debug.LogError("[Spawner] NavigationArrow reference is NULL!");
            }
        }

        // Hide world except target if enabled
        if (hideWorldExceptTarget && navigationTarget != null)
        {
            HideAllExceptTarget();
        }
    }

    private Transform FindMarkerOrigin(GameObject root, string childName)
    {
        if (string.IsNullOrEmpty(childName)) return null;
        var t = root.transform.Find(childName);
        if (t == null)
            Debug.LogWarning($"[Spawner] marker origin child '{childName}' not found in world prefab (optional).");
        return t;
    }

    private void AlignWorldToImage(ARTrackedImage arImg)
    {
        // Pose of the marker in world space
        var imgPos = arImg.transform.position;
        var imgRot = arImg.transform.rotation * Quaternion.Euler(-90, 0, 0);

        if (markerOriginInInstance == null)
        {
            // Treat the prefab's root as the point that should sit on the marker
            worldInstance.transform.SetPositionAndRotation(imgPos, imgRot);
        }
        else
        {
            // We want markerOriginInInstance to land exactly on the marker pose.
            // Compute the prefab root transform from the child 'markerOrigin' offset.
            // worldRoot = imagePose * inverse(localPoseOfMarkerOrigin)
            var localMarkerPose = new Pose(markerOriginInInstance.localPosition, markerOriginInInstance.localRotation);
            var inv = Inverse(localMarkerPose);

            var desiredRoot = Multiply(new Pose(imgPos, imgRot), inv);
            worldInstance.transform.SetPositionAndRotation(desiredRoot.position, desiredRoot.rotation);
        }
    }

    // Utility: Pose math
    private static Pose Multiply(Pose a, Pose b)
    {
        return new Pose(
            a.position + a.rotation * b.position,
            a.rotation * b.rotation
        );
    }
    private static Pose Inverse(Pose p)
    {
        var invRot = Quaternion.Inverse(p.rotation);
        return new Pose(
            invRot * (-p.position),
            invRot
        );
    }

    private void SetWorldActive(bool active)
    {
        if (worldInstance != null && worldInstance.activeSelf != active)
        {
            worldInstance.SetActive(active);
            if (active && hideWorldExceptTarget && navigationTarget != null)
            {
                HideAllExceptTarget();
            }
        }
    }

    private void HideAllExceptTarget()
    {
        Debug.Log("[Spawner] Hiding all renderers except target...");

        Renderer[] allRenderers = worldInstance.GetComponentsInChildren<Renderer>();
        Renderer[] targetRenderers = navigationTarget.GetComponentsInChildren<Renderer>();

        Debug.Log($"[Spawner] Found {allRenderers.Length} total renderers, {targetRenderers.Length} target renderers");

        int hiddenCount = 0;
        foreach (Renderer r in allRenderers)
        {
            bool isTargetRenderer = System.Array.Exists(targetRenderers, tr => tr == r);
            r.enabled = !isTargetRenderer;
            if (!isTargetRenderer) hiddenCount++;
        }

        Debug.Log($"[Spawner] Hidden {hiddenCount} renderers, kept {targetRenderers.Length} visible");
    }

    private Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }
}
