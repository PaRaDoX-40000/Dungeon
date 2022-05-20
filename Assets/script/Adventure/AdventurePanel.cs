using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePanel : MonoBehaviour 
{
    [SerializeField] private DungeonCollection dungeonCollection;
    [SerializeField] private AdventurePanelUI adventurePanelUI;
    [SerializeField] private CommonHeir commonHeir;   
    [SerializeField] private Transform сonnectorAdventures;
    [SerializeField] private PeculiaritiesCollection peculiaritiesCollection;
    [SerializeField] private ReportPanel reportPanel;
    [SerializeField] private GameObject adventurePrefab;

    private int maxHero = 4;
    private Hero[] chosenHeroes;
    private List<Consumable> chosenConsumable =new List<Consumable>();

    private void OnEnable()
    {
        chosenHeroes = new Hero[maxHero];
        adventurePanelUI.СreateHeroSlot(maxHero);
        ShowHeroes();
        adventurePanelUI.ShowConsumablesSlots(chosenConsumable);

    }

    public void ShowConsumables()
    {
        adventurePanelUI.ShowConsumables(commonHeir.dataBase.consumables);
    }
    public void ShowHeroes()
    {
        adventurePanelUI.ShowHeroes(commonHeir.dataBase.hero);
    }
    public void ChooseHero(Hero hero)
    {       
        for (int i = 0; i< chosenHeroes.Length;i++)
        {           
            if (chosenHeroes[i] == null)
            {               
                chosenHeroes[i] = hero;
                commonHeir.dataBase.hero.Remove(hero);
                ShowHeroes();
                adventurePanelUI.ChangeHeroIcon(hero, i);
                break;
            }
        }
    }

    public void ChooseConsumable(Consumable consumable)
    {
        chosenConsumable.Add(consumable);
        commonHeir.dataBase.TryRemoveConsumable(consumable);
        ShowConsumables();
        adventurePanelUI.ShowConsumablesSlots(chosenConsumable);
    }

    public void ReturnConsumable(Consumable consumable)
    {
        commonHeir.dataBase.AddConsumables(new List<Consumable>() { consumable });
        chosenConsumable.Remove(consumable);
        ShowConsumables();
        adventurePanelUI.ShowConsumablesSlots(chosenConsumable);

    }

    public void ReturnHero(Hero hero,int number)
    {
        commonHeir.dataBase.AddHeros(new List<Hero>() { hero });
        chosenHeroes[number] = null;
        ShowHeroes();
    }

    public void StartAdventure()
    {
        if (chosenHeroes!=null)
        {
            List<HeroPeculiarity> heroPeculiarities = new List<HeroPeculiarity>();
            foreach (Hero hero in chosenHeroes)
            {
                if (hero != null)
                {
                    heroPeculiarities.AddRange(hero.HeroPeculiarities);
                }
            }
            GameObject adventureGameObject = Instantiate(adventurePrefab);
            adventureGameObject.transform.SetParent(сonnectorAdventures);
            Adventure adventure = adventureGameObject.GetComponent<Adventure>();
            adventure.Init(chosenHeroes, chosenConsumable, commonHeir,reportPanel, heroPeculiarities);            
            СlearAdventurePanel();
        }
       
    }

    private void СlearAdventurePanel()
    {
        for(int i =0;i< chosenHeroes.Length;i++)
        {
            chosenHeroes[i] = null;
        }
        chosenConsumable.Clear();
        adventurePanelUI.ShowConsumablesSlots(chosenConsumable);
        adventurePanelUI.СreateHeroSlot(maxHero);
    }
   
    public void ClearAdventurePanel()
    {
        List<Hero> heros = new List<Hero>();
        foreach(Hero hero in chosenHeroes)
        {
            if (hero != null)
            {
                heros.Add(hero);
            }
        }
        commonHeir.dataBase.AddHeros(heros);

        commonHeir.dataBase.AddConsumables(chosenConsumable);
        chosenConsumable.Clear();
    }
    private void OnDisable()
    {
        ClearAdventurePanel();
    }




}
