using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Wk13CodingGmPlayerInput : MonoBehaviour
{
    public Wk13CodingGymManagerscript manager;
    public Vector2 moveDirection;
    public float moveSpeed;


    public bool isSqueezed = false;
    public Coroutine squeezeCorotine;
    public AnimationCurve Curve;
    public float duration = 1;
    public float value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
    //Actitivate a attack 
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PLayer is attacking: ");
            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TyAttack(playerInput);
        }
    }
    public IEnumerator SqueezeCoroutine()
    {
        Vector3 orignalscaled = transform.localScale;
        Vector3 newScale = transform.localScale;

        while (duration < 1)
        {
            newScale.y = Curve.Evaluate(Time.deltaTime / duration)+ orignalscaled.y;
            //possiblePlayerVisuals[numOfPlayerBeingAtk].transform.localScale=value*Vector3.one;
            transform.localScale = newScale;
            yield return null;

        }
        
    }
    //This activates the squeeze coroutine when the player is attacked
    public void OnSqueezed()
    {
        squeezeCorotine = StartCoroutine(SqueezeCoroutine());
    }
}
