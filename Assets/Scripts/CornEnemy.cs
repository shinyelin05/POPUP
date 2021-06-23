using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEnemy : EnemyMove
{
    [SerializeField]
    private float speed = 10f;
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < gameManager.minPosition.y - 2f)
        {
            gameManager.score -= 10;
            gameManager.UpdateUI();
            Destroy(gameObject);
        }
    }
}
