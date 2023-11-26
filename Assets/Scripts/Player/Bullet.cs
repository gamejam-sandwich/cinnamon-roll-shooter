using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController hc = collision.GetComponent<HealthController>();
            hc.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if(screenPosition.x < 0 ||
            screenPosition.x > camera.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
