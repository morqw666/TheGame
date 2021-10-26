using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private List<Podium> _podiums;
    //не Transform а (создать класс Castle (тут здоровье базы должно быть))
    [SerializeField] private Transform shootingPosition;

    //в другой скрипт PodiumMover (Методы MoveUp и MoveDown)
    [SerializeField] private Transform podiumsPosUp;
    [SerializeField] private Transform podiumsPosDown;
    private float _targetHeight;
    private float _speed = 0.8f;
    /// ////////////////
    //private readonly List<int> DamageAmount = new List<int>(){1,3,8,20};
    //private void ShootingPosition()
    //{
    //    var selectionManager = FindObjectOfType<SelectionManager>();
    //    selectionManager.ShootingPosition = shootingPosition;
    //}

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
        //ShootingPosition();
        var selectionManager = FindObjectOfType<SelectionManager>();
        var podium = selectionManager.GetPodium();
        if (podium != null && podium.IsEmpty())
        {
            podium.SetCard(card);
            card.Init();
            TryMergeCards();
            return true;
        } 
        if (IsAllPodiumsFull())
        {
            if (TryMergeCard(card))
            {
                TryMergeCards();
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
    //нужен отдельный класс для мержа
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
    public bool SetCardOnPodium(Card card)
    {
        var selectionManager = FindObjectOfType<SelectionManager>();
        var podium = selectionManager.GetPodium();
        if (podium != null && podium.IsEmpty())
        {
            podium.SetCard(card);
            TryMergeCards();
            return true;
        }
        return false;
    }
    //в скрипт PodiumModer
    private void Update()
    {
        MovePodiums();
    }

    private void MovePodiums()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            var pos = podium.transform.position;
            var position = new Vector3(pos.x, _targetHeight, pos.z);
            podium.transform.position = Vector3.MoveTowards(pos, position, _speed * Time.deltaTime);
        }
    }

    public void PodiumsUp()
    {
        _targetHeight = podiumsPosUp.position.y;
        CollidersEnabled(true);
    }
    public void PodiumsDown()
    {
        _targetHeight = podiumsPosDown.position.y;
        CollidersEnabled(false);
    }
    /// 
    private void CollidersEnabled(bool option)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            var colider = podium.GetComponent<Collider>();
            colider.enabled = option;
        }
    }
    public void DiscardCard(Podium podium)
    {
        if (!podium.IsEmpty())
        {
            podium.Destroy();
        }
    }
    //public int SumDamage()
    //{
    //    int sumDamage = 0;
    //    for (int i = 0; i < _podiums.Count; i++)
    //    {
    //        if (!_podiums[i].IsEmpty())
    //        {
    //            sumDamage += DamageAmount[_podiums[i].GetCard().Level - 1];
    //        }
    //    }
    //    return sumDamage;
    //}
}

public static class CardMerger
{
    public static void MergeCards(List<Podium> podiums)
    {

    }
}