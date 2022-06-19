using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Adventure : MonoBehaviour
{
    [SerializeField] private List<Hero> heroes = new List<Hero>();
    [SerializeField] private List<Consumable> consumables = new List<Consumable>(); 
    [SerializeField] private List<Loot> loots = new List<Loot>();
    List<Enemy> enemies = new List<Enemy>();

    private bool retreat = false;
    public bool Retreat => retreat;

    private ReportAdventure reportAdventure = new ReportAdventure();
    public ReportAdventure ReportAdventure => reportAdventure;

    public List<Hero> Heroes => heroes;

    public List<Consumable> Consumables => consumables;

    [SerializeField] DungeonCollection dungeonCollection;

    [SerializeField] private Dungeon activeDungeon;
    private int indexDungeon = 0;

    [SerializeField] private int speed=1;
    private float chanceFind=1;

    private float distanceTraveled;

    private float lootTime;
    private float faindLootTime=5;

    private float enemyTime;
    private float faindEnemyTime=10;

    [SerializeField] private Fight fight;

    [SerializeField] private DataBase dataBase;
    [SerializeField] private ReportPanel reportPanel;

   public UnityAction<Loot, Adventure> FaindLootEvent;
    public UnityAction<Adventure> TryFaindLootEvent;
    public UnityAction<Adventure> FaindEnemyEvent;
    public UnityAction<Adventure> TryFaindEnemyEvent;

    

    private void Start()
    {
        retreat = false;
    }


    

    private void Update()
    {

        Study();
        if (lootTime > faindLootTime)
        {
            FaindLoot();
            lootTime = 0;
           
        }
           
        if (enemyTime > faindEnemyTime)
        {
            СhanceMeetEnemy();
            enemyTime = 0;
        }
        TryDungeonCrossing();




    }

    void Study()
    {
        if (retreat == false)
        {
            distanceTraveled += Time.deltaTime * (float)speed;
        }
        else
        {
            distanceTraveled -= Time.deltaTime * (float)speed;
        }

       
        lootTime += Time.deltaTime * (float)speed;
        enemyTime += Time.deltaTime * (float)speed;
    }

    void TryDungeonCrossing()
    {
        if (retreat == false)
        {
            if (distanceTraveled >= activeDungeon.Lenght)
            {
                if(indexDungeon+1< dungeonCollection.Dungeons.Count)
                {
                    //DungeonCrossing();
                    indexDungeon++;
                    activeDungeon = dungeonCollection.Dungeons[indexDungeon];
                    distanceTraveled = 0;
                }
                else
                {
                    StartRetreat();
                }             
            }
        }
        else
        {
            if (distanceTraveled <= 0)
            {
                if (indexDungeon - 1 >= 0)
                {
                    indexDungeon--;
                    activeDungeon = dungeonCollection.Dungeons[indexDungeon];
                    distanceTraveled = activeDungeon.Lenght;

                }
                else
                {
                    EndAdventure();
                }
            }
        }
    }

    void FaindLoot()
    {
        foreach(RarityLoot rarityLoot in activeDungeon.RarityLoot)
        {
            if(TryFaindLootEvent!=null)
                TryFaindLootEvent.Invoke(this);
            float chance = Random.Range(0f, 1f);
            if(chance* chanceFind> 1 - rarityLoot.Rarity)
            {
                loots.Add(rarityLoot.Loot);
                if (FaindLootEvent != null)
                    FaindLootEvent.Invoke(rarityLoot.Loot, this);
            }           
        }      
    }

    void СhanceMeetEnemy()
    {
        if (TryFaindEnemyEvent != null)
            TryFaindEnemyEvent.Invoke(this);
        float chance = Random.Range(0f, 1f);
        if (chance > 1 - 0.5)
        {
            if (FaindEnemyEvent != null)
                FaindEnemyEvent(this);
            MetEnemy();        
        }           
    }
    
    void MetEnemy()
    {
        GroupEnemies groupEnemies = activeDungeon.GroupEnemies[Random.Range(0, activeDungeon.GroupEnemies.Count)];
        int number = Random.Range(1, groupEnemies.MaxGrup);
        
        for(int i=0;i< number; i++)
        {
            Enemy enemie = Instantiate(groupEnemies.Enemy, transform);
            enemie.name = groupEnemies.Enemy.name;
            enemies.Add(enemie);
        }
        fight.TryStartFight(heroes, enemies);
        ChangeState();
    }

    public void ChangeState()
    {
        
        
            this.enabled = !this.enabled;
            //fight.enabled = !fight.enabled;
        
       
    }
    public void DeliteEnemies()
    {
        if (enemies != null)
        {
            while (enemies.Count != 0)
            {
                Destroy(enemies[0].gameObject);
                enemies.Remove(enemies[0]);
            }
        }
    }


    public void AddLootEnemy(List<Loot> enemyLoot)
    {
        loots.AddRange(enemyLoot);
    }

    public void AddSurvivorsHero(List<Hero> survivorsHero)
    {
        heroes.Clear();
        heroes.AddRange(survivorsHero);
    }

    public void StartRetreat()
    {
        if (retreat==false)
        {
            retreat = true;
            reportAdventure.SetMaxDistance((int)distanceTraveled, activeDungeon);
            Debug.Log("отступают");
        }
    }

    void DungeonCrossing()
    {
        //activeDungeon = dungeonCollection.Dungeons[indexDungeon++];
    }
    void EndAdventure()
    {
        Debug.Log("вернулись");
       
        
        foreach(Hero hero in heroes)
        {
            hero.Stats[0] = hero.Stats[1];
        }
        reportAdventure.EndAdventureReport(heroes, loots, consumables);
        //commonHeir.dataBase.reportAdventure.Add(reportAdventure);
        reportPanel.AddReportAdventure(reportAdventure);

        
        dataBase.adventure.Remove(this);
        Destroy(this.gameObject);
    }


    public void Init(Hero[]heroes,List<Consumable>consumables, DataBase dataBase,ReportPanel reportPanel, List<HeroPeculiarity> HeroPeculiarities)
    {
       foreach(Hero hero in heroes)
        {
            if(hero!=null)
            this.heroes.Add(hero);
        }


        this.reportPanel = reportPanel;
        this.consumables.AddRange(consumables);
        
        this.dataBase = dataBase;
        int minSpeed = this.heroes[0].Stats[3];
        foreach (Hero hero in this.heroes)
        {
            if(hero.Stats[3]< minSpeed)
            {
                minSpeed = hero.Stats[3];
            }
        }
        speed = minSpeed;
        activeDungeon = dungeonCollection.Dungeons[0];
        foreach (HeroPeculiarity peculiarities in HeroPeculiarities)
        {
            peculiarities.Peculiarity.Distribution.Subscribe(fight, this, peculiarities.Hero, peculiarities);

        }
    }
    
    public void RemoveConsumable(Consumable consumable)
    {
        Consumables.Remove(consumable);
    }

}
