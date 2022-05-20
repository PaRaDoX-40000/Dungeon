using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LootAmountChangerPanelUI))]
public class LootAmountChangerPanel : MonoBehaviour
{
    private Loot loot;
    private int number;
    private int maxValue;

    [SerializeField] private CraftEquipable craftEquipable;
    [SerializeField] private LootAmountChangerPanelUI lootAmountChangerPanelUI;

    private void OnEnable()
    {
        craftEquipable.ReachedMaximumLoots += SetAddbuton;
    }
    private void OnDisable()
    {
        craftEquipable.ReachedMaximumLoots -= SetAddbuton;
    }


    public void Init(Loot loot,int numberInDataBase, int numberInCraft, bool craftFull)
    {
        lootAmountChangerPanelUI.Init(loot, numberInDataBase, numberInCraft);
        number = numberInCraft;
        maxValue = numberInDataBase;
        SetInteractableButton(craftFull);
        this.loot = loot;
       
        gameObject.SetActive(true);

    }

    public void ClikButtonAdd()
    {
        
        number++;
        lootAmountChangerPanelUI.ChangeValues(maxValue, number);
        SetInteractableButton();
        craftEquipable.AddLoot(loot);



    }
    public void ClikButtonRemove()
    {
        
        number--;
        lootAmountChangerPanelUI.ChangeValues(maxValue, number);
        SetInteractableButton();
        craftEquipable.RemoveLoot(loot);
    }
    
    public void SetInteractableButton(bool CraftFull = false)
    {
        if (CraftFull == true)        
            lootAmountChangerPanelUI.SetAddButton(false);      
        else
            lootAmountChangerPanelUI.SetAddButton(number != maxValue);
        lootAmountChangerPanelUI.SetRemoveButton(number > 0);

    }

    public void SetAddbuton(bool interactable)
    {
        lootAmountChangerPanelUI.SetAddButton(!interactable);
    }






}
