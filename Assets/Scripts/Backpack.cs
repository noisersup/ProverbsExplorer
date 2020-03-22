using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public GameObject inventory;
    public Button button;

    void Start()
    {
        GameObject equ = inventory.GetComponent<GameObject>();
        Button btn = button.GetComponent<Button>();

        button.onClick.AddListener(ShowEqu);

        inventory.SetActive(false);
    }

    void ShowEqu()
    {
        if(!inventory.activeInHierarchy)
        {
            inventory.SetActive(true);
        }else
        {
            inventory.SetActive(false);
        }
    }
}
