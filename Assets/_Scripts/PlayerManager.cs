using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerDeck player1, player2;
    [SerializeField] private Deck deck;
    private PlayerDeck current;
    public PlayerDeck winner;
    [SerializeField] public Text HealthPlayer1;
    [SerializeField] public Text HealthPlayer2;
    //переезжает в Castle см. PlayerDeck
    private int healthPlayer1 = 200;
    private int healthPlayer2 = 200;
    public static int GameMode = 1;

    private void Start()
    {
        current = player1;
        player1.PodiumsUp();
        player2.PodiumsDown();
        HealthPlayer1.text = healthPlayer1.ToString();
        HealthPlayer2.text = healthPlayer2.ToString();
    }
    public void TakeDamage(int damage)
    {
        if (current == player2)
        {
            healthPlayer2 -= damage;
            HealthPlayer2.text = healthPlayer2.ToString();
        }
        else if (current == player1)
        {
            healthPlayer1 -= damage;
            HealthPlayer1.text = healthPlayer1.ToString();
        }
        if (healthPlayer1 <= 0 || healthPlayer2 <= 0)
        {
            if (healthPlayer1 > healthPlayer2)
                Lose.winner = "player1";
            else if (healthPlayer2 > healthPlayer1)
                Lose.winner = "player2";
            else
                winner = null;
            SceneManager.LoadScene(2);
        }
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
                deck.InvokeBotTakeCard();
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
        {
            return true;
        }
        return false;
    }
}
