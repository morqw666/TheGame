using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMerger : MonoBehaviour
{
    private static List<Podium> _podiums;
    public static bool TryMergeCard(Card card, List<Podium> podiums)
    {
        _podiums = podiums;
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
    public static void TryMergeCards(List<Podium> podiums)
    {
        _podiums = podiums;
        while (CardMerge()) { }
    }
    private static bool CardMerge()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            if (!podium.IsEmpty())
            {
                var card = podium.GetCard();
                for (int j = 0; j < _podiums.Count; j++)
                {
                    if (i != j && !_podiums[j].IsEmpty())
                    {
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
}
