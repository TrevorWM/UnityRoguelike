using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    /*
    [SerializeField] private GameObject player;
    private Stats playerCurrentStats;

    private Dictionary<Relic, int> currentRelics = new Dictionary<Relic, int>();

    private void OnEnable()
    { 
        Relic.OnRelicCollected += Relic_OnRelicCollected;
        playerCurrentStats = player.GetComponent<Stats>();
    }
    private void OnDisable() => Relic.OnRelicCollected -= Relic_OnRelicCollected;

    private void Relic_OnRelicCollected(Relic relicType)
    {
        GiveEntityRelic(relicType);
    }

    private void GiveEntityRelic(Relic newRelic)
    {
        AddRelicToDictionary(newRelic);
        ApplyPassiveRelicsToEntity();
    }

    private void AddRelicToDictionary(Relic relicToAdd)
    {
        currentRelics.TryGetValue(relicToAdd, out int count);
        currentRelics[relicToAdd] = count + 1;
        Debug.LogFormat("You now have {0} {1}s", currentRelics[relicToAdd], relicToAdd.RelicName);
    }
    private void ApplyPassiveRelicsToEntity()
    {
        foreach (Relic relic in currentRelics.Keys)
        {
            if (relic.RelicEffectType == Relic.RelicEffectTypeEnum.Passive)
            {
                relic.ApplyRelicEffect(playerCurrentStats, currentRelics[relic]);
            }
            
        }
    }
    */
}
