using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
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

    public void GiveEntityRelic(Relic newRelic)
    {
        currentRelics.TryGetValue(newRelic, out int count);
        currentRelics[newRelic] = count + 1;
        Debug.LogFormat("You now have {0} {1}s", currentRelics[newRelic], newRelic.RelicName);

        ApplyRelicsToEntity();
    }

    private void ApplyRelicsToEntity()
    {
        foreach (Relic relic in currentRelics.Keys)
        {
            relic.ApplyRelicEffect(playerCurrentStats, currentRelics[relic]);
        }
    }

}
