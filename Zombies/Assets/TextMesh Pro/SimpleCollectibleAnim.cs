using UnityEngine;

public class SimpleCollectibleAnim : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float scaleAmount = 0.1f;
    public float scaleSpeed = 2f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        // Rotācija
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // Pulsācija (scale up/down)
        float scale = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = startScale * scale;
    }
}