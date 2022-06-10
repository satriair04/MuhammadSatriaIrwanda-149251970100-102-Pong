using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenAuthor()
    {
        Debug.Log("Game keren oleh Muhammad Satria Irwanda [149251970100-102]");
    }
}
