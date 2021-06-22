using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;
    private Text textScore = null;

    void Start()
    {
        textHighScore.text = string.Format("HIGHSCORE\n{0}", PlayerPrefs.GetInt("HIGHSCORE"));
       textScore.text = string.Format("SCORE\n{0}", PlayerPrefs.GetInt("SCORE"));
    }

    void Update()
    {
        
    }
}
