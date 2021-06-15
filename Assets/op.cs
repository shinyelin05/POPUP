using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op : MonoBehaviour
{
    public MeshRenderer mash;
    // Start is called before the first frame update
    void Start()
    {
        mash = GetComponent<MeshRenderer>();
        mash.material.color = new Color(mash.material.color.r, mash.material.color.g, mash.material.color.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
