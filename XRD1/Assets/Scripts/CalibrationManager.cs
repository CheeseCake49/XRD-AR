using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CalibrationManager : MonoBehaviour
{
    [Header("Scene Refs")]
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private Transform worldRoot;            // Parent of your environment/targets
    [SerializeField] private string referenceImageName = "WallMarker";
    [SerializeField] private bool lockAfterAlignment = true; // Align once per session

    private bool aligned;

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
        if (aligned && lockAfterAlignment) return;

        foreach (var img in args.added)   TryAlign(img);
        foreach (var img in args.updated) TryAlign(img);
    }

    private void TryAlign(ARTrackedImage arImg)
    {
        if (arImg.trackingState != TrackingState.Tracking) return;
        if (arImg.referenceImage.name != referenceImageName) return;

        // Align content root so its origin sits on the marker
        var p = arImg.transform.position;
        var r = arImg.transform.rotation;

        worldRoot.SetPositionAndRotation(p, r);

        // If your world needs an offset from the marker (e.g., origin is 1m to the right):
        // worldRoot.position += worldRoot.right * 1f;

        aligned = true;
        Debug.Log("[Calibration] World aligned to " + referenceImageName);
    }
}
