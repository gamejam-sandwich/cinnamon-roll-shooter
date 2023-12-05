using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariation : MonoBehaviour
{
    private int rand;
    public Sprite[] enemies;

    void Start()
    {
        rand = Random.Range(0, enemies.Length - 1);
        GetComponent<SpriteRenderer>().sprite = enemies[rand];
    }
}
