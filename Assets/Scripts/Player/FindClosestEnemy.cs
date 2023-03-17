using System.Collections;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    private float overlapRadius = 1.0f;
    private Transform thisTransform;
    private Transform nearestEnemy;
    private int enemyLayer;
    private Transform lastTarget = null;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemies");
        thisTransform = GetComponent<Transform>();
        overlapRadius = GetComponentInParent<Stats>().AttackRange;
    }

    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(thisTransform.position, overlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;

        foreach (Collider2D collider in hitColliders)
        {
            float distance = (collider.transform.position - thisTransform.transform.position).sqrMagnitude;

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
