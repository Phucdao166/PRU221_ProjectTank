using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMoveCreateMap : MonoBehaviour
{
    public float speed;
    private float lastMove = 0f;
    private float delay = 0.2f;

    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public Vector3 Move(Direction direction)
    {
        /*var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed*Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed*Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed*Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed*Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;*/
        var currentPos = gameObject.transform.position;
        if (lastMove + delay > Time.time)
        {
            return currentPos;
        }
        switch (direction)
        {

            case Direction.Down:
                currentPos.y -= speed;
                break;
            case Direction.Left:
                currentPos.x -= speed;
                break;
            case Direction.Right:
                currentPos.x += speed;
                break;
            case Direction.Up:
                currentPos.y += speed;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        lastMove = Time.time;

        return currentPos;
    }
}
