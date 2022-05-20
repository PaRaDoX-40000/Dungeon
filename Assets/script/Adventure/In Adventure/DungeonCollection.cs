using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCollection : MonoBehaviour
{
    [SerializeField] private List<Dungeon> dungeons = new List<Dungeon>();

    public List<Dungeon> Dungeons => dungeons;
}
