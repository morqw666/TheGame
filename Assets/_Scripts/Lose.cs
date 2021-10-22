using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] private Text Winner;
    public static string winner;
    private void Start()
    {
        if (winner != null)
            Winner.text = winner + "\nWin";
        else
            Winner.text = "Draws";
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
