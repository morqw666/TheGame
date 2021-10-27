using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Text levelLabel;
    [SerializeField] private Transform heroPosition;
    [SerializeField] private List<Hero> _prefabs;
    public Hero Hero;
    [SerializeField] private int _level = 1;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            levelLabel.text = Level.ToString();
            RegenerateHeroModel();
        }
    }

    public void Init()
    {
        RegenerateHeroModel();
    }

    private void RegenerateHeroModel()
    {
        if (Hero != null)
        {
            Destroy(Hero.gameObject);
        }
        Hero = Instantiate(_prefabs[_level - 1]);
        Hero.transform.position = heroPosition.position;
        Hero.transform.SetParent(heroPosition);
    }
    public void SetMaterial(ColoredMaterial material)
    {
        _renderer.sharedMaterial = material.Material;
    }
    public Material GetMaterial()
    {
        return _renderer.sharedMaterial;
    }
}
