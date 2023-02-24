using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    protected GameManager gameManager;

    private int enemyCount = 3;

    //Animator anim;
    protected virtual void Start()
    {
        //anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(transform.position.y<gameManager.minPosition.y-2f)
        {
            gameManager.score -= 10;
            gameManager.UpdateUI();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameManager.AddScore();
        }
    }

}
