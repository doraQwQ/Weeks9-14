using UnityEngine;
using UnityEngine.InputSystem;

public class ChangePlayer : MonoBehaviour
{
    public Bounce playerOne;
    public BounceTwo playerTwo;
    public bool one = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangePlayers(InputAction.CallbackContext context)
    {
        bool activated = false;
        if (!playerOne.isJumping && !playerTwo.isJumping)
        {
            one = !one;
            activated = false;
        }
        if (!activated)
        {
            playerTwo.transform.position = new Vector3(20f, 20f, 0);
            activated = true;
        }
        if (!activated)
        {
            playerOne.transform.position = new Vector3(20f, 20f, 0);
            activated = true;
        }
    }
    public void OnJumps(InputAction.CallbackContext context)
    {
        //if (context.started)
        //{
        //    playerOne.OnJump();
        //    
        //}
        one = false;
        if (one && context.started && !playerOne.isJumping)
        {
            playerOne.OnJump();
            Debug.Log(one);
            Debug.Log("Player One Jumped");

        }
        else if (!one && context.started && !playerTwo.isJumping)
        {
            playerTwo.OnJumpTwo();
            Debug.Log("Player Two Jumped");
        }
    }
}
