using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Card _card;
    private Podium _podium;
    private bool isFromDeck;
    private Podium _startPodium;
    private Transform _shootingPosition;
    public Transform ShootingPosition
    {
        get => _shootingPosition;
        set
        {
            _shootingPosition = value;
        }
    }
    public Podium GetPodium()
    {
        return _podium;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if (hit.transform.TryGetComponent(out _podium))
                {
                    if (_card == null)
                    {
                        _card = _podium.GetCard();
                        _startPodium = _podium;
                        var deck = FindObjectOfType<Deck>();
                        isFromDeck = deck.IsPodiumFromDeck(_podium);
                        _podium.Clear();
                    }    
                }
                if (_card != null)
                {
                    var position = hit.point;
                    _card.transform.position = new Vector3(position.x, 0.75f, position.z);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            var deck = FindObjectOfType<Deck>();
            if (_podium != null)
            {
                if (isFromDeck)
                {
                    var lastFromDeck = deck.IsPodiumFromDeck(_podium);
                    if (_podium.IsEmpty())
                    {
                        if(!lastFromDeck)
                        {
                            deck.TakeCard(_card);
                            _card.SetHero(_shootingPosition);
                            var hero = FindObjectOfType<Hero>();
                            hero.FireBullet();
                        } 
                        else
                            deck.ReturnCard(_card);
                    }
                    else
                    {
                        if(!deck.TakeCard(_card))
                        {
                            deck.ReturnCard(_card);
                            return;
                        }
                        var hero = FindObjectOfType<Hero>();
                        hero.FireBullet();
                    }
                }    
                else
                {
                    if (!deck.IsPodiumFromDeck(_podium))
                    {
                        _startPodium.SetCard(_podium.GetCard());
                        _podium.SetCard(_card);
                    }
                    else
                    {
                        if (_startPodium != null)
                            _startPodium.SetCard(_card);
                    }
                }      
            }
            else
            {
                if(_startPodium != null)
                    _startPodium.SetCard(_card);
            }
            _card = null;
            _podium = null;
            _startPodium = null;
        }
    }
}
