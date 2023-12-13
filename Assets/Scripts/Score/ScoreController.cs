using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    public int Score { get; private set; }

    public void AddScore(int amt)
    {
        Score += amt;
        OnScoreChanged.Invoke();
    }

    public void CostScore(int amt)
    {
        Score -= amt;
        OnScoreChanged.Invoke();
    }
}
