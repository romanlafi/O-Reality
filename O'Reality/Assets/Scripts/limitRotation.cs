using UnityEngine;

public class limitRotation : MonoBehaviour
{
    public float minRotationY;
    public float maxRotationY;

    void Update()
    {
        Quaternion rotation = Quaternion.Euler(transform.localEulerAngles);
        Vector3 eulerAngles = rotation.eulerAngles;
        eulerAngles.y = (eulerAngles.y + 180) % 360 - 180;
        eulerAngles.y = Mathf.Clamp(eulerAngles.y, minRotationY, maxRotationY);
        rotation = Quaternion.Euler(eulerAngles);
        transform.localRotation = rotation;
    }
}
