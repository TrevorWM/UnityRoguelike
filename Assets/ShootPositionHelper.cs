using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositionHelper : MonoBehaviour
{
    [SerializeField] Transform shootPosTransform;
    private Vector2 lookDirection;

    void Update()
    {
        Vector2 currentPosition = new Vector2(shootPosTransform.position.x, shootPosTransform.position.y);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = (mousePosition - currentPosition).normalized;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        shootPosTransform.rotation = Quaternion.Euler(0, 0, angle);
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
}
