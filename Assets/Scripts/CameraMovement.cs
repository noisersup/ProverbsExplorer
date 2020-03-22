using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public float distance;
    public Vector2 offset;
    public float camera_speed;
    
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x + offset.x,
                                         target.transform.position.y + offset.y,
                                         transform.position.z);

        Camera.main.orthographicSize = distance;
    }

    void LateUpdate()
    {
        Vector3 target_position = new Vector3(target.transform.position.x + offset.x,
                                              target.transform.position.y + offset.y,
                                              transform.position.z);
                                              
        transform.position = Vector3.Lerp(transform.position, target_position, camera_speed);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, distance, camera_speed);
    }
}
