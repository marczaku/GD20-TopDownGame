using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode enterKey;

    void Update()
    {
        bool forward = Input.GetKey(forwardKey);
        bool backward = Input.GetKey(backwardKey);
        bool left = Input.GetKey(leftKey);
        bool right = Input.GetKey(rightKey);
        bool enter = Input.GetKeyDown(enterKey);
        

        // If the Forward Key is Pressed, MOVE the TRANSFORM in the UP-direction
        // scaled by the MOVEMENT SPEED and the DELTA TIME (the time that has passed)
        if (forward)
        {
            this.transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
        }
        if (backward)
        {
            this.transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));
        }
        if (left)
        {
            this.transform.Translate(Vector3.left * (movementSpeed * Time.deltaTime));
        }
        if (right)
        {
            this.transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
        }

        if (enter)
        {
            // Find the car-GameObject through its name "Car"
            GameObject car = GameObject.Find("Car");

            // Get the distance between the car's position and this' (the Human's) position
            float distance = Vector3.Distance(car.transform.position, this.transform.position);
            
            // Only if the distance is smaller than the threshold...
            if (distance < 2f)
            {
                // Assign the value true
                // To the CarController-Component
                // On the car-GameObject
                MarcCarController carController = car.GetComponent<MarcCarController>();
                carController.enabled = true;
                carController.driver = this.gameObject;
                
                // And disable this' (the Human's) game object
                this.gameObject.SetActive(false);
            }
            
        }
    }

    void Start()
    {
        this.transform.position = Vector3.zero;
    }
}