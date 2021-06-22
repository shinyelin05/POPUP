using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    GameManager gameManager;
    //Animator anim;
    void Start()
    {
        //anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
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
            //anim.Play("Popanim");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameManager.AddScore();
        }
    }

}
