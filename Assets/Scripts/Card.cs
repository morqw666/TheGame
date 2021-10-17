using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    public void SetMaterial(ColoredMaterial material)
    {
        _renderer.sharedMaterial = material.Material;
    }
    public Material GetMaterial()
    {
        return _renderer.sharedMaterial;
    }
    private void OnMouseDown()
    {
        var deck = FindObjectOfType<Deck>();
        deck.TakeCard(this);
    }
}
