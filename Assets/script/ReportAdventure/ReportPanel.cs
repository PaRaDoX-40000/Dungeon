using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReportPanel : MonoBehaviour
{
    [SerializeField] private ReportPanelUI reportPanelUI;

    [SerializeField] private List<ReportAdventure> reportAdventure = new List<ReportAdventure>();
    [SerializeField] private DataBase dataBase;
    private ReportAdventure targetReportAdventure= null;
    [SerializeField] public UnityEvent AddReport;





    public void AddReportAdventure(ReportAdventure report)
    {
        reportAdventure.Add(report);       
        AddReport?.Invoke();
        ShowReport();
    }

    void ShowReport()
    {
        reportPanelUI.ShowReport(reportAdventure);
    }
    private void OnEnable()
    {
        ShowReport();
    }
    public void ShowReportDetailedPanel(ReportAdventure reportAdventure)
    {
        reportPanelUI.ShowReportDetailedPanel(reportAdventure);
        targetReportAdventure = reportAdventure;
    }
    public void Collect()
    {
        if (targetReportAdventure != null)
        {
            
            dataBase.AddLoots(targetReportAdventure.Loots);
            dataBase.AddConsumables(targetReportAdventure.NotUsedConsumable);
            dataBase.AddHeros(targetReportAdventure.LiveHeroes);
            reportAdventure.Remove(targetReportAdventure);
            targetReportAdventure = null;
            reportPanelUI.OffReportDetailedPanel();
            ShowReport();
        }      
    }
}
