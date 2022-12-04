using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUIT : MonoBehaviour
{
    public void QuitGame()
    {
        PlayerPrefs.SetInt("act",0);
        Application.Quit();
    }
}
