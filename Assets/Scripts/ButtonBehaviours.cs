using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonBehaviours : MonoBehaviour
{
    public Button theButton;
    public static bool isBun;

    void Start()
    {
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Debug.Log(isBun);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    GameObject FindObjectByName(string name)
    {
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach(GameObject obj in objs)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    void TaskOnClick()
    {
        if (theButton.name == "StartBtn")
        {
            SceneManager.LoadScene("GameScreen");
        }
        else if (theButton.name == "PauseBtn")
        {
            Time.timeScale = 0;
            SwitchObject("Menu", true);
        }
        else if(theButton.name == "ResumeBtn")
        {
            SwitchObject("Menu", false);
            Time.timeScale = 1;
        }
        else if(theButton.name == "ShopBtn")
        {
            SwitchObject("Shop", true);
            SwitchObject("Menu", false);
        }
        else if(theButton.name == "ExitShopBtn")
        {
            SwitchObject("Shop", false);
            Time.timeScale = 1;
        }
        else if(theButton.name == "CharacterBtn")
        {
            SwitchObject("SelectionMenu", true);
        }
        else if(theButton.name == "SwirlBtn")
        {
            SceneManager.LoadScene("GameScreen");
        }
        else if (theButton.name == "BunBtn")
        {
            isBun = true;
            SceneManager.LoadScene("GameScreen");
        }
        else if(theButton.name == "ReplayBtn")
        {
            SceneManager.LoadScene("GameScreen");
        }
    }

    void SwitchObject(string name, bool onOff)
    {
        GameObject obj = FindObjectByName(name);
        if(obj != null) obj.SetActive(onOff);
    }

    
}
