using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level 
{
    List<int> stats;
    private int number;
    private int experiencePoints=0;
    private int necessaryExperiencePoints=100;
    //private int[] heroStats; 

    public int Number => number; 

    public  Level(int[] stats)
    {
        this.stats = new List<int>(stats);
        

        number = 1;
    }


    //0.Здоровье
    //1.Макс здорове
    //2.Урон
    //3.Скорость 
    //4.Защитаa
    //5.Коэффициент провокации
    //6.Скорость атаки
    //7.Храбрость
    //8.Заметность
    void LevelApp(ref int[] heroStats, Hero hero)
    {
        number++;
        heroStats[1] = stats[1] + 10 * number;
        heroStats[0] = heroStats[1];
        heroStats[2] = stats[2] + 1 * number;
        heroStats[3] = stats[3] + (int)(0.4f * number);
        heroStats[4] = stats[4];
        heroStats[5] = stats[5] + (int)(0.2f * number);
        heroStats[6] = stats[6] + (int)(0.1f * number);
        heroStats[7] = stats[7];
        heroStats[8] = stats[8];
        experiencePoints = experiencePoints- necessaryExperiencePoints;
        necessaryExperiencePoints += 100;

        Debug.Log(stats[1]);
        foreach (Equipable equipable in hero.Equipment.Where(equipment => equipment != null))
        {
            foreach(StatsApp statsApp in equipable.StatsApp.Where(stats => stats!=null))
            {
                heroStats[(int)statsApp.Stat] += statsApp.Value;
            }
        }
    }

    public void AddExperiencePoints(int amount,Hero hero, ref int[] heroStats)
    {
        experiencePoints += amount;
        while (experiencePoints > necessaryExperiencePoints)
        {
            LevelApp(ref heroStats, hero);
        }
        
        
       
         
    }
}
