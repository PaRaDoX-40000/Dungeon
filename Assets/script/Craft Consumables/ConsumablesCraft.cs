using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumablesCraft : MonoBehaviour
{
    [SerializeField]private DataBase dataBase;
    private int maxConsumables = 2;
    private ConsumablesRecipe targetConsumablesRecipe;
    [SerializeField] private ConsumablesRecipe[] consumablesRecipes;
    [SerializeField] private ConsumablesCraftPanelIU ConsumablesCraftPanelIU;

    private void OnEnable()
    {
        ShowConsumablesRecipe();
        ShowTargetConsumables(consumablesRecipes[0]);
    }

    public void ShowConsumablesRecipe()
    {
        for(int i = 0;i< maxConsumables; i++)
        {
            consumablesRecipes[i].ShowConsumablesRecipe(dataBase,true);
        }
        for (int i = maxConsumables; i < consumablesRecipes.Length; i++)
        {
            consumablesRecipes[i].ShowConsumablesRecipe(dataBase,false);
        }
    }

    public void ShowTargetConsumables(ConsumablesRecipe consumablesRecipe) 
    {
        targetConsumablesRecipe = consumablesRecipe;
        ConsumablesCraftPanelIU.Inin(targetConsumablesRecipe);
    }

    public  void StartConsumablesCraft()
    {
        if (dataBase.TryСhangeGold(targetConsumablesRecipe.Gold))
        {
            foreach (Ingredient ingredient in targetConsumablesRecipe.Ingredients)
            {
                dataBase.TryRemoveLoot(ingredient.Loot, ingredient.Number);                
            }
            dataBase.AddConsumable(targetConsumablesRecipe.Consumable);
            ShowConsumablesRecipe();
            ShowTargetConsumables(targetConsumablesRecipe);
        }
    }
    
}
