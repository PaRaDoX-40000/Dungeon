using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureConsumableSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Consumable consumable;
    private AdventurePanel adventurePanel;

    public void Init(Consumable consumable, AdventurePanel adventurePanel)
    {
        icon.sprite = consumable.Icon;
        this.consumable = consumable;
        this.adventurePanel = adventurePanel;
    }

    public void ReturnConsumable()
    {
        adventurePanel.ReturnConsumable(consumable);
    }
}
