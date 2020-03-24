using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EntityMovement movement;
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(target);
    }
    void FollowTarget(GameObject target){
        Vector2 direction = (target.transform.position - transform.transform.position).normalized;
        movement.Move(direction.x,direction.y);
    }
}
