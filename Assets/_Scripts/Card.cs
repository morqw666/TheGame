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
    [SerializeField] private List<ColoredMaterial> _materials;
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
        for (int i = 0; i < _materials.Count; i++)
        {
            if (this._renderer.sharedMaterial == _materials[i].Material)
            {
                Hero.SetMaterial(_materials[i]);
            }
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
}
