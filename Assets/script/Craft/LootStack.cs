using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootStack
{
    public Loot loot;
    public int num;

    public LootStack(Loot _loot, int _num)
    {
        loot = _loot;
        num = _num;
    }
}
