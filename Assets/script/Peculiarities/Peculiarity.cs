using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Peculiarities new", menuName = "Peculiarities/Peculiarities", order = 51)]
public class Peculiarity:ScriptableObject
{
    

    [SerializeField] Distribution distribution;
    [SerializeField] Effect effect;

    public Distribution Distribution => distribution;
    public Effect Effect => effect;
}
