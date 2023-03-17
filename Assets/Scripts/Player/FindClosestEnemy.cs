using System.Collections;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    public Transform player;
    public float overlapRadius = 10.0f;

    private Transform nearestEnemy;
    private int enemyLayer;
    private Transform lastTarget = null;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemies");
        Debug.Log(enemyLayer);
        overlapRadius = player.GetComponent<Stats>().AttackRange;
    }

    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.position, overlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;

        foreach (Collider2D collider in hitColliders)
        {
            //float distance = Vector3.Distance(Player.position, collider.transform.position);
            float distance = (collider.transform.position - player.transform.position).sqrMagnitude;

            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
        
        if (nearestEnemy != null && nearestEnemy != lastTarget)
        {
            Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + minimumDistance);
            lastTarget = nearestEnemy;
        }
        
        
    }

    public Transform GetEnemyTransform()
    {
        return nearestEnemy;
    }
}
