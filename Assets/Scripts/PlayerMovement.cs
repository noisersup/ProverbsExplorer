using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 5f;

    public void MoveH( float horizontal )
    {
        transform.Translate(new Vector3(horizontal * move_speed * Time.deltaTime, 0));
    }
    public void MoveV(float vertical )
    {
        transform.Translate(new Vector3(0, vertical * move_speed * Time.deltaTime));
    }
}
