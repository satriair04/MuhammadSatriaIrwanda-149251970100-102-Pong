using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector2 ballSpeed;
    public Vector2 resetPos;
    public Collider2D paddleLeft;       //Referensi ke paddle
    public Collider2D paddleRight;
    private Collider2D paddleLastContact;
    // Start is called before the first frame update
    void Start()
    {
        paddleLastContact = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = ballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + (new Vector3(1, 0, 0) * Time.deltaTime);
        //transform.Translate(new Vector3(1f, 1f, 0) * Time.deltaTime);
        //transform.Translate(ballSpeed * Time.deltaTime);
        
    }

    public void ResetBall()
    {
        transform.position = (new Vector2(resetPos.x, resetPos.y));
    }

    public void ActivePUSpeedUp(float magnitude)
    {
        rb2d.velocity *= magnitude;
        //rb2d.velocity *= magnitude * (rb2d.velocity.normalized);
    }

    public Collider2D GetPaddleLastContact()
    {
        if(paddleLastContact == null)
        {
            return null;
        }
        return paddleLastContact;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Cek tabrakan
        if(collision.gameObject.name == paddleLeft.gameObject.name)
        {
            paddleLastContact = paddleLeft;
            Debug.Log("Hantaman paddle terakhir: " + paddleLastContact.gameObject.name.ToString());
        }
        if(collision.gameObject.name == paddleRight.gameObject.name)
        {
            paddleLastContact = paddleRight;
            Debug.Log("Hantaman paddle terakhir: " + paddleLastContact.gameObject.name.ToString());
        }
        
    }
}
