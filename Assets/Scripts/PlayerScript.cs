using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Transform gun;
    public Vector2 direction; 
    public Vector2 rotationAngle;
    public Vector3 value =new Vector3 (0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The Update function is called once per frame
        //and is used to move the player based on the directional input stored in the direction variable.
        transform.position += (Vector3) direction * Time.deltaTime;
        value.z = rotationAngle.x;
        gun.eulerAngles += value;
    }
    //This function reads the directional input from the player and stores it in a variable.
    //The variable is then used in the Update function to move the player.
    public void Move(InputAction.CallbackContext huh)
    {
        direction = huh.ReadValue<Vector2>();
    }
    public void RotateAngle(InputAction.CallbackContext whar)
    {
        rotationAngle = whar.ReadValue<Vector2>();
        //Debug.Log("ROTATE ANGLE " + rotationAngle);
    }
    
}
