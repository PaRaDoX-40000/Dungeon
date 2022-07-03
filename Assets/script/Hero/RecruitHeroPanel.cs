using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitHeroPanel : HeroPanel
{
    [SerializeField] private RecruitingHeroes recruitingHeroes;

    public override void ShoweDetailedHero()
    {
        recruitingHeroes.ShoweDetailedHero(hero);
    }
}
