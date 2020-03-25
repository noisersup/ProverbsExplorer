using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EntityMovement movement;
    [SerializeField] EntityDamage damage_system;
    [SerializeField] GameObject target;
    [SerializeField] float max_range;

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
    void Update()
    {   
        if(target_collided) 
        {
            AttackTarget(target);
        }
        float a = (target.transform.position.x - transform.transform.position.x) * (target.transform.position.x - transform.transform.position.x);
        float b = (target.transform.position.y - transform.transform.position.y) * (target.transform.position.y - transform.transform.position.y);
        if(a+b >= max_range) FollowTarget(target);
    }
    void FollowTarget(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.transform.position).normalized;
        movement.Move(direction.x,direction.y);
    }
    void AttackTarget(GameObject target)
    {
        damage_system.Attack(target.transform.position);
    }
}
