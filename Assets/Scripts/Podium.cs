using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //Destroy(spawnedCard.gameObject);
            spawnedCard = null;
        }
    }
    public void Destroy()
    {
        Destroy(spawnedCard.gameObject);
        spawnedCard = null;
    }
}
