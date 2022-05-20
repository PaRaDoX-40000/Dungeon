using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour 
{    
    [SerializeField] private GameObject[] window;
    static private GameObject targetWindow;
    void CloseWindow()
    {        
        targetWindow?.SetActive(false);    
    }
    public void OpenWindow()
    {
        CloseWindow();
        window[0].SetActive(true);
        targetWindow = window[0];      
        
    }

    public void OnClik()
    {      
        if (window[0].activeSelf == false)
        {
            OpenWindow();
        }
        else
        {
            CloseWindow();
        }
    }






}
