using UnityEngine;

public class Pulse : MonoBehaviour
{
    public AnimationCurve pulseCurve;
    public Vector3 location;
    public float time;
    public float duration=4;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenPosition = transform.position;
        ScreenPosition.x += 5*Time.deltaTime;
        ScreenPosition.z = 0;
        if (ScreenPosition.x > Screen.width)
        {
            ScreenPosition.x = 0;
        }
        ScreenPosition.y= pulseCurve.Evaluate(time/duration);
        Vector3 worldPosition = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3  = Camera.main.ScreenToWorldPoint(ScreenPosition);
        transform.position = worldPosition;
    }
}
