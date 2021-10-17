using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    private List<Card> PlayerCardDeck = new List<Card>();
    public bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var cardOnPodium = _podiums[i].GetCard();
            if (!_podiums[i].IsEmpty() && cardOnPodium.GetMaterial() == card.GetMaterial()) //_podiums[i].Contains(card)
            {
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
