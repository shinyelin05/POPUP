using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
