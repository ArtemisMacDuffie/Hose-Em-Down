using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    private CharacterController characterController;
    private StarterAssetsInputs input;
    public int distanceFactor;
    public GameObject mainCamera;
    public GameObject hoseCap;
    public GameObject water;
    public LineRenderer waterLine;
    public GameObject bubbleSpray;
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
            bubbleSpray.SetActive(true);
        }
        else
        {
            water.SetActive(false);
            bubbleSpray.SetActive(false);
        }
    }

    void DrawLine()
    {
        float distance;

        RaycastHit hit;
        Ray streamRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        Physics.Raycast(streamRay, out hit);
        target = hit.collider.gameObject;

        if (target.CompareTag("Dirty"))
        {            
            Dirty dirty = target.GetComponent<Dirty>();
            dirty.beingCleaned = true;
            if (dirty.dirt <= 0)
            {
                dirty.enabled = false;                
            }
            if (dirty.enabled)
            {
                bubbleSpray.transform.position = hit.point;
            }
            else
            {
                bubbleSpray.SetActive(false);
            }
        }
        else
        {
            target = null;
            bubbleSpray.SetActive(false);
        }

        distance = hit.distance;
        Vector3[] positions = new Vector3[2];
        positions[0] = Vector3.zero;
        Vector3 targetPosition = new Vector3(0, distance * distanceFactor, 0);
        positions[1] = targetPosition;
        
        waterLine.SetPositions(positions);
    }
}
