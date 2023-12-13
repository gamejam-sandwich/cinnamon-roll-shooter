using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public class ButtonBehaviours : MonoBehaviour
{
    public Button theButton;
    private HealthController hc;
    private PlayerShoot ps;
    private ScoreController sc;

    void Start()
    {
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        SetShopPanelOpacity(1);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        var currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScreen")
        {
            hc = GameObject.Find("Player").GetComponent<HealthController>();
            ps = GameObject.Find("Player").GetComponent<PlayerShoot>();
            sc = GameObject.Find("Player").GetComponent<ScoreController>();
        }
    }

    public static GameObject FindObjectByName(string name)
    {
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objs)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    async void TaskOnClick()
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
        else if (theButton.name == "ResumeBtn")
        {
            SwitchObject("Menu", false);
            Time.timeScale = 1;
        }
        else if (theButton.name == "ShopBtn")
        {
            SwitchObject("Shop", true);
            SwitchObject("Warning", false);
            SwitchObject("Menu", false);
        }
        else if (theButton.name == "ExitShopBtn")
        {
            SwitchObject("Shop", false);
            Time.timeScale = 1;
        }
        else if (theButton.name == "CharacterBtn")
        {
            SwitchObject("SelectionMenu", true);
        }
        else if (theButton.name == "ReplayBtn")
        {
            SceneManager.LoadScene("GameScreen");
        }
        else if (theButton.name == "SpeedBtn")
        {
            if (!CheckScore(1000)) return;
            Time.timeScale = 5;
            SetShopPanelOpacity(1);
            StartCoroutine(DelayAction(() => Time.timeScale = 1, 10));
        }
        else if (theButton.name == "HealthBtn")
        {
            if (!CheckScore(300)) return;
            float health = hc.maxHealth - hc.currentHealth;
            hc.AddHealth(health);
            SwitchObject("Shop", false);
            Time.timeScale = 1;
        }
        else if (theButton.name == "BulletBtn")
        {
            if (!CheckScore(10000)) return;
            ps.timeBetweenShots = 0.1f;
            Time.timeScale = 1;
            StartCoroutine(DelayAction(() => ps.timeBetweenShots = 0.5f, 1));            
        }
    }

    public bool CheckScore(int req)
    {
        if (sc.Score < req)
        {
            SwitchObject("Warning", true);
            return false;
        }
        return true;
    }

    void SwitchObject(string name, bool onOff)
    {
        GameObject obj = FindObjectByName(name);
        if (obj != null) obj.SetActive(onOff);
    }

    IEnumerator DelayAction(Action action, float seconds)
    {
        SetShopPanelOpacity(0);
        Debug.Log("Delay Action Entered");
        yield return new WaitForSeconds(seconds);
        Debug.Log("action timeout");
        action();
        SetShopPanelOpacity(1);
        SwitchObject("Shop", false);

    }

    void SetShopPanelOpacity(float opacity)
    {
        //Image shopPanelImage = GameObject.Find("Shop").GetComponent<Image>();
        Image shopPanelImage = FindObjectByName("Shop")?.GetComponent<Image>();
        if (shopPanelImage == null || shopPanelImage.material == null) return;
        Color objColor = shopPanelImage.material.color;
        objColor.a = opacity;
        shopPanelImage.material.color = objColor;
    }

}
