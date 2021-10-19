using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerDeck player1, player2;
    private PlayerDeck current;
    [SerializeField] public Text HealthPlayer1;
    [SerializeField] public Text HealthPlayer2;
    private int healthPlayer1 = 200;
    private int healthPlayer2 = 200;
    private void Start()
    {
        current = player1;
        current.PodiumsUp();
        HealthPlayer1.text = healthPlayer1.ToString();
        HealthPlayer2.text = healthPlayer2.ToString();
    }
    public void EndTurn()
    {
        healthPlayer1 -= player2.SumDamage();
        healthPlayer2 -= player1.SumDamage();
        HealthPlayer1.text = healthPlayer1.ToString();
        HealthPlayer2.text = healthPlayer2.ToString();
    }
    public void ChangePlayer()
    {
        if (current == player1)
        {
            player1.PodiumsDown();
            player2.PodiumsUp();
            current = player2;
        } else if (current == player2)
        {
            player2.PodiumsDown();
            player1.PodiumsUp();
            EndTurn();
            current = player1;
        }
    }
    public bool TryTakeCard(Card card)
    {
        bool Result = current.TryTakeCard(card);
        ChangePlayer();
        return Result;
    }
}
