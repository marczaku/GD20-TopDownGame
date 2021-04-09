using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    void Update()
    {
        bool forward = Input.GetKey(forwardKey);
        bool backward = Input.GetKey(backwardKey);
        bool left = Input.GetKey(leftKey);
        bool right = Input.GetKey(rightKey);
        
        // But the performance impact is almost zero for a small game like this
        // So let's just get everything we need whenever we need it:
        
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        // transform.forward (x: 0, y: 0, z: 1)
        // transform.up (x: 0, y: 1)
        rigidbody.AddForce(transform.up*movementSpeed);
        //rigidbody.velocity.magnitude
    }
}