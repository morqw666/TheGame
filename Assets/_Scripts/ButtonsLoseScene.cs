using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsLoseScene : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private Text winner;
    //private void Start()
    //{
    //    if (playerManager.winner != null)
    //    {
    //        winner.text = winner.ToString() + "\nWin";
    //    } 
    //    else
    //    {
    //        winner.text = "Draws";
    //    }
    //}
    public void ButtoneReplay()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtoneHome()
    {

    }
}
