using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y<gameManager.minPosition.y-2f)
        {
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
