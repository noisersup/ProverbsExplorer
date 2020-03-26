using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{

    [SerializeField] int max_hp=10;
    [SerializeField] int damage=5;
    [SerializeField] float cooldown=2;
    
    int hp;
    bool cooldown_active = false;
    float cooldown_progress = 0;
    List <BoxCollider2D> collisions = new List <BoxCollider2D>();  

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetType() == typeof(BoxCollider2D)) collisions.Add((BoxCollider2D) other);  
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetType() == typeof(BoxCollider2D)) collisions.Remove((BoxCollider2D) other);  
    }
    void Start()
    {
        hp = max_hp;
    }
    void Update()
    {
        if(cooldown_active)
        {
            cooldown_progress += Time.deltaTime;
            if(cooldown_progress >= cooldown)
            {
                cooldown_active = false;
                cooldown_progress = 0;
            }
        }
    }
    
    public void Attack(Vector2 location)
    {
        if(!cooldown_active)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(location,0.001f);
            if(colliders.Length>0 && collisions.Contains((BoxCollider2D) colliders[0].GetComponent("BoxCollider2D")))
            {
                GiveDamage(colliders[0].gameObject);
                cooldown_active = true;
            }
        }
    }
    public void TakeDamage(int taken_damage)
    {
        if(taken_damage<0) return;
        hp -= taken_damage;
        Debug.Log("["+gameObject.name+"] HP:"+hp+"/"+max_hp+" (-"+taken_damage+")");
        if(hp<=0){ Die();}
    }
    public float GetCooldown(){return cooldown;}
    public float GetCooldownProgress(){return cooldown_progress;}
    
    public int GetHp(){return hp;}
    public int GetMaxHp(){return max_hp;} 

    void GiveDamage(GameObject target)
    {
        EntityDamage target_damage_system = (EntityDamage) target.GetComponent("EntityDamage");
        if(target_damage_system==null || target.CompareTag(gameObject.tag)) return;

        target_damage_system.TakeDamage(damage);
    }
    void Die()
    {
	    Destroy(gameObject);
        if(tag == "Player") {
            GameObject.FindObjectOfType<DeathScreen>().ShowDeathScreen();
        }
    }
}
