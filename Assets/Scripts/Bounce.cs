using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEditor.Rendering.CameraUI;
public class Bounce : MonoBehaviour
{
    
    public Vector3 positions;
    public Vector3 startPos;
    public bool isJumping=false;
    public AnimationCurve curve;
    public float duration=2;
    public float value;
    public float progress = 0;
    public AudioSource audioSource;
    private Coroutine jumpCorotine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame  
    void Update()
    {
        
    }
    /*This part uses a pre-recorded positon.
     * Later another value = the pre-recorded pos plus the curve position.
     * assign back to the transform position to have a bounce effect.*/
    private IEnumerator JumpCorotine()
    {
        startPos = transform.position;
        startPos.z = 0;
        progress = 0;

        while (progress < 1)
        {
            progress += Time.deltaTime / duration;
            value = curve.Evaluate(progress);

            positions = startPos;
            positions.y += value;

            transform.position = positions;

            yield return null; 
        }
        progress = 0;
        transform.position = startPos;
        isJumping = false;
    }
    //When the user presses jump
    //It starts the jumping corotine.
    //it also prevent corotine starts if there is one that is already running.
    public void OnJump()
    {
        jumpCorotine = StartCoroutine(JumpCorotine());
        audioSource.Play();
        isJumping=true;

    }

}
