using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{
    public int max_hp;  //temporary, until global config introduction
    public int player_damage;   //temporary, until global config introduction
    public int range;   //temporary, until global config introduction

    int hp;

    void Start()
    {
        hp = max_hp;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) Attack(Input.mousePosition);
    }

    public void TakeDamage(int taken_damage)
    {
        if(taken_damage<0) return;
        hp -= taken_damage;
        Debug.Log("["+gameObject.name+"] HP:"+hp+"/"+max_hp+" (-"+taken_damage+")");
        if(hp<=0){ Die();}
    }
    
    public void Attack(Vector2 location)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(location,0.001f);
        foreach(Collider2D collider in colliders)
        {
            GiveDamage(collider.gameObject);
        }
    }

    void GiveDamage(GameObject target)
    {
        EntityDamage target_damage_system = (EntityDamage) target.GetComponent("EntityDamage");
        if(target_damage_system==null || target.tag == gameObject.tag) return;

        target_damage_system.TakeDamage(player_damage);
    }
    void Die()
    {
        Debug.Log(gameObject.name+" zaliczył zgona");
    }
}
