using UnityEngine;

public class PlayerController : MonoBehaviour // The PlayerController inherits from / IS A MonoBehaviour...
{ // ... and implements / CONTAINS everything between these Curly Brackets

    public float movementSpeed = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        // We assign the Righthand-Side
        // - which is the Result of the GetKey-Method
        // - which is of type 'bool'
        // To the Lefthand-Side
        // - which is a variable named forward
        // - which is of type 'bool'
        bool forward = UnityEngine.Input.GetKey(KeyCode.W);
        
        // Only move up if the User wants to go forward
        if (forward)
        {
            // transform points to this GameObject's Transform-Component
            // Translate Moves the Transform in a certain direction
            // Vector3.up is always X: 0, Y: 1, Z: 0
            
            // we multiply it with the movement speed
            // movement speed of 0.5 means, we walk half as fast
            // movement speed of 2 means, we walk twice as fast
            
            // we multiply it with delta time
            // so we walk faster, the more time has passed
            // if only half a second has passed, we walk only half the distance
            // if two seconds have passed, we walk twice the distance
            transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
