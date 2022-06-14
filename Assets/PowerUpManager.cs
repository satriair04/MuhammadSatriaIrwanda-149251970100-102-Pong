using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;                    //Akan muncul sebanyak 1+X; X = angka yg diisi pada inspector
    public List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;    //Mungkin ini diisi dengan berbagai macam jenis powerUp

    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public int xAxisBoundary = 1;           //Membatasi agar spawn tidak mepet ditengah; baru ditambahkan
    public Vector2 powerUpAreaMax;

    public int spawnInterval = 1;           //Default
    public int selfDestroyInterval = 1;     //Default; baru ditambahkan
    private float timer;
    private bool leftSpawn;
    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
        leftSpawn = true;
    }

    private void Update()
    {
        timer = Time.deltaTime;
        if (timer < spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
            //Debug
            Debug.Log("Power up telah muncul");
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    //Method ini fungsinya agar objek/prefab yang akan muncul memiliki posisinya secara acak pada Scene
    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count > maxPowerUpAmount-1)
        {
            //Skip method jika jumlah total powerUp udah mentok
            return;
        }

        if (position.x < powerUpAreaMin.x || position.y < powerUpAreaMin.y || position.x > powerUpAreaMax.x || position.y > powerUpAreaMax.y)
        {
            //Skip method jika hasil mathRandom diluar jangkauan
            return;
        }

        //Penambahan percabangan agar sebaran powerUp terlihat merata kiri dan kanan
        //Perpatokan sumbu x; Modifikasi sumbu x berdasarkan batasan tengah sumbu x
        //Example: Jika xAxisBoundary = 2; maka batas tengah area kiri adalah -2 sedangkan kanan adalah 2
        //Example: Jika xAxisBoundary = 3; maka batas tengah area kiri adalah -3 sedangkan kanan adalah 3
        if (leftSpawn)
        {
            if (position.x > -xAxisBoundary)
            {
                position.x = -position.x;   //Ubah ke negatif
            }
            position.x = Random.Range(position.x, -xAxisBoundary);  
        }
        else
        {
            if (position.x < xAxisBoundary)
            {
                position.x *= position.x;   //Ubah ke positif jika nilai kecil dari 0
            }
            position.x = Random.Range(xAxisBoundary, position.x);  // dari 0 hingga mendekati position.x
        }

        //integer randomIndex sepertinya agar powerup yang muncul bisa bermacam-macam
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
        leftSpawn = !leftSpawn; //Membuat spawn powerUp bergantian ke kanan dan kiri
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        //Hapus suatu powerUp yang dipilih
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

}
