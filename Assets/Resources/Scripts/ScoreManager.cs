using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public Bola objekBola;
    public int paddleScoreLeft;
    public int paddleScoreRight;
    public int maxScore;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLeftScore(int increment)
    {
        paddleScoreLeft += increment;
        objekBola.ResetBall();
        if (paddleScoreLeft >= maxScore)
        {
            GameOver();
        }
    }

    public void AddRightScore(int increment)
    {
        paddleScoreRight += increment;
        objekBola.ResetBall();
        if (paddleScoreRight >= maxScore)
        {
            GameOver();
        }
    }

   


    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToMainMenu()
    {
        //Method dibedakan karena mungkin nanti akan ada penambahan fungsi yang berbeda
        SceneManager.LoadScene("MainMenu");
    }
}
