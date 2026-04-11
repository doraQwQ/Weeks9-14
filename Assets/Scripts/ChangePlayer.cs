using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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
        if (context.started && !playerOne.isJumping && !playerTwo.isJumping)    //prevent glitches
        {
            {
                one = !one;
                print(one);
            }
            if (one)// Player one active
            {
                playerOne.transform.position = new Vector3(0.02f, -1.81f, 0f);
                playerTwo.transform.position = new Vector3(20, -1.81f, 0);
                print(playerTwo.transform.position);
            }
            else if (one == false)// Player two active
            {
                playerTwo.transform.position = new Vector3(0.02f, -1.81f, 0f);
                playerOne.transform.position = new Vector3(20, -1.81f, 0);
                print(playerOne.transform.position);
            }
        }

    }
    public void OnJumps(InputAction.CallbackContext context)
    {
      
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
    public void stopClapperboard(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerTwo.StopJumpTwo();
            playerOne.StopJump();
        }
    }
}
