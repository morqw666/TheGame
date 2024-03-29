using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Podium : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    private Card spawnedCard;
    public bool IsEmpty()
    {
        return spawnedCard == null;
    }
    public void SetCard(Card card)
    {
        spawnedCard = card;
        if (card != null)
        {
            card.transform.position = spawn.position;
            card.transform.SetParent(spawn);
        }
    }
    public Card GetCard()
    {
        return spawnedCard;
    }
    public bool Contains(Card card)
    {
        return spawnedCard == card;
    }
    public void Clear()
    {
        if (!IsEmpty())
        {
            spawnedCard = null;
        }
    }
    public void Destroy()
    {
        Destroy(spawnedCard.gameObject);
        spawnedCard = null;
    }
    public void ButtoneDiscard()
    {
        var playerDeck = FindObjectOfType<PlayerDeck>();
        playerDeck.DiscardCard(this);
    }
}
