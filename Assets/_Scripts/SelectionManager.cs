using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private bool _cardThrowFromDeck = false;
    private Card _card;
    private Podium _podium;
    public Podium GetPodium()
    {
        return _podium;
    }
    public void CardThrowFromDeck(Card card)
    {
        _card = card;
        _cardThrowFromDeck = true;
    }
    void Update()
    {
        if (_cardThrowFromDeck == true)
        {
            var card = _card;
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                var position = hit.point;
                card.transform.position = new Vector3(position.x, 0.75f, position.z);
                var selection = hit.transform;
                _podium = selection.GetComponent<Podium>();
            }
        }
        _cardThrowFromDeck = false;
    }
}
