using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    // Fields describe what attributes a class HAS
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;
    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;

    public GameObject driver;

    // Methods describe what a class CAN DO
    void Update()
    {
        PlayerInput playerInput = driver.GetComponent<PlayerInput>();
        
        bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool right = Input.GetKey(playerInput.rightKey);
        bool exit = Input.GetKeyDown(playerInput.enterKey);
        
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (forward)
        {
            rigidbody.AddForce(transform.up * (movementSpeed * Time.deltaTime));
        }
        if (backward)
        {
            rigidbody.AddForce(-transform.up * (movementSpeed * Time.deltaTime));
        }
        if (left)
        {
            // We want to rotate on the z-axis:
            var rotateBy = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            // We rotate the transform:
            transform.Rotate(rotateBy);
            // And we also rotate the velocity, so that we do not continue sliding in the old direction:
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }
        if (right)
        {
            // documentation: see above
            var rotateBy = new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (exit)
        {
            driver.transform.position = this.transform.position;
            driver.SetActive(true);
            this.enabled = false;
            driver = null;
        }
        // Pseudo-Code:
        // if (exit)
        // set the driver's position to our own position
        // activate the driver
        // disable ourselves (this script)
    }
}