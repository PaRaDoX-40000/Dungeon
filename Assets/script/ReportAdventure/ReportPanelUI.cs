using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReportPanelUI : MonoBehaviour
{
    [SerializeField] private HeroReportPanel[] heroReportPanels;
    [SerializeField] private ReportDetailedPanel detailedPanel;

    public void ShowReportDetailedPanel(ReportAdventure reportAdventure)
    {
        detailedPanel.Init(reportAdventure);
    }


    public void ShowHeroReportPanel(List<ReportAdventure> reportAdventures)
    {
       
        for(int i = 0;i<reportAdventures.Count;i++)
        {
            heroReportPanels[i].Init(reportAdventures[i].LiveHeroes, reportAdventures[i].DeadHeroes, reportAdventures[i]);
            heroReportPanels[i].gameObject.SetActive(true);
        }
        for (int i = reportAdventures.Count; i < heroReportPanels.Length; i++)
        {
            heroReportPanels[i].gameObject.SetActive(false);
        }
    }

    internal void OffReportDetailedPanel()
    {
        detailedPanel.gameObject.SetActive(false);
    }
}
