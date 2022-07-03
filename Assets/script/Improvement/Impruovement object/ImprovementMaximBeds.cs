using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaximBeds", menuName = "Improvement/MaximBeds", order = 51)]
public class ImprovementMaximBeds : Improvement
{
    [SerializeField] private int maximBedsDefault = 5;
    [SerializeField] private int bedsPerLevel=2;
    private int maximBeds;

    public int MaximBeds => maximBeds;

    public override void levelUp()
    {
        level++;
        maximBeds = maximBedsDefault + level * bedsPerLevel;
    }
}
