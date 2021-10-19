using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Podium : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    private Card spawnedCard;

    public void PodiumUp(Podium podium, Card card)
    {
        var pos = podium.transform.position;
        podium.transform.position = new Vector3(pos.x, pos.y + 0.45f, pos.z);
        if (card != null)
        {
            var cardpos = card.transform.position;
            card.transform.position = new Vector3(cardpos.x, cardpos.y + 0.45f, cardpos.z);
        }
    }
    public void PodiumDown(Podium podium, Card card)
    {
        var pos = podium.transform.position;
        podium.transform.position = new Vector3(pos.x, pos.y - 0.45f, pos.z);
        if (card != null)
        {
            var cardpos = card.transform.position;
            card.transform.position = new Vector3(cardpos.x, cardpos.y - 0.45f, cardpos.z);
        }
    }
    public bool IsEmpty()
    {
        return spawnedCard == null;
    }

    public void SetCard(Card card)
    {
        card.transform.position = spawn.position;
        spawnedCard = card;
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
