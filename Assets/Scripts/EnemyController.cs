using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EntityMovement movement;
    public GameObject target;
    public float max_range;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        float a = (target.transform.position.x - transform.transform.position.x) * (target.transform.position.x - transform.transform.position.x);
        float b = (target.transform.position.y - transform.transform.position.y) * (target.transform.position.y - transform.transform.position.y);
        if(a+b >= max_range) FollowTarget(target);
    }
    void FollowTarget(GameObject target){
        Vector2 direction = (target.transform.position - transform.transform.position).normalized;
        movement.Move(direction.x,direction.y);
    }

}
