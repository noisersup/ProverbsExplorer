using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Button button;
    public Image img;
    public Text txt;
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ClosePopUp);
    }

    void ClosePopUp()
    {
        img.enabled = false;
        txt.enabled = false;
    }
}
