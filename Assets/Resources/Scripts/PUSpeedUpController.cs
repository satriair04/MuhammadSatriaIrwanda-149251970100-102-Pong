using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D bola;
    public float magnitude;
    public PowerUpManager manager;

    private void Start()
    {
        Invoke("SelfDestructByManager", manager.selfDestroyInterval);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision = bola)
        {

            //Speed up si bola
            //bola.GetComponent<Bola>().DoubleSpeed();
            bola.GetComponent<Bola>().ActivePUSpeedUp(magnitude);

            //Destroy(gameObject);
            manager.RemovePowerUp(gameObject);
        }
    }

    private void SelfDestructByManager()
    {
        manager.RemovePowerUp(gameObject);
    }
}
