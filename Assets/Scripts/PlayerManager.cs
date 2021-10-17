using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerDeck player1, player2;
    private PlayerDeck current;
    private void Start()
    {
        current = player1;
    }
    public bool TryTakeCard(Card card)
    {
        bool Result = current.TryTakeCard(card);
        if (current == player1)
        {
            current = player2;
        } else if (current == player2)
        {
            current = player1;
        }
        return Result;
    }
}
