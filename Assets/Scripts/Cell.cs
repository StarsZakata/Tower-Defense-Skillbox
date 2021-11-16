using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Material MainMaterial;
    public Material CanMaterial;
    public Material CantMaterial;
    public bool CanBuild;
    public GameObject TowerPrefab;

    private ResourceManager rm;

    void Start()
    {
        rm = FindObjectOfType<ResourceManager>();
    }

    private void OnMouseUp()
    {
        if(CanBuild && rm.Gold >= rm.TowerCost)
        {
            Tower tower = Instantiate(TowerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)).GetComponent<Tower>();
            CanBuild = false;
            rm.BuildTower();
        }
    }

    private void OnMouseOver()
    {
        if(CanBuild)
        {
            GetComponent<Renderer>().material = CanMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = CantMaterial;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }
}
