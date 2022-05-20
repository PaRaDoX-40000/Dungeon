using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableClass : MonoBehaviour
{
    public enum Class
    {
        Warrior = 1,
        Archer = 2,
        Mag = 3
    }
    public enum EquippableSlot
    {
        Weapon = 0,
        Armor = 1,
        Mascot = 2
    }
    public EquippableSlot equippableSlot;
    public List<Class> classes;

}
