using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 MaxPosition { get; private set; }
    public Vector2 MinPosition { get; private set; }
    void Start()
    {
        MaxPosition = new Vector2(1.75f, 4.17f);
        MinPosition = new Vector2(-1.75f, -4.17f);
    }

    void Update()
    {
        
    }
}
