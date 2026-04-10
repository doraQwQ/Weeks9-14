using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayer : MonoBehaviour
{
    public LocalMultiPlayerManager manager;
    public Vector2 moveDirection;
    public float moveSpeed;

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

}
