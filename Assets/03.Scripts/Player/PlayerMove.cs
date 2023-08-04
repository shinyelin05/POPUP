using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("플레이어 관리")]
    private float speed = 10f;
    private Vector2 targetPosition = Vector2.zero; 

    [Header("플레이어 총알 관리")]
    [SerializeField]
    private float bulletDelay = 1f;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;

    [Header("관리 매니저")]
    private GameManager gameManager = null;
    private PoolManager poolManager = null;

    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        poolManager = FindObjectOfType<PoolManager>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.minPosition.y, gameManager.maxPosition.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
   
    private IEnumerator Fire()
    {
        while(true)
        {
        Instanbullet();
        yield return new WaitForSeconds(bulletDelay);
        }
    }
    private void Instanbullet()
    {
        GameObject bullet = null;
        if (poolManager.transform.childCount > 0)
        {
            bullet = poolManager.transform.GetChild(0).gameObject;
            bullet.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
        }

        bullet.transform.SetParent(null);
        bullet.transform.position = bulletPosition.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameManager.life--;

            if(gameManager.life<=0)
            {
                PlayerPrefs.SetInt("SCORE", gameManager.score);
                PlayerPrefs.SetInt("HIGHSCORE", gameManager.highscore);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

}
