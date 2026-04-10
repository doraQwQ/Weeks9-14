using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class BounceTwo : MonoBehaviour
{
    public bool started = false;
    public Vector3 positions;
    public Vector3 startPos;
    public AnimationCurve curve;
    public float duration = 2;
    public float value;
    public float progress = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            progress += Time.deltaTime / duration;
            value = curve.Evaluate(progress);
            positions = startPos;
            positions.y += value;
            transform.position = positions;

            if (progress >= 1)
            {
                progress = 0;
                transform.position = startPos;
                started = false;
            }
        }
    }
    public void OnJumpTwo(InputAction.CallbackContext context)
    {
        if(context.started && !started)
        {
            started = true;
            startPos = transform.position;
            startPos.z = 0;
        }

    }
}
