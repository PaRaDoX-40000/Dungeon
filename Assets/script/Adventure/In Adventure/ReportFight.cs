using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReportFight 
{
    private List<Sprite> iconHero = new List<Sprite>();
    private List<int> healthHero = new List<int>();
    private List<int> maxHealthHero = new List<int>();
    private List<string> nameHero = new List<string>();

    private List<Sprite> iconEnemies = new List<Sprite>();
    private List<int> numberEnemies = new List<int>();
    private List<string> nameEnemies = new List<string>();
    private bool win;


    public List<Sprite> IconHero => iconHero;
    public List<int> HealthHero => healthHero;
    public List<int> MaxHealthHero => maxHealthHero;
    public List<string> NameHero => nameHero;

    public List<Sprite> IconEnemies => iconEnemies;
    public List<int> NumberEnemies => numberEnemies;
    public List<string> NameEnemies => nameEnemies;

    public bool Win => win; 

    public ReportFight(List<Hero> heroes,List <Enemy> enemies,bool win) 
    {
        foreach(Hero hero in heroes)
        {
            iconHero.Add(hero.Icon);
            healthHero.Add(hero.Stats[0]);
            maxHealthHero.Add(hero.Stats[1]);
            nameHero.Add(hero.Name);
        }
        this.win = win;

        foreach (Enemy enemy in enemies)
        {
            Debug.Log("до бага");
            if (NameEnemies.Contains(enemy.name))
            {
                NumberEnemies[NameEnemies.IndexOf(enemy.name)]++;
            }
            else
            {
                NameEnemies.Add(enemy.name);
                NumberEnemies.Add(1);
                iconEnemies.Add(enemy.Icon);
            }
            Debug.Log("после");
        }
    }
}
