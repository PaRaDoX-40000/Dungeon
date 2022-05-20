using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class Test:MonoBehaviour
{
    public List<Coroutine> coroutines = new List<Coroutine>();
    private void Start()
    {
        coroutines.Add(StartCoroutine(tes("tes1")));
        StartCoroutine(tes2("tes1"));


    }

    public IEnumerator tes (string text)
    {
        
        
            yield return new WaitForSeconds(1);
            Debug.Log("до");
        

    }
    public IEnumerator tes2(string text)
    {


        yield return new WaitForSeconds(0.5f);
        
        StopCoroutine(coroutines[0]);
       

    }



}
