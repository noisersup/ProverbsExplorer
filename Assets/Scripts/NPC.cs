using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // deploy dialog system
            Application.LoadLevel("FirstQuest");

            /*Scene first_quest = SceneManager.GetSceneByName("FirstQuest");
            SceneManager.LoadScene("FirstQuest", LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(other.gameObject, first_quest);*/
        }
    }
}
