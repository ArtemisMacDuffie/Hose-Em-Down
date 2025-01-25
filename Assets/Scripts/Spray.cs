using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    private CharacterController characterController;
    private StarterAssetsInputs input;
    public int distanceFactor;
    public GameObject camera;
    public GameObject hoseCap;
    public GameObject water;
    public LineRenderer waterLine;
    public GameObject foam;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();
        waterLine.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        IsClick();
        if (water.activeSelf)
        {
            DrawLine();
        }
        else
        {
            target = null;
        }
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

    void DrawLine()
    {
        float distance;

        RaycastHit hit;
        Ray streamRay = new Ray(camera.transform.position, camera.transform.forward);
        Physics.Raycast(streamRay, out hit);
        target = hit.collider.gameObject;

        if (target.CompareTag("Dirty"))
        {
            // start the cleaning method
        }
        else
        {
            target = null;
        }

        distance = hit.distance;
        Vector3[] positions = new Vector3[2];
        positions[0] = Vector3.zero;
        positions[1] = new Vector3(0, distance * distanceFactor, 0);

        waterLine.SetPositions(positions);
    }
}
