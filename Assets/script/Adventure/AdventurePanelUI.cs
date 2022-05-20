using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurePanelUI : MonoBehaviour
{
    [SerializeField] private Transform сonnectorHero;
    [SerializeField] private Transform сonnectorConsumables;
    [SerializeField] private Transform сonnectorHeroSlots;

    [SerializeField] private GameObject heroPanel;
    [SerializeField] private GameObject consumablesPanel;
    [SerializeField] private GameObject consumablesSlot;
    [SerializeField] private GameObject heroSlot;


    [SerializeField] private AdventureHeroSlot[] heroSlots; 

    [SerializeField] private Sprite defaultHeroSlot;

    [SerializeField] private AdventurePanel adventurePanel;

    private List<GameObject> conectorHeroObjects = new List<GameObject>();
    private List<GameObject> сonnectorConsumablesObjects = new List<GameObject>(); 


    public void ShowHeroes(List<Hero> heroes)
    {
        СlearListObject(conectorHeroObjects);
        foreach (Hero hero in heroes)
        {

            AdventureHeroPanel adventureHeroPanel = Instantiate(heroPanel, сonnectorHero).GetComponent<AdventureHeroPanel>();
            conectorHeroObjects.Add(adventureHeroPanel.gameObject);
            adventureHeroPanel.Init(hero, adventurePanel);
        }
    }
    public void ShowConsumables(Dictionary<Consumable, int> consumables)
    {
        СlearListObject(conectorHeroObjects);

        Dictionary<Consumable, int>.KeyCollection consumablesKey = consumables.Keys;

        foreach (Consumable consumable in consumablesKey)
        {

            PanelAdventureConsumables panelAdventureConsumables = Instantiate(consumablesPanel, сonnectorHero).GetComponent<PanelAdventureConsumables>();
            conectorHeroObjects.Add(panelAdventureConsumables.gameObject);
            panelAdventureConsumables.Init(consumables[consumable].ToString(), consumable, adventurePanel);
        }
    }

    private void СlearListObject(List<GameObject> ListObject)
    {
        if (ListObject != null)
        {
            while (ListObject.Count != 0)
            {
                Destroy(ListObject[0]);
                ListObject.Remove(ListObject[0]);
            }
        }
    }

    public void ChangeHeroIcon(Hero hero, int number)
    {
        heroSlots[number].ChangeHeroIcon(hero);
    }

    public void ShowConsumablesSlots(List<Consumable> consumables)
    {
        СlearListObject(сonnectorConsumablesObjects);

        foreach (Consumable consumable in consumables)
        {

            AdventureConsumableSlot adventureConsumableSlot = Instantiate(consumablesSlot, сonnectorConsumables).GetComponent<AdventureConsumableSlot>();
            сonnectorConsumablesObjects.Add(adventureConsumableSlot.gameObject);
            adventureConsumableSlot.Init(consumable, adventurePanel);
        }

    }

    public void СreateHeroSlot(int numberSlots)
    {
        if (heroSlots != null)
        {
           
            foreach(AdventureHeroSlot heroSlot in heroSlots)
            {
               
                Destroy(heroSlot.gameObject);
            }
        }


        heroSlots = new AdventureHeroSlot[numberSlots];
        for (int i=0;i< numberSlots; i++)
        {          
            AdventureHeroSlot adventureHeroSlot = Instantiate(heroSlot, сonnectorHeroSlots).GetComponent<AdventureHeroSlot>();
            heroSlots[i] = adventureHeroSlot;
            adventureHeroSlot.Init(defaultHeroSlot,i,adventurePanel);
        }
    }






}
