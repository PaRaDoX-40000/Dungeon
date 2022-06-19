using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitHeroPanel : HeroPanel
{
    [SerializeField] private HeroesDetailedMenu detailedMenu;

    public override void ShoweDetailedHero()
    {
        detailedMenu.ShoweDetailedHero(hero);
    }
}
