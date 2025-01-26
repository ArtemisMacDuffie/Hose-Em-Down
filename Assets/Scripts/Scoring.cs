using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public GameObject[] paintingArray;
    public GameObject paintingText;
    public GameObject[] dogArray;
    public GameObject dogText;
    public GameObject[] clownArray;
    public GameObject clownText;
    public ScoreKeeping scorekeeper;
    public GameObject reticle;

    private List<GameObject> paintings;
    private List<GameObject> dogs;
    private List<GameObject> clowns;

    private void Awake()
    {
        paintings = new List<GameObject>();
        dogs = new List<GameObject>();
        clowns = new List<GameObject>();

        for (int i = 0; i < paintingArray.Length; i++)
        {
            paintings.Add(paintingArray[i]);
        }

        for (int i = 0; i < dogArray.Length; i++)
        {
            dogs.Add(dogArray[i]);
        }

        for (int i = 0; i < clownArray.Length; i++)
        {
            clowns.Add(clownArray[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeScores();
    }

    private void ChangeScores()
    {
        scorekeeper.ScoreChange(paintingText, paintings.Count);
        scorekeeper.ScoreChange(dogText, dogs.Count);
        scorekeeper.ScoreChange(clownText, clowns.Count);
    }

    public void RemoveGameObject(GameObject go)
    {
        if (go == null) return;
        else if (paintings.Contains(go))
        {
            paintings.Remove(go);
        }
        else if (dogs.Contains(go))
        {
            dogs.Remove(go);
        }
        else if (clowns.Contains(go))
        {
            clowns.Remove(go);
        }
        ChangeScores();
        CheckScores();
    }

    private void CheckScores()
    {
        if (paintings.Count == 0 && dogs.Count == 0 && clowns.Count == 0)
        {
            reticle.GetComponent<TextMeshProUGUI>().text = "Congrats! Everything is clean!";
        }
    }
}
