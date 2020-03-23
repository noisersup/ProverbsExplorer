using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject box;
    public bool debug_box = false;
    RectTransform rect;
    Text text_box;
    bool open = false;
    void Start()
    {
        box.SetActive(false);
        rect = (RectTransform) box.GetComponent("RectTransform");
        text_box = box.transform.Find("Text").GetComponent<Text>();
    }
    void Update()
    {
        if(debug_box) Prompt("Lorem ipsum dolor sit amet, consectetur adipiscing elit. ");
        if(Input.GetKey("space") && open) Close();
    }
    public void Prompt(string content)
    {
        open=true;
        box.SetActive(true);
        text_box.text = content;
    }
    void Close()
    {
        open=false;
        box.SetActive(false);
    }

}
