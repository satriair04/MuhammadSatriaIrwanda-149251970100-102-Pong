using System;   //Try-catch Exception
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSizeController : MonoBehaviour
{
    public Collider2D bola;
    public int buffDuration;
    public PowerUpManager manager;
    private void Start()
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
                paddleLastContact.GetComponent<Paddle>().PaddleSizeIncrease(buffDuration);
            }catch(Exception)
            {
                //Do-nothing, Agar gak ada keliatan ada error saat di UnityEditor-nya   
            }
            manager.RemovePowerUp(gameObject);
        }
    }

    private void SelfDestructByManager()
    {
        manager.RemovePowerUp(gameObject);
    }
}
