using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 2;

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.position.x, target.position.y, -10), smoothSpeed * Time.deltaTime);
    }
}
