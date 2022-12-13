using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    List<GameObject> children = new List<GameObject>(); //Obsolete?
    GameObject statsUI;
    GameObject AttackMenu;

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            children.Add(child.gameObject);
        }

        statsUI = transform.GetChild(0).gameObject;
    }

    public void SetHealth(int health)
    {
        statsUI.GetComponentInChildren<Text>().text = "Health: " + health + "/" + PlayerData.MaxHealth;
    }
}
