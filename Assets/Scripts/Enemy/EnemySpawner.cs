using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;

    private float timeLeft;

    void Awake()
    {
        SetTimeLeft();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if(timeLeft <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeLeft();
        }
    }

    private void SetTimeLeft()
    {
        timeLeft = Random.Range(minSpawnTime,maxSpawnTime);
    }
}
