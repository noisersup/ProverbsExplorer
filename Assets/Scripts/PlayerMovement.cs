using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 5f;

    public void Move( float horizontal, float vertical )
    {
        transform.Translate(new Vector3(horizontal * move_speed * Time.deltaTime, vertical * move_speed * Time.deltaTime));
    }
}
