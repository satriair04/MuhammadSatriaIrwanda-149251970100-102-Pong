using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rb2d;
    private Vector3 defaultSize;    //Pada game start akan menyimpan dahulu nilai defaultnya
    private float initialSpeed;
    void Start()
    {
        defaultSize = gameObject.transform.localScale;
        initialSpeed = paddleSpeed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }

    public void PaddleSizeIncrease(int duration)
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z);
        Invoke("PaddleSizeReset", duration);
    }

    private void PaddleSizeReset()
    {
        gameObject.transform.localScale = defaultSize;
    }

    public void PaddleSpeedIncrease(int duration)
    {
        //paddleSpeed *= paddleSpeed;
        paddleSpeed = paddleSpeed + 1; //Menghindari bola terlalu cepat
        Invoke("PaddleSpeedReset", duration);
    }
    
    private void PaddleSpeedReset()
    {
        paddleSpeed = initialSpeed;
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
        //Debug.Log("paddleSpeed: " + paddleSpeed + ". Movement: " + movement + ". Velocity: " + rb2d.velocity);
    }
}
