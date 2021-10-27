using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private PlayerDeck playerDeck;
    [SerializeField] private PlayerManager playerManager;
    private List<Podium> _podiumsOnDeck;
    private List<Podium> _podiums;
    private void Start()
    {
        _podiumsOnDeck = deck._podiums;
        _podiums = playerDeck._podiums;
    }
    public void InvokeTakeCard()
    {
        Invoke("TakeCard", 1.5f);
    }
    private void TakeCard()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            if (podium.GetCard() != null)
            {
                var card = podium.GetCard();
                for (int j = 0; j < _podiumsOnDeck.Count; j++)
                {
                    var podiumDeck = _podiumsOnDeck[i];
                    var cardDeck = podiumDeck.GetCard();
                    if (card.GetMaterial() == cardDeck.GetMaterial() && card.Level == cardDeck.Level)  
                    {
                        if (IfTryTakeCard(card, podiumDeck))
                            return;
                    }
                }
            }
        }
        var podiumRandom = _podiumsOnDeck[Random.Range(0, _podiumsOnDeck.Count)];
        var cardRandom = podiumRandom.GetCard();
        podiumRandom.Clear();
        if (!IfTryTakeCard(cardRandom, podiumRandom))
            playerManager.ChangePlayer();
    }
    private bool IfTryTakeCard(Card card, Podium podium)
    {
        if (TryTakeCard(card))
        {
            podium.Clear();
            deck.FillEmptyPodiums();
            playerManager.ChangePlayer();
            return true;
        }
        else
        {
            deck.ReturnCard(card);
            return false;
        }
    }
    private bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty())
            {
                _podiums[i].SetCard(card);
                card.Init();
                CardMerger.TryMergeCards(_podiums);
                return true;
            }
            else if (IsAllPodiumsFull())
            {
                if (CardMerger.TryMergeCard(card, _podiums))
                {
                    CardMerger.TryMergeCards(_podiums);
                    return true;
                }
            }
        }
        return false;
    }
    private bool IsAllPodiumsFull()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
}
