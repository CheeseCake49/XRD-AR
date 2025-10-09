using UnityEngine;

public class M16Navigation : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // The object to point to

    [Header("Arrow Settings")]
    [SerializeField] private bool use3DArrow = true; // 3D world arrow vs 2D UI arrow
    [SerializeField] private float distanceFromCamera = 2f; // How far in front of camera
    [SerializeField] private Vector3 offset = new Vector3(0, -0.5f, 0); // Offset from camera center

    [Header("Optional: Distance Display")]
    [SerializeField] private TMPro.TextMeshProUGUI distanceText; // Optional distance text

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        Debug.Log($"[NavigationArrow] Started. Camera: {(mainCamera != null ? "Found" : "NULL")}");
        Debug.Log($"[NavigationArrow] Arrow active: {gameObject.activeSelf}");
        Debug.Log($"[NavigationArrow] Arrow position: {transform.position}");
        Debug.Log($"[NavigationArrow] Arrow scale: {transform.localScale}");
        Debug.Log($"[NavigationArrow] Has renderer: {GetComponent<Renderer>() != null}");
        Debug.Log($"[NavigationArrow] Camera found: {mainCamera != null}");
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log($"[NavigationArrow] Target set to: {(target != null ? target.name : "NULL")}");
    }

    private void Update()
    {
        // if (target == null || mainCamera == null) return;
        if (target == null)
        {
            Debug.LogWarning("[NavigationArrow] Target is NULL!");
            return;
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("[NavigationArrow] Camera is NULL!");
            return;
        }

        if (use3DArrow)
        {
            Update3DArrow();
            if (Time.frameCount % 120 == 0)
            {
                Debug.Log($"[Arrow] Camera: {mainCamera.transform.position}, Target: {target.position}");
                Debug.Log($"[Arrow] Arrow position: {transform.position}, Distance to camera: {Vector3.Distance(transform.position, mainCamera.transform.position)}");
                Debug.Log($"[Arrow] Arrow visible in frustum: {IsVisibleFrom(GetComponent<Renderer>(), mainCamera)}");
            }
        }
        else
        {
            Update2DArrow();
        }

        // Optional: Update distance text
        if (distanceText != null)
        {
            float distance = Vector3.Distance(mainCamera.transform.position, target.position);
            distanceText.text = $"{distance:F1}m";
        }
    }

    private void Update3DArrow()
    {
        // Position arrow in front of camera with offset
        Vector3 forwardPos = mainCamera.transform.position +
                            mainCamera.transform.forward * distanceFromCamera;
        transform.position = forwardPos + mainCamera.transform.TransformDirection(offset);

        // Calculate direction to target
        Vector3 directionToTarget = target.position - mainCamera.transform.position;
        directionToTarget.y = 0; // Keep arrow horizontal (remove if you want vertical pointing too)

        if (directionToTarget.magnitude > 0.1f)
        {
            // Rotate arrow to point at target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = targetRotation;
        }
    }

    private void Update2DArrow()
    {
        // Project target position to screen space
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // Check if target is behind camera
        if (screenPos.z < 0)
        {
            screenPos.x = Screen.width - screenPos.x;
            screenPos.y = Screen.height - screenPos.y;
        }

        // Clamp to screen edges
        screenPos.x = Mathf.Clamp(screenPos.x, 50, Screen.width - 50);
        screenPos.y = Mathf.Clamp(screenPos.y, 50, Screen.height - 50);

        // Set arrow position (for UI)
        if (transform is RectTransform rectTransform)
        {
            rectTransform.position = screenPos;

            // Calculate rotation to point toward center if off-screen
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 direction = (Vector2)screenPos - screenCenter;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rectTransform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    // Helper to check if renderer is visible
    private bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        if (renderer == null) return false;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}