using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonBehaviours : MonoBehaviour
{
    public Button theButton;
    private GameObject menu;
    private GameObject canv;

    void Start()
    {
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        canv = GameObject.Find("Canvas");
        menu = canv.GetComponent<GameObject>();
        Debug.Log(menu);
    }

    void TaskOnClick()
    {
        if (theButton.name == "StartBtn")
        {
            SceneManager.LoadScene("GameScreen");
        }
        else if (theButton.name == "PauseBtn")
        {
            Debug.Log("Paused");
            Debug.Log(menu);
            menu.SetActive(true);
        }
    }

    
}
