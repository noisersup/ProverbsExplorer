using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    GameObject screen;
    void Start(){
        screen = transform.Find("DeathScreen").gameObject;
    }
    public void ShowDeathScreen(){
        screen.SetActive(true);
    }
}
