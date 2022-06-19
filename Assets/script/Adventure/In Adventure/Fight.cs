using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fight : MonoBehaviour
{
    [SerializeField] private List<Hero> heroes= new List<Hero>();
    [SerializeField] private ConsumableHealing[] consumableHealing;
    private List<Enemy> enemies= new List<Enemy>();
    private List<Coroutine> heroesCoroutine= new List<Coroutine>();
    private List<Coroutine> enemiesCoroutine = new List<Coroutine>();
    private Coroutine didEveryoneRunAway;
    private Enemy targetEnemie;
    [SerializeField] private Adventure adventure;
    private bool everyoneRanAway = false;

    public UnityAction<Enemy, Hero, Fight, Adventure> BeforeTakingDamage;
    public UnityAction<Enemy, Hero, Fight, Adventure> AfterTakingDamage;

    public UnityAction<Enemy, Hero, Fight, Adventure> BeforeDamage;
    public UnityAction<Enemy, Hero, Fight, Adventure> AfterDamage;

    public UnityAction<Enemy, Hero, Fight, Adventure> HeroDied;
    public UnityAction<Enemy, Hero, Fight, Adventure> EnemyDied;


    public UnityAction<int, Hero, Fight> GetHealing;
  
    public List<Hero> Heroes => heroes; 

    public void TryStartFight(List<Hero> playerParty, List<Enemy> oppositeParty)
    {
        Debug.Log("попробовать бится");
        int generalSecrecy = 0;
        foreach (Hero hero in playerParty)
        {
            generalSecrecy += hero.Stats[8];
        }
        generalSecrecy = generalSecrecy / playerParty.Count;
 
        float heroChance = Random.Range(1, 10);
        float enemieChance = Random.Range(1, 10);
        if (heroChance + generalSecrecy > enemieChance + oppositeParty[0].Stats[5])
        {
            Debug.Log("не заметили");
            if (adventure.Retreat == true)
            {
                DidNotFight();
            }
            else
            {
                if(TryFight(playerParty, oppositeParty))
                {
                    Debug.Log("атака из засады");
                    foreach (Enemy enemy in oppositeParty)
                    {
                        enemy.GetDamage((int)(enemy.Stats[1] * 0.15));
                    }
                    StartFight(playerParty, oppositeParty);
                }
                else
                {
                    DidNotFight();
                }
            }
        }
        else
        {
            Debug.Log("заметели");
            StartFight(playerParty, oppositeParty);
        }


    }

    private void StartFight(List<Hero> playerParty, List<Enemy> oppositeParty)
    {


        foreach (Hero hero in playerParty)
        {
            Heroes.Add(hero);
            Coroutine coroutine = StartCoroutine(HeroDoHit(hero));
            heroesCoroutine.Add(coroutine);
        }
        foreach (Enemy enemy in oppositeParty)
        {
            enemies.Add(enemy);
            enemiesCoroutine.Add(StartCoroutine(EnemyDoHit(enemy)));
        }
        didEveryoneRunAway = StartCoroutine(DidEveryoneRunAway());
        targetEnemie = enemies[0];
    }

    private IEnumerator DidEveryoneRunAway()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            everyoneRanAway = true;
            foreach (Hero _hero in Heroes)
            {
                if (_hero.retreated == false && _hero.Dead == false)
                {
                    everyoneRanAway = false;
                }
            }
            if (everyoneRanAway)
            {
                Debug.Log("все сбежали");
                RetreatEndFight();
            }
        }
    }
   
    private IEnumerator HeroDoHit(Hero hero)
    {    
        while (hero.Dead==false && hero.retreated== false)
        {       
            yield return new WaitForSeconds((100f / (float)(hero.Stats[6])));
            if (hero.Stats[0] < hero.Stats[1] / 2)
            {
                foreach (ConsumableHealing consumableHealing in consumableHealing)
                {
                    if (adventure.Consumables.Contains(consumableHealing))
                    {
                        hero.Heal(consumableHealing.AmountHealing);
                        adventure.RemoveConsumable(consumableHealing);
                        break;
                    }
                }                  
            }
            if(hero.statusEffectСontainer != null)
            if (hero.statusEffectСontainer.Count != 0)
            {
                List<StatusEffectСontainer> statuses = new List<StatusEffectСontainer>();
                foreach(StatusEffectСontainer statusEffectСontainer in hero.statusEffectСontainer)
                {
                    if (adventure.Consumables.Contains(statusEffectСontainer.StatusEffect.MedicineConsumable))
                    {
                        statuses.Add(statusEffectСontainer);
                        adventure.RemoveConsumable(statusEffectСontainer.StatusEffect.MedicineConsumable);
                    }
                }
                if (statuses.Count > 0)
                {
                    foreach (StatusEffectСontainer statusEffectСontainer in statuses)
                    {
                        Debug.Log("Снят " + statusEffectСontainer.StatusEffect.name);
                        
                        StopCoroutine(statusEffectСontainer.CoroutineEffect);
                        statusEffectСontainer.ForceRemoveStatus(hero);
                    }
                }
            }
            hero.DoHit(targetEnemie,this,adventure);
            Debug.Log("удар героя по " + targetEnemie.name + " здороая осталась " + targetEnemie.Stats[0]);
            if (targetEnemie.Dead == true)
            {
                foreach(Enemy enemy in enemies)
                {
                    if (enemy.Dead == false)
                    {
                        targetEnemie = enemy;
                        break;
                    }
                }
                if(targetEnemie.Dead == true)
                {
                    VictoryEndFight();
                    break;
                }
            }
            if (TryFight(Heroes, enemies) == false)
            {                             
                hero.TryRetreat(targetEnemie);               
            }
        }
    }
   
    private IEnumerator EnemyDoHit(Enemy enemy)
    {
        while (enemy.Dead == false)
        {
            yield return new WaitForSeconds((100f / (float)enemy.Stats[4]));            
            Hero targethero = FindTargetHero();
            if (targethero != null)
            {
                enemy.DoHit(targethero, this, adventure);
                if (enemy.StatusEffectСhance.StatusEffect != null)
                {
                    int chance = Random.Range(0, 100);
                    if (chance <= enemy.StatusEffectСhance.Сhance)
                    {
                        StatusEffectСontainer statusEffectСontainer = new StatusEffectСontainer(enemy.StatusEffectСhance.StatusEffect);
                        Coroutine coroutine = StartCoroutine(enemy.StatusEffectСhance.StatusEffect.EffctCoroutine(targethero, statusEffectСontainer));
                        statusEffectСontainer.SetCoroutine(coroutine);
                        targethero.statusEffectСontainer.Add(statusEffectСontainer);
                    }
                }
            }   
            if (Heroes.Count != 0)
            {
                bool everyoneDead = true;
                foreach (Hero hero in Heroes)
                {
                    if (hero.Dead == false)
                    {
                        everyoneDead = false;
                    }
                }
                if (everyoneDead)
                {
                    DefeatEndFight();
                    break;
                }
            }
        }
    }

    private Hero FindTargetHero()
    {
        Hero heroMaxChance=null;
        int maxChance=0;

        foreach (Hero hero in Heroes)
        {
            if (hero.Dead ==false && hero.retreated==false)
            {
                int chance = Random.Range(0, 100);
                if (maxChance < chance + hero.Stats[5])
                {
                    maxChance = chance + hero.Stats[5];
                    heroMaxChance = hero;
                }
            }
        }
        return heroMaxChance;
        
    }

    private void VictoryEndFight()
    {
        Debug.Log("победа");
        List<Loot> enemyLoot = new List<Loot>();
        foreach (Enemy enemy in enemies)
        {
            foreach(RarityLoot rarityLoot in enemy.RarityLoots)
            {
                float chance = Random.Range(0f, 1f);
                if (chance > 1 - rarityLoot.Rarity)
                {
                    enemyLoot.Add(rarityLoot.Loot);
                }
            }
        }
        adventure.AddLootEnemy(enemyLoot);
        ReturnSurvivingHeroes();
        ClearFight();    
    }

    private void DefeatEndFight()
    {
        Debug.Log("все мерты");
        ClearFight();
        Destroy(this.gameObject);
    }

    private void RetreatEndFight()
    {  
        adventure.StartRetreat();
        ReturnSurvivingHeroes(); 
        ClearFight();
    }

    
    private void DidNotFight()
    {
        Debug.Log("не сражались");
        adventure.StartRetreat();
        ClearFight();
    }

    private void ClearFight()
    {



        if (didEveryoneRunAway != null)
            StopCoroutine(didEveryoneRunAway);
        if (heroesCoroutine != null)
            foreach (Coroutine hero in heroesCoroutine)
            {
                StopCoroutine(hero);
            }
        
        if (enemiesCoroutine != null)
            foreach (Coroutine enemy in enemiesCoroutine)
            {
                StopCoroutine(enemy);
            }
        if (Heroes != null)
            foreach (Hero hero in Heroes)
            {
                hero.retreated = false;
            }

        Heroes.Clear();
        enemies.Clear();
        heroesCoroutine.Clear();
        enemiesCoroutine.Clear();
        targetEnemie = null;
        adventure.ChangeState();
        adventure.DeliteEnemies();
       
        if (didEveryoneRunAway != null)
            StopCoroutine(didEveryoneRunAway);
        
    }

    private bool TryFight(List<Hero> heroes, List<Enemy> enemies)
    {
        int generalCourage = 0;
        int generalHealthierHeroes = 0;
        int generalHealthierEnemies = 0;
        foreach (Hero hero in heroes)
        {
            generalCourage += hero.Stats[7];
            generalHealthierHeroes += hero.Stats[0];
        }
        generalCourage /= heroes.Count;
        generalCourage /= 100;

        foreach (Enemy enemie in enemies)
        {
            generalHealthierEnemies += enemie.Stats[0];
        }
        return generalHealthierEnemies < generalHealthierHeroes * generalCourage;

    }
 
    private void ReturnSurvivingHeroes()
    {
        

        List<Hero> deadHero=new List<Hero>();
        foreach (Hero hero in Heroes)
        {
            
            if (hero.Dead == true)
            {
               
                deadHero.Add(hero);
            }
            if(hero.statusEffectСontainer != null)
            if (hero.statusEffectСontainer.Count > 0)
            {
                while(hero.statusEffectСontainer.Count == 0)
                {
                    StopCoroutine(hero.statusEffectСontainer[hero.statusEffectСontainer.Count-1].CoroutineEffect);
                    hero.statusEffectСontainer[hero.statusEffectСontainer.Count].ForceRemoveStatus(hero);
                }
                
            }
            
               
        }
        
        adventure.ReportAdventure.AddReportFight(new ReportFight(Heroes, enemies, !everyoneRanAway), deadHero);
      
                                
        foreach (Hero hero in deadHero)
        {
            //foreach(HeroPeculiarity heroPeculiarity in hero.HeroPeculiarities)
            //{
            //    Debug.Log("проблема здесь");
            //    heroPeculiarity.Peculiarity.Distribution.Unsubscribe(this, adventure, hero, heroPeculiarity);//&&&&&???????????????
            //}
            Heroes.Remove(hero);

        }
       



        adventure.AddSurvivorsHero(Heroes);
      
    }

    public void Init(Adventure adventure)
    {
        this.adventure = adventure;
    }

}
