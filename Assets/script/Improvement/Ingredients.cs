using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient
{
    [SerializeField] private Loot loot;
    [SerializeField] private int number;
    private bool enough = false;
    private string stringRatio;


    public Loot Loot => loot;
    public int Number => number;
    public string StringRatio  => stringRatio;
    public bool Enough => enough;

    public void SetState(int numberInDataBase)
    {              
        enough = number <= numberInDataBase;
        stringRatio = number+"/"+numberInDataBase;


    }
}
