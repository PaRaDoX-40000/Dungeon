using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureConsumablesPanel : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text textConsumablesName;
    [SerializeField] private Text textDescription;
    [SerializeField] private Text textNumber;
    private Consumable consumable;

    private AdventurePanel adventurePanel;

    public void Init(string number, Consumable consumable, AdventurePanel adventurePanel)
    {
        icon.sprite = consumable.Icon;
        textConsumablesName.text = consumable.name;
        textDescription.text = consumable.Description;
        textNumber.text = number;
        this.adventurePanel = adventurePanel;
        this.consumable = consumable;
        gameObject.SetActive(true);
    }

    public void ChooseConsumable()
    {
        adventurePanel.ChooseConsumable(consumable);
    }
}
