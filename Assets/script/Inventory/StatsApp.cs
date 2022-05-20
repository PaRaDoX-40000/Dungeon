using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsApp
{
    public enum Stats
    {
        //0.Здоровье
        //1.Макс здорове
        //2.Урон
        //3.Скорость
        //4.Защита
        //5.Коэффициент провокации
        //6.Скорость атаки
        //7.Храбрость
        //8.Заметность
        HP = 0,
        MaxHP = 1,
        Damage = 2,
        Speed = 3,
        Armore = 4,
        ProvocationCoefficient = 5,
        AttackSpeed = 6,
        Bravery = 7,
        Visibility = 8
    }

    private Stats stats;
    private int value;

    public Stats Stat=> stats;
    public int Value { get => value; set => this.value = value; }

    public StatsApp(StatsApp statsAp)
    {
        stats = statsAp.Stat;
        value = statsAp.Value;
    }
}
