using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Stats playerStats;
    

    private Dictionary<RelicSO, int> currentRelics = new Dictionary<RelicSO, int>();

    private void OnEnable()
    {
        Relic.OnRelicCollected += Relic_OnRelicCollected;
        playerStats = player.GetComponent<Stats>();
    }
    private void OnDisable()
    {
        Relic.OnRelicCollected -= Relic_OnRelicCollected;
    }

    private void Relic_OnRelicCollected(RelicSO relic)
    {
        GiveEntityRelic(relic);
    }

    private void GiveEntityRelic(RelicSO newRelic)
    {
        AddRelicToDictionary(newRelic);
        ApplyPassiveRelicsToEntity();
    }

    private void AddRelicToDictionary(RelicSO relicToAdd)
    {
        currentRelics.TryGetValue(relicToAdd, out int count);
        currentRelics[relicToAdd] = count + 1;
        Debug.LogFormat("You now have {0} {1}s", currentRelics[relicToAdd], relicToAdd.RelicName);
    }
    private void ApplyPassiveRelicsToEntity()
    {
        foreach (RelicSO relic in currentRelics.Keys)
        {
            if (relic.EffectType == RelicSO.RelicEffectType.Passive)
            {
                relic.ApplyRelicEffect(playerStats, currentRelics[relic]);
            }

        }
    }
}
