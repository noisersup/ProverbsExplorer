using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] Vector2 offset = new Vector2(70,0);
    [SerializeField] GameObject player;

    EntityDamage damage_system;
    Text text;
    
    void Start(){
        text = gameObject.GetComponent<Text>();
        damage_system = player.GetComponent<EntityDamage>();
    }
    void Update()
    {
        FollowEntity();
        UpdateInfo();
    }
    void FollowEntity()
    {
        transform.position = Input.mousePosition + (Vector3) offset;
    }
    void UpdateInfo()
    {
        text.text = damage_system.GetCooldownProgress()+" / "+damage_system.GetCooldown()+"s";
    }
}
