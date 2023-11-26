using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
    }

    public void UpdateScore(ScoreController sc)
    {
        score.text = $"Score: {sc.Score}";
        Debug.Log(score.text);
    }
}
