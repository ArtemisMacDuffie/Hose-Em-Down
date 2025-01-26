using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeping : MonoBehaviour
{
    public void ScoreChange(GameObject text, int remaining)
    {
        text.GetComponent<TextMeshProUGUI>().text = remaining.ToString();
    }
}
