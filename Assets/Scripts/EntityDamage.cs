using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{

    [SerializeField] int max_hp=10;
    [SerializeField] int damage=5;
    
    int hp;
     List <BoxCollider2D> collisions = new List <BoxCollider2D>();
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetType() == typeof(BoxCollider2D)) collisions.Add((BoxCollider2D) other);  
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.GetType() == typeof(BoxCollider2D)) collisions.Remove((BoxCollider2D) other);  
    }
    void Start()
    {
        hp = max_hp;
    }
    
    public void Attack(Vector2 location)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(location,0.001f);
        if(colliders.Length>0 && collisions.Contains((BoxCollider2D) colliders[0].GetComponent("BoxCollider2D")))  GiveDamage(colliders[0].gameObject);
    }
    public void TakeDamage(int taken_damage)
    {
        if(taken_damage<0) return;
        hp -= taken_damage;
        Debug.Log("["+gameObject.name+"] HP:"+hp+"/"+max_hp+" (-"+taken_damage+")");
        if(hp<=0){ Die();}
    }
    
    void GiveDamage(GameObject target)
    {
        EntityDamage target_damage_system = (EntityDamage) target.GetComponent("EntityDamage");
        if(target_damage_system==null || target.CompareTag(gameObject.tag)) return;

        target_damage_system.TakeDamage(damage);
    }
    void Die()
    {
	    Destroy(gameObject);
    }
}
