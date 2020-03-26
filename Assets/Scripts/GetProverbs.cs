using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetProverbs : MonoBehaviour
{
    private string proverbs_text;
    public Button button;
    private Pickup pickup;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ReadProverbs);
    }

    void ReadProverbs()
    {
        GameObject canvas = GameObject.Find("MainCanvas");
        CanvasProxy CP = canvas.GetComponent<CanvasProxy>();
        CP.image.enabled = true;
        CP.text.enabled = true;
        CP.text.text = pickup.proverbs_text;
    }
}
