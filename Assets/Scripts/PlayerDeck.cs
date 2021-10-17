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
    private void Start()
    {
        Health.text = health.ToString();
    }
    public bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var cardOnPodium = _podiums[i].GetCard();
            if (!_podiums[i].IsEmpty() && cardOnPodium.GetMaterial() == card.GetMaterial() && cardOnPodium.level < 4) //_podiums[i].Contains(card)
            {
                card.level = cardOnPodium.level + 1;
                _podiums[i].CardLevel.text = card.level.ToString();
                _podiums[i].Destroy();
                PlayerCardDeck.Remove(cardOnPodium);
                PlayerCardDeck.Add(card);
                _podiums[i].SetCard(card);
                return true;
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
}
