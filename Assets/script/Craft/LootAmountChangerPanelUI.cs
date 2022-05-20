using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class LootAmountChangerPanelUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private TMP_Text numberText;
    [SerializeField] private Button addLootButton;
    [SerializeField] private Button removeLootButton;

    public void Init(Loot loot,int numberInDataBase, int numberInCraft)
    {       
        icon.sprite = loot.Icon;
        valueText.text = "+" + loot.StatsApp.Value;
        numberText.text = numberInCraft + "/" + numberInDataBase;
    }
    public void ChangeValues(int numberInDataBase, int numberInCraft)
    {       
        numberText.text = numberInCraft + "/" + numberInDataBase;        
    }

    public void SetAddButton(bool interactable)
    {
        addLootButton.interactable = interactable;
    }
    public void SetRemoveButton(bool interactable)
    {
        removeLootButton.interactable = interactable;
    }

    



}
