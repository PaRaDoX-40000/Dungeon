using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportFightPanel : MonoBehaviour
{
    [SerializeField] List<CharacterPanel> characterPanelHero = new List<CharacterPanel>();
    [SerializeField] List<CharacterPanel> characterPanelEnemy = new List<CharacterPanel>();
    [SerializeField] GameObject retreatImage;
    [SerializeField] GameObject winImage;

    public void Init(ReportFight reportFight)
    {
        for(int i = 0; i < reportFight.NameHero.Count; i++)
        {
            characterPanelHero[i].Init(reportFight.NameHero[i], reportFight.IconHero[i], reportFight.HealthHero[i] + "/" + reportFight.MaxHealthHero[i]);
            characterPanelHero[i].gameObject.SetActive(true);
        }
        for (int i = reportFight.NameHero.Count; i < characterPanelHero.Count; i++)
        {
            characterPanelHero[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < reportFight.NameEnemies.Count; i++)
        {
            characterPanelEnemy[i].Init(reportFight.NameEnemies[i], reportFight.IconEnemies[i], "X"+reportFight.NumberEnemies[i]);
            characterPanelEnemy[i].gameObject.SetActive(true);
        }
        for (int i = reportFight.NameEnemies.Count; i < characterPanelEnemy.Count; i++)
        {
            characterPanelEnemy[i].gameObject.SetActive(false);
        }
        if (reportFight.Win == true)
        {
            winImage.SetActive(true);
            retreatImage.SetActive(false);
        }
        else
        {
            winImage.SetActive(false);
            retreatImage.SetActive(true);
        }

        gameObject.SetActive(true);

    }
}
