using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryEquipmentPanel : MonoBehaviour
{

   //[SerializeField] HeroEquipmentPanel HeroEquipmentPanel;
   private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void Awake()
    {
        inventorySlots.AddRange(transform.GetComponentsInChildren<InventorySlot>());
        if (inventorySlots.Count == 0)
        {
            Debug.Log("нет слотов");
        }
    }
    

    public void ShowEquipable(int clase,DataBase dataBase)
    {
        int counter = 0;
        
        foreach (Equipable equipable in dataBase.inventory.Where(equip => equip.EquipableClass.classes.Contains((EquipableClass.Class)clase)))
        {
            
            inventorySlots[counter].Init(equipable);
            counter++;
        }
        for(int i = counter; i< inventorySlots.Count; i++)
        {
            inventorySlots[i].gameObject.SetActive(false);
        }
    }
    public void ShoweEmpty()
    {
       foreach(InventorySlot inventorySlot in inventorySlots)
        {
            inventorySlot.gameObject.SetActive(false);
        }
    }
}
