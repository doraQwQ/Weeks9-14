using UnityEngine;
using UnityEngine.UI;

public class ManagerScipt : MonoBehaviour
{
    public int turnOrder=1;
    public Button button1;
    public Button button2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicked()
    {
        if (turnOrder == 1)
        {
            button1.interactable = true;
            if(corr!= null)
            {
                button1.interactable = false;
            }          
             turnOrder = 2;
        }
        else if (turnOrder == 2)
        {
            button1.interactable = false;
        }
    }

}
