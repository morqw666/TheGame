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
    public bool TryTakeCard(Card card)
    {
        bool Result = current.TryTakeCard(card);
        if (current == player1)
        {
            current = player2;
        } else if (current == player2)
        {
            EndTurn();
            current = player1;
        }
        return Result;
    }
}
