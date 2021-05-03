using System.Linq;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;
    public PlayerInput playerInput;

    void Update()
    {
        // this.playerInput accesses our own class' playerInput-field.
        // with the '.' we say that we want to access that field's class' contents.
        // with forwardKey, we say that we want to access the field forwardKey of that class.
        bool forward = Input.GetKey(this.playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool right = Input.GetKey(playerInput.rightKey);
        bool enter = Input.GetKeyDown(playerInput.enterKey);

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
            CarController closestCar = GetClosestCar();
            
            // Get the distance between the car's position and this' (the Human's) position
            float distance = Vector3.Distance(closestCar.transform.position, this.transform.position);
            
            // Only if the distance is smaller than the threshold...
            if (distance < 2f) // TODO: ALSO CHECK, THAT NOBODY ELSE IS IN THE CAR
            {
                closestCar.Enter(this.gameObject);
            }
            
        }
    }

    private CarController GetClosestCar()
    {
        return Resources.FindObjectsOfTypeAll<CarController>()
            .OrderBy((car) => Vector3.Distance(this.transform.position, car.transform.position))
            .First();
    }

    void Start()
    {
        this.transform.position = Vector3.zero;
    }
}