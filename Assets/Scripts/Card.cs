using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Text levelLabel;
    private int _level = 1;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            levelLabel.text = Level.ToString();
        }
    }
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
