using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private HeroEquipmentPanel HeroEquipmentPanel;
    private Equipable equipable;

    public void Init(Equipable equipable)
    {
        icon.sprite = equipable.Icon;
        this.equipable = equipable;
        gameObject.SetActive(true);
    }
    
  
    public void ShowDetailedEquipable()
    {
        HeroEquipmentPanel.ShowDetailedEquipable(equipable);
    }
}
