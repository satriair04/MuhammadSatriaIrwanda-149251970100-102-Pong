using System;   //Try-catch Exception
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleFastController : MonoBehaviour
{
    public Collider2D bola;
    public int buffDuration;
    public PowerUpManager manager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestructByManager", manager.selfDestroyInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == bola)
        {
            Collider2D paddleLastContact = bola.GetComponent<Bola>().GetPaddleLastContact();
            try
            {
                paddleLastContact.GetComponent<Paddle>().PaddleSpeedIncrease(buffDuration);
            }
            catch (Exception)
            {
                //Do-nothing.
            }      
            manager.RemovePowerUp(gameObject);
        }
    }

    private void SelfDestructByManager()
    {
        manager.RemovePowerUp(gameObject);
    }
}
