using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipableClassCraft : MonoBehaviour
{
    [SerializeField] private EquipableClass equipableClass;
    [SerializeField] private StatsApp.Stats[] permissibleStats;
    [SerializeField] private StatsApp[] debuffs;
    [SerializeField] private Image imageIcon;

    public EquipableClass EquipableClass => equipableClass; 
    public StatsApp.Stats[] PermissibleStats => permissibleStats; 
    public StatsApp[] Debuffs => debuffs; 
    public Image ImageIcon => imageIcon;
}
