using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportDetailedPanel : MonoBehaviour
{
    [SerializeField] private SimpleHeroPanel[] heroPanel;
    [SerializeField] private TMP_Text dungeonNameText;
    [SerializeField] private TMP_Text maxDistanceText;
    [SerializeField] private PictureWithText[] lootPanels;
    [SerializeField] private ReportFightPanel[] reportFightPanels;

    public void Init(ReportAdventure reportAdventure)
    {
        ShowHero(reportAdventure.LiveHeroes, reportAdventure.DeadHeroes);
        dungeonNameText.text = reportAdventure.MaxDungeon.name;
        maxDistanceText.text = reportAdventure.MaxDistance.ToString();
        ShowReportLoot(reportAdventure.Loots);
        ShowReportFight(reportAdventure.ReportFight);

        gameObject.SetActive(true);
    }

    private void ShowHero(List<Hero> LiveHeroes,List<Hero> DeadHeroes)
    {
        for (int i = 0; i < LiveHeroes.Count; i++)
        {
            heroPanel[i].Init(LiveHeroes[i].Icon, LiveHeroes[i].Name, true);
        }
        for (int i = LiveHeroes.Count; i < DeadHeroes.Count+ LiveHeroes.Count; i++)
        {
            int deadIndex = i - LiveHeroes.Count;
            heroPanel[i].Init(DeadHeroes[deadIndex].Icon, DeadHeroes[deadIndex].Name, false);
        }
        for (int i = LiveHeroes.Count + DeadHeroes.Count; i < heroPanel.Length; i++)
        {

            heroPanel[i].gameObject.SetActive(false);
        }
    }
    private void ShowReportFight(List<ReportFight> reportFights)
    {
        for (int i = 0; i < reportFights.Count; i++)
        {
            reportFightPanels[i].Init(reportFights[i]);
        }
        for (int i = reportFights.Count; i < reportFightPanels.Length; i++)
        {
            reportFightPanels[i].gameObject.SetActive(false);
        }

    }
    private void ShowReportLoot(List<Loot> loots)
    {
        Dictionary<Loot, int> lootsValues = new Dictionary<Loot, int>();
        foreach(Loot loot in loots)
        {
            if (lootsValues.ContainsKey(loot))
            {
                lootsValues[loot]++;
            }
            else
            {
                lootsValues.Add(loot, 1);
            }
        }
        Dictionary<Loot, int>.KeyCollection lootsKey = lootsValues.Keys;
        int i = 0;
        foreach(Loot loot in lootsKey)
        {
            lootPanels[i].Init(loot.Icon, "x"+lootsValues[loot]);
            i++;
        }
        while(i< lootPanels.Length)
        {
            lootPanels[i].gameObject.SetActive(false);
            i++;
        }
       
    }

}
