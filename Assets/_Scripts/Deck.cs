using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    [SerializeField] private Card _prefab;
    [SerializeField] private List<ColoredMaterial> _materials;
    [SerializeField] private int _CardDeckCount = 60;
    private List<Card> CardDeck = new List<Card>();
    [SerializeField] private Text CardsCountLabel;
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        FillDeck();
        FillEmptyPodiums();
    }
    private void FillDeck()
    {
        int setOneColor = (_CardDeckCount / _materials.Count);
        for (int j = 0; j < setOneColor; j++)
        {
            for (int k = 0; k < _materials.Count; k++)
            {
                var card = Instantiate(_prefab);
                card.SetMaterial(_materials[k]);
                card.gameObject.SetActive(false);
                CardDeck.Add(card);
            }  
        }
    }
    private void FillEmptyPodiums()
    {
        if (CardDeck.Count == 0)
        {
            return;
        }
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty()) 
            {
                var card = CardDeck[UnityEngine.Random.Range(0, CardDeck.Count)];
                CardDeck.Remove(card);
                CardsCountLabel.text = CardDeck.Count.ToString();
                card.gameObject.SetActive(true);
                _podiums[i].SetCard(card);
            }
        }
    }
    public void InvokeBotTakeCard()
    {
        Invoke("BotTakeCard", 1.5f);
    }
    public void BotTakeCard()
    {
        var podium = _podiums[UnityEngine.Random.Range(0, _podiums.Count)];
        var card = podium.GetCard();
        TakeCard(card);
    }
    public void ReturnCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty())
            {
                _podiums[i].SetCard(card);
            }
        }
    }
    public bool IsPodiumFromDeck(Podium podium)
    {
        if (_podiums.Contains(podium)) 
        {
            return true;
        }
        return false;
    }
    public bool TakeCard(Card card)
    {
        if (playerManager.TryTakeCard(card))
        {
            playerManager.ChangePlayer();
        }
        else
        {
            return false;
        }
        FillEmptyPodiums();
        return true;
    }
    public void ButtoneSkipTurn()
    {
        playerManager.ChangePlayer();
    }
}
