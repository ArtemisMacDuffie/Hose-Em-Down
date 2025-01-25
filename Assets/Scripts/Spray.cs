using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    private CharacterController characterController;
    private StarterAssetsInputs input;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        IsClick();
    }

    void IsClick()
    {
        if (input.hose)
        {
            water.SetActive(true);
        }
        else
        {
            water.SetActive(false);
        }
    }
}
