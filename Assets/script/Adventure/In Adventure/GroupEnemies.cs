using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroupEnemies
{

    [SerializeField] private Enemy enemy;
    [SerializeField] private int maxGrup;

    public Enemy Enemy => enemy;
    public int MaxGrup => maxGrup;
}
   

