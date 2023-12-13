using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    
    [SerializeField]
    public float bulletSpeed;

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    public float timeBetweenShots;

    [SerializeField]
    AudioManager audio;

    private bool fireContinuous;
    private bool fireSingle;
    private float lastFireTime;

    void Update()
    {
        if (fireContinuous || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if(timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();
                lastFireTime = Time.time;
                fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        audio.PlaySFX(audio.sword);
        rigidbody.velocity = bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuous = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            fireSingle = true;
        }
    }
}
