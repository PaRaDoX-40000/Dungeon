using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReportPanel : MonoBehaviour
{
    [SerializeField] private ReportPanelUI reportPanelUI;

    private List<ReportAdventure> reportAdventure = new List<ReportAdventure>();
    [SerializeField] private CommonHeir CommonHeir;
    private ReportAdventure targetReportAdventure= null;
    [SerializeField] public UnityEvent AddReport;





    public void AddReportAdventure(ReportAdventure report)
    {
        reportAdventure.Add(report);       
        AddReport?.Invoke();
        ShowHeroReportPanel();
    }

    void ShowHeroReportPanel()
    {
        reportPanelUI.ShowHeroReportPanel(reportAdventure);
    }
    private void OnEnable()
    {
        ShowHeroReportPanel();
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
            
            CommonHeir.dataBase.AddLoots(targetReportAdventure.Loots);
            CommonHeir.dataBase.AddConsumables(targetReportAdventure.NotUsedConsumable);
            CommonHeir.dataBase.AddHeros(targetReportAdventure.LiveHeroes);
            reportAdventure.Remove(targetReportAdventure);
            targetReportAdventure = null;
            reportPanelUI.OffReportDetailedPanel();
            ShowHeroReportPanel();
        }
        

    }
}
