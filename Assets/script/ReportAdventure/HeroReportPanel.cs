using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroReportPanel : MonoBehaviour
{
    [SerializeField] private Image[] iconHero;
    [SerializeField] private Image[] deadCross;
    [SerializeField] private TMP_Text[] nameHero;
    [SerializeField] private ReportAdventure reportAdventure;
    [SerializeField] private ReportPanel reportPanel;



    public void Init(List<Hero>liveHeroes, List<Hero> deadHeroes, ReportAdventure reportAdventure)
    {
        for(int i=0;i< liveHeroes.Count; i++)
        {
            iconHero[i].sprite = liveHeroes[i].Icon;
            deadCross[i].gameObject.SetActive(false);
            nameHero[i].text = liveHeroes[i].Name;
        }
        for (int i = liveHeroes.Count; i < liveHeroes.Count + deadHeroes.Count; i++)
        {
            iconHero[i].sprite = deadHeroes[i- liveHeroes.Count].Icon;
            deadCross[i].gameObject.SetActive(true);
            nameHero[i].text = deadHeroes[i - liveHeroes.Count].Name;
        }
        for (int i = liveHeroes.Count + deadHeroes.Count; i < iconHero.Length; i++)
        {
            iconHero[i].gameObject.SetActive(false);
            
        }
        this.reportAdventure = reportAdventure;

        gameObject.SetActive(true);

    }

    public void Show()
    {
        reportPanel.ShowReportDetailedPanel(reportAdventure);
    }


}
