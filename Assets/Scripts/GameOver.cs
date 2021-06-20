using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;
    void Start()
    {
        textHighScore.text = string.Format("HIGHSCORE\n{0}", PlayerPrefs.GetInt("HIGHSCORE", 500));
    }

    void Update()
    {
        
    }
}
