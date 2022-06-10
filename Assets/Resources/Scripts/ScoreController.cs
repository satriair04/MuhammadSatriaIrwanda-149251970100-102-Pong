using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text textScoreLeft;
    public Text textScoreRight;
    public ScoreManager manager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScoreLeft.text = manager.paddleScoreLeft.ToString();
        textScoreRight.text = manager.paddleScoreRight.ToString();
    }
}
