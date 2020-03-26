using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHp : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    Text hp_status;
    GameObject entity;
    EntityDamage damage_system;


    void Start()
    {
        hp_status = GetComponentInChildren<Text>();
        entity = transform.parent.gameObject;
        damage_system = entity.GetComponent<EntityDamage>();
    }
    void Update()
    {
        FollowEntity();
        UpdateInfo();
    }
    void FollowEntity()
    {
        hp_status.transform.position = Camera.main.WorldToScreenPoint(entity.transform.position + (Vector3) offset);
    }
    void UpdateInfo()
    {
        hp_status.text = damage_system.GetHp()+" / "+ damage_system.GetMaxHp();
    }
}
