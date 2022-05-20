using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    //public int MaximumEnemies;
    //public List<Hero> heroes;
    //public int chanceForPointOfInterest;
    [SerializeField] private List<GroupEnemies> groupEnemies;
    [SerializeField] private List<RarityLoot> rarityLoot;
    [SerializeField] private int lenght;
    //public int difficulity;
    /*public bool decision;*/ //1 - будут драться, 0 - убегут
                         

    public List<RarityLoot> RarityLoot => rarityLoot;
    public List<GroupEnemies> GroupEnemies => groupEnemies;
    public int Lenght => lenght;


}
