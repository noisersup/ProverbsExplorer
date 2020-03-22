using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement player_movement;
    public EntityDamage player_damage;

    void Update()
    {
        player_movement.Move(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        if(Input.GetMouseButtonDown(0)) 
        {
            player_damage.Attack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
