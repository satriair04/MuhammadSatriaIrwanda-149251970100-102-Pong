using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * paddleSpeed;
        }
        if (Input.GetKey(downKey))
        {
            return Vector2.down * paddleSpeed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //transform.Translate(movement * Time.deltaTime);
        rb2d.velocity = movement;
    }
}
