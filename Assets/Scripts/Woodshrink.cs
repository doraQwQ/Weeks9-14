using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Woodshrink : MonoBehaviour
{
    public AnimationCurve curvey;
    public float duration;
    public float time;
    public Coroutine corr;
    public Button buttonyay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Woodsmaller()
    {
        while (time < duration)
        {
            time += Time.deltaTime;
            transform.localScale = curvey.Evaluate(time / duration) * Vector3.one;
            yield return null;
        }
        buttonyay.interactable = true;
        time = 0;
    }
    public void CallCoroutine()
    {
        corr = StartCoroutine(Woodsmaller());
        buttonyay.interactable = false;
    }
}
