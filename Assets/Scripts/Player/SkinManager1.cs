using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager1 : MonoBehaviour
{
    public GameObject selectedskin;
    public GameObject Player;
    private Sprite playersprite;

    void Start()
    {
        playersprite = selectedskin.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }
}
