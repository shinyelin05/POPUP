using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public Vector2 maxPosition { get; private set; }
    public Vector2 minPosition { get; private set; }
    public PoolManager poolManager { get; private set; }

    [SerializeField]
    public int life = 3;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    public int highscore = 0;

    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;
    void Awake()
    {
        maxPosition = new Vector2(1.75f, 4.17f);
        minPosition = new Vector2(-1.75f, -4.17f);

        poolManager = FindObjectOfType<PoolManager>();

        StartCoroutine(EnemySpawn());
        PlayerPrefs.GetInt("HIGHSCORE", 0);
        UpdateUI();
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
    void Update()
    {
        
    }
    private void UpdateUI()
    {
        lifeText.text = string.Format("LIFE : {0}", life);
        scoreText.text = string.Format("SCORE : {0}", score);
        highScoreText.text = string.Format("HIGHSCORE : {0}", highscore);
    }
    private IEnumerator EnemySpawn()
    {
        float randomX = 0f;
        float randomDelay = 0f;
        while(true)
        {
            randomX = Random.Range(-1.5f, 1.5f);
            randomDelay = Random.Range(0.1f, 2f);
            Instantiate(enemyPrefab, new Vector2(randomX, 4f), Quaternion.identity);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
