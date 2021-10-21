using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    [SerializeField] private Transform podiumsPosUp;
    [SerializeField] private Transform podiumsPosDown;
    private bool tokenUp = false;
    private bool tokenDown = false;
    private float _speed = 0.8f;
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
            else if (IsAllPodiumsFull() == true)
            {
                if (TryMergeCard(card))
                {
                    TryMergeCards();
                    return true;
                }
            }
        }
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
    private bool TryMergeCard(Card card)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            var card1 = podium.GetCard();
            if (card1.GetMaterial() == card.GetMaterial() && card1.Level == card.Level)
            {
                card.Level++;
                _podiums[i].Destroy();
                _podiums[i].SetCard(card);
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
    private void Update()
    {
        if (tokenUp == true)
        {
            for (int i = 0; i < _podiums.Count; i++)
            {
                var podium = _podiums[i];
                var pos = podium.transform.position;
                podiumsPosUp.transform.position = new Vector3(pos.x, podiumsPosUp.position.y, pos.z);
                podium.transform.position = Vector3.MoveTowards(pos, podiumsPosUp.position, _speed * Time.deltaTime);
                if (!podium.IsEmpty())
                {
                    var card = podium.GetCard();
                    var cardpos = card.transform.position;
                    card.transform.position = cardpos + new Vector3(0, _speed * Time.deltaTime, 0);
                }
                if (pos == podiumsPosUp.position)
                {
                    tokenUp = false;
                }
            }
        }
        if (tokenDown == true)
        {
            for (int i = 0; i < _podiums.Count; i++)
            {
                var podium = _podiums[i];
                var pos = podium.transform.position;
                podiumsPosDown.transform.position = new Vector3(pos.x, podiumsPosDown.position.y, pos.z);
                podium.transform.position = Vector3.MoveTowards(pos, podiumsPosDown.position, _speed * Time.deltaTime);
                if (!podium.IsEmpty())
                {
                    var card = podium.GetCard();
                    var cardpos = card.transform.position;
                    card.transform.position = cardpos - new Vector3(0, _speed * Time.deltaTime, 0);
                }
                if (pos == podiumsPosDown.position)
                {
                    tokenDown = false;
                }
            }
        }
    }
    public void PodiumsUp()
    {
        tokenUp = true;
    }
    public void PodiumsDown()
    {
        tokenDown = true;
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
