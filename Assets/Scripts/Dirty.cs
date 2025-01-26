using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirty : MonoBehaviour
{
    Animator anim;
    [Range(0f, 1f)]
    public float dirt = 1f;
    public float cleanTime;
    public bool beingCleaned;
    public Scoring scoring;
    public GameObject tada;
        
    // Start is called before the first frame update
    void Start()
    {
        beingCleaned = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beingCleaned) { Cleaning(); }
    }

    public void Cleaning()
    {
        dirt = dirt - Time.deltaTime / cleanTime;
        anim.Play("DirtAnim", 0, 1f - dirt);
        beingCleaned = false;

        if (dirt <= 0f)
        {
            scoring.RemoveGameObject(gameObject);
            tada.SetActive(true);
        }
    }
}
