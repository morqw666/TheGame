using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    private List<Card> PlayerCardDeck = new List<Card>();
    public bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (!_podiums[i].IsEmpty() && IsEmptyPodium())
            {
                var cardOnPodium = _podiums[i].GetCard();
                if (IsPodiumsContainLevelThree() && IsPodiumsContainLevelTwo())
                {
                    var cardLvlTwo = CardLevelTwo();
                    if (AnotherCardLevelTwo(cardLvlTwo) != null)
                    {
                        var anotherCardLvlTwo = AnotherCardLevelTwo(cardLvlTwo);
                        if (card.GetMaterial() == anotherCardLvlTwo.GetMaterial())
                        {
                            cardLvlTwo = anotherCardLvlTwo;
                        }
                    }
                    var cardLvlThree = CardLevelThree();
                    if (cardLvlTwo.GetMaterial() == cardOnPodium.GetMaterial() && cardLvlTwo.GetMaterial() == card.GetMaterial() && cardLvlTwo.GetMaterial() == cardLvlThree.GetMaterial() && cardOnPodium.level < 2)
                    {
                        card.level = 4;
                        _podiums[i].CardLevel.text = card.level.ToString();
                        _podiums[i].Destroy();
                        var podiumCardLevelTwo = WhatPodiumContainLevelTwo(cardLvlTwo);
                        podiumCardLevelTwo.Destroy();
                        podiumCardLevelTwo.CardLevel.text = " ";
                        var podiumCardLevelThree = WhatPodiumContainLevelThree(cardLvlThree);
                        podiumCardLevelThree.Destroy();
                        podiumCardLevelThree.CardLevel.text = " ";
                        PlayerCardDeck.Remove(cardLvlTwo);
                        PlayerCardDeck.Remove(cardLvlThree);
                        PlayerCardDeck.Remove(cardOnPodium);
                        PlayerCardDeck.Add(card);
                        _podiums[i].SetCard(card);
                        return true;
                    }
                    
                }
                if (IsPodiumsContainLevelTwo())
                {
                    var cardLvlTwo = CardLevelTwo();
                    if (AnotherCardLevelTwo(cardLvlTwo) != null)
                    {
                        var anotherCardLvlTwo = AnotherCardLevelTwo(cardLvlTwo);
                        if (card.GetMaterial() == anotherCardLvlTwo.GetMaterial())
                        {
                            cardLvlTwo = anotherCardLvlTwo;
                        }
                    }
                    if (cardLvlTwo.GetMaterial() == cardOnPodium.GetMaterial() && cardLvlTwo.GetMaterial() == card.GetMaterial() && cardOnPodium.level < 2)
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
                if (cardOnPodium.GetMaterial() == card.GetMaterial() && cardOnPodium.level < 2)
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
    private bool IsPodiumsContainLevelThree()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            try
            {
                var card = _podiums[i].GetCard();
                if (card.level == 3)
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
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
    private Card AnotherCardLevelTwo(Card anotherCardLvlTwo)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var card = _podiums[i].GetCard();
            try
            {
                if (card.level == 2 && card.GetMaterial() != anotherCardLvlTwo.GetMaterial())
                {
                    return card;
                }
            } catch (NullReferenceException)
            {
                continue;
            }
        }
        return null;
    }
    private Card CardLevelThree()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            try
            {
                var card = _podiums[i].GetCard();
                if (card.level == 3)
                {
                    return card;
                }
            } catch (NullReferenceException)
            {
                continue;
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
    private Podium WhatPodiumContainLevelThree(Card cardLvlThree)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].GetCard() == cardLvlThree)
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
    public int SumDamage()
    {
        int sumDamage = 0;
        for (int i = 0; i < _podiums.Count; i++)
        {
            try
            {
                int damage = 0;
                if (_podiums[i].GetCard().level == 1)
                {
                    damage = 1;
                } else if (_podiums[i].GetCard().level == 2)
                {
                    damage = 3;
                } else if (_podiums[i].GetCard().level == 3)
                {
                    damage = 8;
                } else if (_podiums[i].GetCard().level == 4)
                {
                    damage = 20;
                }
                sumDamage += damage;
            }
            catch (NullReferenceException)
            {
                continue;
            }
        }
        return sumDamage;
    }
}
