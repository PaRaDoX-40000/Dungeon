using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroPeculiarity
{
    private Hero hero;
    private Peculiarity peculiarity;

    public Hero Hero => hero;
    public Peculiarity Peculiarity => peculiarity;

    public HeroPeculiarity(Hero hero, Peculiarity peculiarity)
    {
        this.hero = hero;
        this.peculiarity = peculiarity;
    }
}
