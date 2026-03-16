using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Rendering.CameraUI;
/*Use the Trick Shot code from the week 3 coding gym. Change the code so that a public function OnJump() starts
the timer, instead of checking for the space key press. Add the PlayerInput component, set the Default Map to
Player and behaviour to Invoke UnityEvents, then use the Player Jump UnityEvent to call your OnJump() function.
*/

/*Make a shape move across the screen and bounce at the left and right edges.
When the player presses space, start a timer, and use the timer with an AnimationCurve to make the sprite
“jump”. This will need one more variable than you might think �������:
• If the player presses space, set a “timer is running” bool to true
• If the “timer is running” bool is true, make a timer count up using a speed variable (and Time.deltaTime)
• If the timer reaches 1 set the “timer is running” bool to false and reset the timer to 0
• Use the timer and an AnimationCurve to change the y position of the shape, adjust the curve till you get
motion that feels like a jump.
 */
public class TrickShot : MonoBehaviour
{
    public AnimationCurve jumpCurve;
    public float time=0;
    public float during=2;
    public float yValue;
    public bool isJumping=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (during > 2.3)
        {
            isJumping = false;
            during = 0;
        }
        if (isJumping)
        {
            during += Time.deltaTime;
            yValue = jumpCurve.Evaluate(during);
            Vector2 position = new Vector2(transform.position.x, yValue);
            transform.position = position;
        }
    }
    public void Onjump(InputAction.CallbackContext jump)
    {
        isJumping = true;


        
    }
}
