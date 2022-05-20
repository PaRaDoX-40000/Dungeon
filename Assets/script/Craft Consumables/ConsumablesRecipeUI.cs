using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ConsumablesRecipeUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private PictureWithText[] lootText;
    [SerializeField] private Image consumablesRecipePanel;
    [SerializeField] private Color colorСanСreate;
    [SerializeField] private Color colorСannotСreated;

    public void Init(ConsumablesRecipe consumablesRecipe,bool active)
    {
        if (active == true)
        {
            iconImage.sprite = consumablesRecipe.Consumable.Icon;
            nameText.text = consumablesRecipe.Consumable.name;
            
            for (int i = 0; i < consumablesRecipe.Ingredients.Length; i++)
            {
                lootText[i].Init(consumablesRecipe.Ingredients[i].Loot.Icon, "X" + consumablesRecipe.Ingredients[i].Number);
            }
            for (int i = consumablesRecipe.Ingredients.Length; i < lootText.Length; i++)
            {
                lootText[i].gameObject.SetActive(false);
            }
            if (consumablesRecipe.EnoughIngredients == true)
            {
                consumablesRecipePanel.color = colorСanСreate;
            }
            else
            {
                consumablesRecipePanel.color = colorСannotСreated;
            }
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
        

    }

}
