using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;
    
    public KeyCode rotateLeftKey;
    public KeyCode rotateRightKey;

    // Update is called once per frame
    void Update()
    {
        // Rotates Right
        bool rotateRight = UnityEngine.Input.GetKey(rotateRightKey);
        if (rotateRight)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }
        
        // Rotates Left
        bool rotateLeft = UnityEngine.Input.GetKey(rotateLeftKey);
        if (rotateLeft)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}