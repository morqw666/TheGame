using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private PlayerManager playerManager;
    public void ButtonePlayPvP()
    {
        playerManager.GameMode = 1;
        SceneManager.LoadScene(1);
    }
    public void ButtonePlayPvE()
    {
        playerManager.GameMode = 2;
        SceneManager.LoadScene(1);
    }
    public void ButtoneReplay()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtoneHome()
    {
        SceneManager.LoadScene(0);
    }
}
