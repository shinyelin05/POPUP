using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cornEnemy;

    [SerializeField]
    private GameObject nachoEnemy;

    public Vector2 maxPosition { get; private set; }
    public Vector2 minPosition { get; private set; }
    public PoolManager poolManager { get; private set; }

    private static GameManager instance = null;
   
    [SerializeField]
    public int life = 3;
    [SerializeField]
    public int score = 0;
    [SerializeField]
    public int highscore = 0;

    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;

    private int countDown = 3;

    void Awake()
    {
       

        Screen.SetResolution(1440, 2960, false);
        maxPosition = new Vector2(2.2f, 4.2f);
        minPosition = new Vector2(-2.2f, -4.2f);

        poolManager = FindObjectOfType<PoolManager>();

        StartCoroutine(EnemySpawn());
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        UpdateUI();
    }

    void Update()
    {
    
    }
   

    public void AddScore()
    {
        score += 10;
        if(score>highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
        }
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        if(score<0)
        {
            score = 0;  
        }
        lifeText.text = string.Format("LIFE : {0}", life);
        scoreText.text = string.Format("SCORE : {0}", score);
        highScoreText.text = string.Format("HIGHSCORE : {0}", highscore);
    }

    private IEnumerator EnemySpawn()
    {
        float randomX = 0f;
        float randomY = 0f;
        float randomDelay = 0f;

        while(true)
        {
            int randomEnemy = Random.Range(1, 3);
            randomX = Random.Range(-1.5f, 1.5f);
            randomY = Random.Range(4f, 0f);
            randomDelay = Random.Range(0.1f, 1f);
            switch(randomEnemy)
            {
                case 1:
                    Instantiate(cornEnemy, new Vector2(randomX, 4f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(nachoEnemy, new Vector2(randomX, 4f), Quaternion.identity);
                    break;

            }
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
