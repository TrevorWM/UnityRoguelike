using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO baseStats;
    [SerializeField] private Stats currentStats;

    private Dictionary<Relic, int> currentRelics = new Dictionary<Relic, int>();

    public void GiveRelicToPlayer(Relic newRelic)
    {
        currentRelics.TryGetValue(newRelic, out int count);
        currentRelics[newRelic] = count;
    }

}
