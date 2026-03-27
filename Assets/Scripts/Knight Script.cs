using UnityEngine;
using UnityEngine.InputSystem;

public class KnightScript : MonoBehaviour
{
    public AudioSource audiosource;
    public float speed = 5f;
    public float xMovenment;
    public Animator knightAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovenment, 0, 0) * speed * Time.deltaTime;
    }
    //For moving the character
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2  moveDirection = context.ReadValue<Vector2>();
        xMovenment = moveDirection.x;

        bool isRunning = xMovenment != 0;
        knightAnimator.SetBool("IsRunning", true);
    }
    //Basically play the sound
    public void OnFootstepint ()
    {
        Debug.Log("Footsteps");
        audiosource.Play();
    }
    
}
