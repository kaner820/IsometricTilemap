using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private int lastDir;
    
    public string[] staticDirections =
        { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public string[] runDirections =
        { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction.magnitude < 0.01)
        {
            anim.Play(staticDirections[lastDir]);
        }
        else
        {
            lastDir = DirectionToIndex(direction);
            anim.Play(runDirections[lastDir]);
        }
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;
        float step = 360 / 8; //45
        float offset = step / 2; //22.5

        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
