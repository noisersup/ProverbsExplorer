using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityMovement player_movement;
    public EntityDamage player_damage;
    public Animator animator;
    private bool is_attack;

    void Update()
    {
        player_movement.Move(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        /*if(Input.GetMouseButtonDown(0))
        {
            player_damage.Attack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }*/

        Flip();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            is_attack = true;
        }
        else
        {
            is_attack = false;
        }

        animator.SetFloat("move_x", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("move_y", Input.GetAxisRaw("Vertical"));
        animator.SetBool("attack_right_side", is_attack);
    }

    void Flip()
    {
        if(Input.GetAxis("Horizontal") < -0.5)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetAxis("Horizontal") >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
