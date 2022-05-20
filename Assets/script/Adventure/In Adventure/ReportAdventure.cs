using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReportAdventure
{
    [SerializeField] private List<Hero> deadHeroes = new List<Hero>();
    [SerializeField] private List<Hero> liveHeroes = new List<Hero>();
    [SerializeField] private List<Loot> loots = new List<Loot>();
    [SerializeField] private List<Consumable> notUsedConsumable = new List<Consumable>();

    [SerializeField] private List<ReportFight> reportFight = new List<ReportFight>();
    [SerializeField] private int maxDistance=0;
    [SerializeField] private Dungeon maxDungeon;

    public List<Hero> LiveHeroes => liveHeroes;
    public List<Hero> DeadHeroes => deadHeroes;

    public Dungeon MaxDungeon => maxDungeon;
    public int MaxDistance => maxDistance;

    public List<ReportFight> ReportFight  => reportFight;

    public List<Loot> Loots => loots;

    public List<Consumable> NotUsedConsumable => notUsedConsumable;

    public void AddReportFight(ReportFight reportFight, List<Hero> deadHeroes)
    {
        this.reportFight.Add(reportFight);

        if (deadHeroes.Count != 0)
        {
            this.deadHeroes.AddRange(deadHeroes);

        }
    }

    public void SetMaxDistance(int Distance, Dungeon dungeon)
    {

        if (MaxDistance == 0)
        {
            maxDistance = Distance;
            maxDungeon = dungeon;
        }
    }

    public void EndAdventureReport(List<Hero> heros, List<Loot> loots, List<Consumable> consumables)
    {
        liveHeroes.AddRange(heros);
        this.loots.AddRange(loots);
        notUsedConsumable.AddRange(consumables);
    }


}
    

