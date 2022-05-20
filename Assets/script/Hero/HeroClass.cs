using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroClass", menuName = "HeroClass/HeroClass", order = 51)]

public class HeroClass : ScriptableObject
{
    [SerializeField] private string[] names;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private int clas;

    public Sprite[] Sprite => sprite;
    public int Clas => clas;

    public string[] Names => names; 
}
