using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasProxy : MonoBehaviour
{
    public Image image;
    public Text text;
    public Button button;

    void Start()
    {
        Image img = image.GetComponent<Image>();
        Text txt = text.GetComponent<Text>();
        Button btn = button.GetComponent<Button>();
        button.onClick.AddListener(Close);
        image.enabled = false;
        text.enabled = false;
    }

    void Close()
    {
        image.enabled = false;
        text.enabled = false;
    }
}
