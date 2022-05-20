using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementPanel : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Button buttonCraft;
    //public Transform conector;
    [SerializeField] private Text goldText;
    [SerializeField] private Improvement improvement;
    [SerializeField] private PictureWithText[] lootPanel;


    public void Init(Improvement improvement, CommonHeir commonHeir)
    {
        titleText.text = improvement.Title;
        descriptionText.text = improvement.Description;
        buttonCraft.interactable = improvement.CanBeImproved(commonHeir);
        goldText.text = improvement.Gold.ToString();
        this.improvement = improvement;
        
        for(int i =0;i< improvement.Resources.Length;i++)
        {
            lootPanel[i].Init(improvement.Resources[i].Loot.Icon, "X" + improvement.Resources[i].Number);
        }
        for(int i = improvement.Resources.Length; i < lootPanel.Length; i++)
        {
            lootPanel[i].gameObject.SetActive(false);
        }
        improvement.commonHeir = commonHeir;
        gameObject.SetActive(true);
    }


    public void ClikImprovementButto()
    {
        improvement.levelUp();
    }



}

