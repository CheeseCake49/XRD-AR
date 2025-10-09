using UnityEngine;

public class FloatingMotion : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatAmplitude = 0.5f;     // Height of up-and-down motion
    public float floatFrequency = 1f;       // Speed of vertical motion

    [Header("Circular Motion Settings")]
    public float rotationRadius = 1f;       // Radius of circular motion
    public float rotationSpeed = 1f;        // Speed of circular motion

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Time-based calculations
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        float x = Mathf.Cos(Time.time * rotationSpeed) * rotationRadius;
        float z = Mathf.Sin(Time.time * rotationSpeed) * rotationRadius;

        // Combine base position with circular and floating motion
        transform.position = startPos + new Vector3(x, floatOffset, z);
    }
}
