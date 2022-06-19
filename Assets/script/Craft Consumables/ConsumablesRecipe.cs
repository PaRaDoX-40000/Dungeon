using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(ConsumablesRecipeUI))]
public class ConsumablesRecipe : MonoBehaviour
{
    private bool enoughIngredients;
    [SerializeField] private ConsumablesCraft consumablesCraft;
    [SerializeField] private Ingredient[] ingredients;
    [SerializeField] private Consumable consumable;
    [SerializeField] private int gold;
    [SerializeField] private ConsumablesRecipeUI consumablesRecipeUI;

    public Ingredient[] Ingredients => ingredients; 
    public Consumable Consumable => consumable; 
    public int Gold => gold;

    public bool EnoughIngredients => enoughIngredients;

   

    private void Awake()
    {
        consumablesRecipeUI = GetComponent<ConsumablesRecipeUI>();
        consumablesCraft = GetComponentInParent<ConsumablesCraft>();
    }

   public void ShowConsumablesRecipe(DataBase dataBase,bool active)
   {      
        CanCreate(dataBase);
        consumablesRecipeUI.Init(this, active);
   }
    public void ShowTargetConsumables()
    {
        consumablesCraft.ShowTargetConsumables(this);
    }

    public void CanCreate(DataBase dataBase)
    {
        enoughIngredients = true;
        foreach (Ingredient ingredient in ingredients)
        {     
            if (dataBase.loots.ContainsKey(ingredient.Loot))
            {               
               if(dataBase.loots[ingredient.Loot] < ingredient.Number)
               {
                    enoughIngredients = false;                    
               }
                ingredient.SetState(dataBase.loots[ingredient.Loot]);
            }
            else
            {
                enoughIngredients = false;
                ingredient.SetState(0);
            }           
        }
        if(dataBase.gold < gold)
        {
            enoughIngredients = false;
        }      
    }
   



}
