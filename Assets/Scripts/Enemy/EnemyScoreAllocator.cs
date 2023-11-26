using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int killScore;

    private ScoreController sc;

    private void Awake()
    {
        sc = FindObjectOfType<ScoreController>();
    }

    public void AllocateScore()
    {
        sc.AddScore(killScore);
    }
}
