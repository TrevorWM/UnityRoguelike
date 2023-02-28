using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicSOManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Stats playerStats;
    

    private Dictionary<RelicSO, int> currentRelics = new Dictionary<RelicSO, int>();

    private void OnEnable()
    {
        RelicSO.OnRelicSOCollected += RelicSO_OnRelicSOCollected;
        playerStats = player.GetComponent<Stats>();
    }
    private void OnDisable() => RelicSO.OnRelicSOCollected -= RelicSO_OnRelicSOCollected;

    private void RelicSO_OnRelicSOCollected(RelicSO relicType)
    {
        GiveEntityRelic(relicType);
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
