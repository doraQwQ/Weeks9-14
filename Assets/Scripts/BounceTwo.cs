using System.Collections;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
//This script lets the player to jump and fall down.
//Player will change face in between, and cracks on wall will appear
public class BounceTwo : MonoBehaviour
{
    public bool isJumping = false;
    public Vector3 positions;
    public Vector3 startPos;
    public AnimationCurve curve;

    public float duration = 2;
    public float value;
    public float progress = 0;

    public Sprite jump;
    public Sprite fall;
    
    public GameObject crack;
    public GameObject crackTwo;

    public SpriteRenderer spriteRD;
    public AudioSource audioSource;
    private Coroutine jumpCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRD=GetComponent<SpriteRenderer>();
        crack.SetActive(false);
        crackTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //The coroutine that cause the jump
    //Uses a animationcurve to control jump height
    //There are sprite changes in between
    private IEnumerator JumpCoroutine()
    {
        startPos = transform.position;
        startPos.z = 0;
        progress =0;
        while (progress < 1)
        {
            progress += Time.deltaTime / duration;
            value = curve.Evaluate(progress);
            positions = startPos;
            positions.y += value;
            transform.position = positions;

            if (progress > 0.134)
            {
                crack.SetActive(true);
                crackTwo.SetActive(true);
            }

            if (progress < 0.4f)
            {
                spriteRD.sprite = jump;
            }
            else if (progress > 0.4f)
            {
                spriteRD.sprite = fall;
            }
            yield return null;
        }
        crack.SetActive(false);
        crackTwo.SetActive(false);
        progress = 0;
        transform.position = startPos;
        spriteRD.sprite = jump;
        isJumping = false;
    }
    //this starts the corotine and prevent another corotine happen,
    //if there is one running already.
    public void OnJumpTwo()
    {
        jumpCoroutine = StartCoroutine(JumpCoroutine());
        isJumping = true;
        audioSource.Play();
    }
    
}
