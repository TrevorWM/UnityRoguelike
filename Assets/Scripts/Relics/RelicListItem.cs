using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RelicListItem
{
    public Relic relic;
    public string relicName;
    public int relicStacks;

    public RelicListItem(Relic newRelic)
    {
        relic = newRelic;
        relicName = newRelic.RelicName;
    }
}
