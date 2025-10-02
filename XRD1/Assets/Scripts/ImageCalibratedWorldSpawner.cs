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
        foreach (var img in args.added)   Handle(img);
        foreach (var img in args.updated) Handle(img);
        foreach (var img in args.removed) HandleRemoved(img);
    }

    private void Handle(ARTrackedImage arImg)
    {
        if (arImg.referenceImage.name != referenceImageName) return;

        if (arImg.trackingState == TrackingState.Tracking)
        {
            if (spawnOnce && alignedOnce) return;
            if (worldInstance == null)
                SpawnWorldInstance();

            AlignWorldToImage(arImg);

            if (!alignedOnce) alignedOnce = true;

            SetWorldActive(true);
        }
        else // Limited or None
        {
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
        worldInstance = Instantiate(worldRootPrefab);
        markerOriginInInstance = FindMarkerOrigin(worldInstance, markerOriginChildName);
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
        var imgRot = arImg.transform.rotation;

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
            worldInstance.SetActive(active);
    }
}
