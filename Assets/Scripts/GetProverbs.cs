using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetProverbs : MonoBehaviour
{
    private string proverbs = Pickup.Text;
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ReadProverbs);
    }

    void ReadProverbs()
    {
        Debug.Log(proverbs);
        GameObject canvas = GameObject.Find("Canvas");
        CanvasProxy CP = canvas.GetComponent<CanvasProxy>();
        CP.image.enabled = true;
        CP.text.enabled = true;
        CP.text.text = proverbs;
    }
}
