using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameManager gameManager = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        CheckLimit();
    }

    private void CheckLimit()
    {
        if (transform.position.y > gameManager.MaxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }
        if (transform.position.x > gameManager.MaxPosition.x + 2f)
        {
            Despawn();
        }
        if (transform.position.x < gameManager.MinPosition.x - 2f)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        transform.SetParent(gameManager.transform, false);
        gameObject.SetActive(false);
    }
}



