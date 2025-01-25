using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    [Range(0f, 1f)]
    public float dirt = 1;
    public Material dirtGraph;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirtGraph.SetFloat("_Dirtiness", dirt);
    }
}
