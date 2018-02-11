using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private Vector3 position;

    void Start()
    {
        position = Camera.main.transform.position;
    }
        
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = new Vector3(position.x + target.position.x * 0.4f, position.y, target.position.z * 0.4f);
            /*Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(startX, destination.y, destination.z), ref velocity, dampTime);*/
        }

    }
}
