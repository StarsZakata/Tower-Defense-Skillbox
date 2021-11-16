using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text GoldTxt, LivesTxt;
    public int Gold, TowerCost, EnemyCost, Lives;
    public GameObject DeadPanel;
    
    void Start()
    {
        DeadPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GoldTxt.text = "Gold: " + Gold;
        LivesTxt.text = "Lives: " + Lives;
    }

    public void MissEnemy()
    {
        Lives -= 1;

        if(Lives <= 0)
        {
            DeadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BuildTower()
    {
        Gold -= TowerCost;
    }

    public void EnemyKill()
    {
        Gold += EnemyCost;
    }
}
