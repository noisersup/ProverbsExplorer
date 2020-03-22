using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement player_movement;
    public EntityDamage player_damage;
    void Start(){
    }
    void Update(){
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            player_movement.MoveH(Input.GetAxisRaw("Horizontal"));

        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            player_movement.MoveV(Input.GetAxisRaw("Vertical"));

    }
}
