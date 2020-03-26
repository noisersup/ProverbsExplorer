using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EntityMovement movement;
    [SerializeField] EntityDamage damage_system;
    [SerializeField] GameObject target;
    [SerializeField] float range_of_view=5f;
    [SerializeField] float max_range;


    bool cooldown_active = false;
    float cooldown_progress = 0;


    bool target_collided = false;
    List <BoxCollider2D> collisions = new List <BoxCollider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == target) target_collided = true;  
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == target) target_collided = false;
    }
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {   
        float distance = Mathf.Sqrt(((target.transform.position.x - transform.transform.position.x) * (target.transform.position.x - transform.transform.position.x))+
                                    ((target.transform.position.y - transform.transform.position.y) * (target.transform.position.y - transform.transform.position.y)));
        if( distance <= range_of_view){
            CooldownTime();
            if(target_collided && !cooldown_active) 
            {
                AttackTarget(target);
            }
            if(distance >= max_range) FollowTarget(target);
        }
    }
    void FollowTarget(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.transform.position).normalized;
        movement.Move(direction.x,direction.y);
    }
    void AttackTarget(GameObject target)
    {
        damage_system.Attack(target.transform.position);
        cooldown_active = true;
    }
    void CooldownTime(){
        if(cooldown_active)
        {
            cooldown_progress += Time.deltaTime;
            if(cooldown_progress >= MeasurmentError(damage_system.GetCooldown()))
            {
                cooldown_active = false;
                cooldown_progress = 0;
            }
        }
    }
    float MeasurmentError(float number)
    {
        return number + Random.Range(0.1f, 10f);
    }
}
