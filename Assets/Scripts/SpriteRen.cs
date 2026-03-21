using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteRen: MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>(3);
    public int count = 0;
    public SpriteRenderer sR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        sR= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEInteract(InputAction.CallbackContext context)
    {
       
            
        if (count == spriteList.Count)
        {
            count = 0;
        }
        else
        {
            count++;
        }

            sR.sprite = spriteList[count];
    }
}
