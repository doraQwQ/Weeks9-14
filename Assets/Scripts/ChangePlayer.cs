using UnityEngine;
using UnityEngine.InputSystem;

public class ChangePlayer : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
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
        BounceTwo bounceTwo = GetComponent<BounceTwo>();
        Bounce bounce = GetComponent<Bounce>();
        if (bounceTwo.started == false && bounce.isJumping == false)  //ensure not in any jumps
        {


        }
    }
    public void WhoJumps(InputAction.CallbackContext context)
    {
        bool one = true;

    }
}
