using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    [SerializeField] public Text Health;
    private int health = 200;
    private List<Card> PlayerCardDeck = new List<Card>();
    private Renderer _renderer;
    private void Start()
    {
        Health.text = health.ToString();
    }
    public bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (!_podiums[i].IsEmpty())
            {
                var cardOnPodium = _podiums[i].GetCard();
                if (IsPodiumsContainLevelTwo())
                {
                    var cardLvlTwo = CardLevelTwo();
                    if (cardLvlTwo.GetMaterial() == cardOnPodium.GetMaterial() && cardLvlTwo.GetMaterial() == card.GetMaterial() && cardOnPodium.level < 2 && IsEmptyPodium())
                    {
                        card.level = 3;
                        _podiums[i].CardLevel.text = card.level.ToString();
                        _podiums[i].Destroy();
                        var podiumCardLevelTwo = WhatPodiumContainLevelTwo(cardLvlTwo);
                        podiumCardLevelTwo.Destroy();
                        podiumCardLevelTwo.CardLevel.text = " ";
                        PlayerCardDeck.Remove(cardLvlTwo);
                        PlayerCardDeck.Remove(cardOnPodium);
                        PlayerCardDeck.Add(card);
                        _podiums[i].SetCard(card);
                        return true;
                    }
                }
                if (cardOnPodium.GetMaterial() == card.GetMaterial() && cardOnPodium.level < 2 && IsEmptyPodium())
                {
                    card.level = 2;
                    _podiums[i].CardLevel.text = card.level.ToString();
                    _podiums[i].Destroy();
                    PlayerCardDeck.Remove(cardOnPodium);
                    PlayerCardDeck.Add(card);
                    _podiums[i].SetCard(card);
                    return true;
                }
            }
            if (_podiums[i].IsEmpty())
            {
                PlayerCardDeck.Add(card);
                _podiums[i].SetCard(card);
                return true;
            }
        }
        return false;
    }
    private bool IsPodiumsContainLevelTwo()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            try
            {
                var card = _podiums[i].GetCard();
                if (card.level == 2)
                {
                    return true;
                }
            } catch (NullReferenceException) {
                continue;
            }
            
        }
        return false;
    }
    private Card CardLevelTwo()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var card = _podiums[i].GetCard();
            if (card.level == 2)
            {
                return card;
            }
        }
        return null;
    }
    private Podium WhatPodiumContainLevelTwo(Card cardLvlTwo)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].GetCard() == cardLvlTwo)
            {
                return _podiums[i];
            }
        }
        return null;
    }
    private bool IsEmptyPodium()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty())
            {
                return true;
            }
        }
        return false;
    }
}
