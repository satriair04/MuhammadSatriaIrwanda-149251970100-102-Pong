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
    public Vector2 powerUpAreaMax;

    public int spawnInterval = 1;           //Default
    public int selfDestroyInterval = 1;     //Default; baru ditambahkan
    private float timer;
    
    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
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

        //integer randomIndex sepertinya agar powerup yang muncul bisa bermacam-macam
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
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
