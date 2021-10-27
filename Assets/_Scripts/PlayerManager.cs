using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerDeck player1, player2;
    [SerializeField] private Bot bot;
    [SerializeField] private Text HealthBase1, HealthBase2;
    private PlayerDeck current;
    public static int GameMode = 1;
    private void Start()
    {
        current = player1;
        player1.PodiumsUp();
        player2.PodiumsDown();
    }
    public void ChangePlayer()
    {
        current.FireBullets();
        if (current == player1)
        {
            player1.PodiumsDown();
            player2.PodiumsUp();
            current = player2;
            if (GameMode == 2)
            {
                bot.InvokeTakeCard();
            }
        } else if (current == player2)
        {
            player2.PodiumsDown();
            player1.PodiumsUp();
            current = player1;
        }
    }
    public bool TryTakeCard(Card card)
    {
        bool Result = current.TryTakeCard(card);
        return Result;
    }
    public bool CurrentPlayer()
    {
        if (current == player1)
            return true;
        return false;
    }
    public void GameOver()
    {
        var health1 = Convert.ToInt32(HealthBase1.text);
        var health2 = Convert.ToInt32(HealthBase2.text);
        if (health1 <= 0 || health2 <= 0)
        {
            if (health1 > health2)
                Lose.winner = "player1";
            else if (health2 > health1)
                Lose.winner = "player2";
            SceneManager.LoadScene(2);
        }
    }
}
