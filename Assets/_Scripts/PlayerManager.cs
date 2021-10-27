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
    [SerializeField] private PlayerBase playerBase;
    private PlayerDeck current;
    public static int GameMode = 1;
    private void Start()
    {
        current = player1;
        player1.PodiumsUp();
        player2.PodiumsDown();
    }
    public void TakeDamage(int damage)
    {
        if (current == player2)
            playerBase.TakeDamageToPlayer2(damage);
        else if (current == player1)
            playerBase.TakeDamageToPlayer1(damage);
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
            return true;
        return false;
    }
}
