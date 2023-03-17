using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositionHelper : MonoBehaviour
{
    [SerializeField] Transform shootPosTransform;
    [SerializeField] FindClosestEnemy autoAimScript;
    private Vector2 lookDirection;
    public bool autoAimOn;

    void Update()
    {
        CalculateShootDirection();
    }

    public Vector3 GetShootPosition()
    {
        return shootPosTransform.position;
    }

    public Vector2 GetShootDirection()
    {
        return this.lookDirection;
    }

    public Quaternion GetShootRotation()
    {
        return shootPosTransform.rotation;
    }

    private void CalculateShootDirection()
    {
        Vector2 currentPosition = new Vector2(shootPosTransform.position.x, shootPosTransform.position.y);

        if (autoAimOn)
        {
            Transform enemyTransform = autoAimScript.GetEnemyTransform();
            
            if (enemyTransform != null)
            {
                Vector2 enemyPosition = new Vector2(enemyTransform.position.x, enemyTransform.position.y);
                lookDirection = (enemyPosition - currentPosition).normalized;
            }
            
        }
        else
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookDirection = (mousePosition - currentPosition).normalized;
        }


        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        shootPosTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
