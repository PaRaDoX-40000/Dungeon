using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumablesCraftPanelIU : MonoBehaviour
{       
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text descriptionText;    
    [SerializeField] private Button buttonCraft;
    [SerializeField] private TMP_Text golgText;
    [SerializeField] private PictureWithText[] lootText;

    public void Inin(ConsumablesRecipe consumablesRecipe)
    {
        iconImage.sprite = consumablesRecipe.Consumable.Icon;
        descriptionText.text = consumablesRecipe.Consumable.Description;
        buttonCraft.interactable = consumablesRecipe.EnoughIngredients;
        golgText.text = consumablesRecipe.Gold.ToString();

        for (int i = 0; i < consumablesRecipe.Ingredients.Length; i++)
        {
            lootText[i].Init(consumablesRecipe.Ingredients[i].Loot.Icon, consumablesRecipe.Ingredients[i].StringRatio);
            if (consumablesRecipe.Ingredients[i].Enough == true)
                lootText[i].SetColorText(Color.white);
            else
                lootText[i].SetColorText(Color.red);
        }
        for (int i = consumablesRecipe.Ingredients.Length; i < lootText.Length; i++)
        {
            lootText[i].gameObject.SetActive(false);
            
        }
    }

}
