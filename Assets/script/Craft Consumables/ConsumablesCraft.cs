using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumablesCraft : MonoBehaviour
{
    [SerializeField]private CommonHeir commonHeir;
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
            consumablesRecipes[i].ShowConsumablesRecipe(commonHeir.dataBase,true);
        }
        for (int i = maxConsumables; i < consumablesRecipes.Length; i++)
        {
            consumablesRecipes[i].ShowConsumablesRecipe(commonHeir.dataBase,false);
        }
    }

    public void ShowTargetConsumables(ConsumablesRecipe consumablesRecipe) 
    {
        targetConsumablesRecipe = consumablesRecipe;
        ConsumablesCraftPanelIU.Inin(targetConsumablesRecipe);
    }

    public  void StartConsumablesCraft()
    {
        if (commonHeir.dataBase.TryСhangeGold(targetConsumablesRecipe.Gold))
        {
            foreach (Ingredient ingredient in targetConsumablesRecipe.Ingredients)
            {
                commonHeir.dataBase.TryRemoveLoot(ingredient.Loot, ingredient.Number);                
            }
            commonHeir.dataBase.AddConsumable(targetConsumablesRecipe.Consumable);
            ShowConsumablesRecipe();
            ShowTargetConsumables(targetConsumablesRecipe);
        }
    }
    
}
