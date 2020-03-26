using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetProverbs : MonoBehaviour
{
    string proverbs;
    public Button button;
    private Pickup pickup;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ReadProverbs);
        proverbs = pickup.proverbs_text;
    }

    void ReadProverbs()
    {
        Debug.Log(proverbs);
        GameObject canvas = GameObject.Find("Canvas");
        CanvasProxy CP = canvas.GetComponent<CanvasProxy>();
        CP.image.enabled = true;
        CP.text.enabled = true;
        CP.text.text = "pierwsza część: " + pickup.proverbs_text;
        Debug.Log("pierwsza część: " + pickup.proverbs_text);
        Debug.Log(proverbs);
    }
}
