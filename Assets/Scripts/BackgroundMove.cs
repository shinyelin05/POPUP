using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer renderer = null;
    private Vector2 offset = Vector2.zero;
    [SerializeField]
    private float speed = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        offset.y += speed * Time.deltaTime ;
        renderer.material.SetTextureOffset("_MainTex", offset);
    }
}
