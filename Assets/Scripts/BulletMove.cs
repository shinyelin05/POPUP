using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameManager gameManager = null;
    private PoolManager poolManager = null;

    private static GameManager instance = null;
    private static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if(instance == null )
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return instance;
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
        if (transform.position.y > Instance.maxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.y < Instance.minPosition.y - 2f)
        {
            Despawn();
        }
        if (transform.position.x > Instance.maxPosition.x + 2f)
        {
            Despawn();
        }
        if (transform.position.x < Instance.minPosition.x - 2f)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        transform.SetParent(gameManager.poolManager.transform, false);
        gameObject.SetActive(false);
    }
}



