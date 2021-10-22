using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ButtonePlayPvP()
    {
        PlayerManager.GameMode = 1;
        SceneManager.LoadScene(1);
    }
    public void ButtonePlayPvE()
    {
        PlayerManager.GameMode = 2;
        SceneManager.LoadScene(1);
    }
}
