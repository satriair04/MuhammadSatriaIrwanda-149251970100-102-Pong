using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector2 ballSpeed;
    // Start is called before the first frame update
    void Start()
    {
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
}
