using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;

    private float timeLeft;
    private int rand;

    public GameObject[] enemyPrefabs;

    void Awake()
    {
        SetTimeLeft();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if(timeLeft <= 0)
        {
            rand = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[rand], transform.position, Quaternion.identity);
            SetTimeLeft();
        }
    }

    private void SetTimeLeft()
    {
        timeLeft = Random.Range(minSpawnTime,maxSpawnTime);
    }
}
