using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetProverbs : MonoBehaviour
{
    private string proverbs_text;
    public Button button;
    private Pickup pickup;
    public CanvasProxy CP;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(ReadProverbs);
    }

    void ReadProverbs()
    {
        
        CP.image.enabled = true;
        CP.text.enabled = true;
    }
}
