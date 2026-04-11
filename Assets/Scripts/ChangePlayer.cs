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

            }
            if (one)// Player one active
            {
                playerTwo.crack.SetActive(false);
                playerTwo.crackTwo.SetActive(false);
                playerOne.transform.position = new Vector3(0.02f, -1.81f, 0f);
                playerTwo.transform.position = new Vector3(20, -1.81f, 0);

            }
            else if (one == false)// Player two active
            {
                playerTwo.transform.position = new Vector3(0.02f, -1.81f, 0f);
                playerOne.transform.position = new Vector3(20, -1.81f, 0);

            }
        }

    }
    //This method sends a message to the player to jump.
    public void OnJumps(InputAction.CallbackContext context)
    {
      
        if (one && context.started && !playerOne.isJumping)
        {
            playerOne.OnJump();

        }
        else if (!one && context.started && !playerTwo.isJumping)
        {
            playerTwo.OnJumpTwo();
        }
    }
    //This method sends a message to stop the coroutine of both players.
    public void stopClapperboard(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerTwo.StopJumpTwo();
            playerOne.StopJump();
        }
    }
}
