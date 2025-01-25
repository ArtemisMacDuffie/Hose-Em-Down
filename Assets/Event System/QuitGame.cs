using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("Quit button");
        Application.Quit();
    }
}
