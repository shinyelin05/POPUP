using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoEnemy : EnemyMove
{
    [SerializeField]
    private float speed = 10f;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < gameManager.minPosition.x - 2f)
        {
            gameManager.score -= 100;
            gameManager.UpdateUI();
            Destroy(gameObject);
        }
    }

}

