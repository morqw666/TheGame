using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private bool _cardThrowFromDeck = false;
    private Card _card;
    public void CardThrowFromDeck(Card card)
    {
        _card = card;
        _cardThrowFromDeck = true;
    }
    void Update()
    {
        var card = _card;
        if (_cardThrowFromDeck == true)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                //var selection = hit.transform;
                //var card = selection.GetComponent<Card>();
                if (card != null)
                {
                    var position = hit.point;
                    card.transform.position = new Vector3(position.x, 0.75f, position.z);
                }
            }
        }
        _cardThrowFromDeck = false;
    }
}
