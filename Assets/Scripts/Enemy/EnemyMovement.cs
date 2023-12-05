using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float screenBorder;

    private Rigidbody2D rigidbody;
    private PlayerAwareness playerAwarenessController;
    private Vector2 targetDirection;
    private float directionCooldown;
    private Camera camera;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwareness>();
        targetDirection = transform.up;
        camera = Camera.main;
    }


    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        RandomDirectionChange();
        PlayerTargeting();
        EnemyOffScreen();
    }

    private void RandomDirectionChange()
    {
        directionCooldown -= Time.deltaTime;
        if(directionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            directionCooldown = Random.Range(1f, 5f);
        }
    }

    private void PlayerTargeting()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
    }

    private void EnemyOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && targetDirection.x < 0) ||
            (screenPosition.x > camera.pixelWidth - screenBorder && targetDirection.x > 0))
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }

        if ((screenPosition.y < screenBorder && targetDirection.y < 0) ||
            (screenPosition.y > camera.pixelHeight - screenBorder && targetDirection.y > 0))
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        rigidbody.velocity = transform.up * speed;
    }
}
