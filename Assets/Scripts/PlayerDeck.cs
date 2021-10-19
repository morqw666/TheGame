using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    private readonly List<int> DamageAmount = new List<int>(){1,3,8,20};
    public bool TryTakeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (_podiums[i].IsEmpty())
            {
                _podiums[i].SetCard(card);
                TryMergeCards();
                return true;
            }
        }
        return false;
    }
    private void TryMergeCards()
    {
        while (CardMerge()){}
    }
    private bool CardMerge()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            if (!podium.IsEmpty())
            {
                var card = podium.GetCard();
                for (int j = 0; j < _podiums.Count; j++)
                {
                    if (i != j && !_podiums[j].IsEmpty()) {
                        var card2 = _podiums[j].GetCard();
                        if (card2.GetMaterial() == card.GetMaterial() && card2.Level == card.Level)
                        {
                            card.Level++;
                            _podiums[j].Destroy();
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public void PodiumsUp()
    {
        for (int i = 0; i < _podiums.Count; i ++)
        {
            var podium = _podiums[i];
            if (!podium.IsEmpty())
            {
                var card = podium.GetCard();
                podium.PodiumUp(podium, card);
            }
            else
            {
                podium.PodiumUp(podium, null);
            }
        }
    }
    public void PodiumsDown()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            if (!podium.IsEmpty())
            {
                var card = podium.GetCard();
                podium.PodiumDown(podium, card);
            }
            else
            {
                podium.PodiumDown(podium, null);
            }
        }
    }
    public void DiscardCard(Podium podium)
    {
        if (!podium.IsEmpty())
        {
            podium.Destroy();
        }
    }
    public int SumDamage()
    {
        int sumDamage = 0;
        for (int i = 0; i < _podiums.Count; i++)
        {
            if (!_podiums[i].IsEmpty())
            {
                sumDamage += DamageAmount[_podiums[i].GetCard().Level - 1];
            }
        }
        return sumDamage;
    }
}
