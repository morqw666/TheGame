using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    [SerializeField] private PodiumMover podiumMover;
    //не Transform а (создать класс Castle (тут здоровье базы должно быть))
    [SerializeField] private Transform shootingPosition;
    public void FireBullets()
    {
        var heroes = _podiums
            .Where(item => item.GetCard() != null)
            .Select(item => item.GetCard())
            .Select(item => item.Hero);

        foreach (var hero in heroes)
        {
            if(hero != null)
                hero.ShootAt(shootingPosition);
        }
    }
    public bool TryTakeCard(Card card)
    {
        var selectionManager = FindObjectOfType<SelectionManager>();
        var podium = selectionManager.GetPodium();
        if (podium != null && podium.IsEmpty())
        {
            podium.SetCard(card);
            card.Init();
            CardMerger.TryMergeCards(_podiums);
            return true;
        } 
        if (IsAllPodiumsFull())
        {
            if (CardMerger.TryMergeCard(card, _podiums))
            {
                CardMerger.TryMergeCards(_podiums);
                card.Init();
                return true;
            }
        }
        //for (int i = 0; i < _podiums.Count; i++)
        //{
        //    if (_podiums[i].IsEmpty())
        //    {
        //        _podiums[i].SetCard(card);
        //        TryMergeCards();
        //        return true;
        //    } 
        //    else if (IsAllPodiumsFull())
        //    {
        //        if (TryMergeCard(card))
        //        {
        //            TryMergeCards();
        //            return true;
        //        }
        //    }
        //}
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
    public bool SetCardOnPodium(Card card)
    {
        var selectionManager = FindObjectOfType<SelectionManager>();
        var podium = selectionManager.GetPodium();
        if (podium != null && podium.IsEmpty())
        {
            podium.SetCard(card);
            CardMerger.TryMergeCards(_podiums);
            return true;
        }
        return false;
    }
    public void PodiumsUp()
    {
        podiumMover.MoveUp(_podiums);
    }
    public void PodiumsDown()
    {
        podiumMover.MoveDown(_podiums);
    }
    public void DiscardCard(Podium podium)
    {
        if (!podium.IsEmpty())
        {
            podium.Destroy();
        }
    }
}