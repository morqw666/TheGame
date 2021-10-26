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
    private Hero spawnedHero;
    private int _level = 1;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            SetHero(null);
            levelLabel.text = Level.ToString();
        }
    }
    public void SetHero(Transform position)
    {
        if (spawnedHero != null)
        {
            Destroy(spawnedHero.gameObject);
        }
        spawnedHero = Instantiate(_prefabs[_level - 1]);
        spawnedHero.transform.position = heroPosition.position;
        spawnedHero.transform.SetParent(heroPosition);
        spawnedHero.ShootingPosition = position;
        spawnedHero.Damage = _level - 1;
        for (int i = 0; i < _materials.Count; i++)
        {
            if (this._renderer.sharedMaterial == _materials[i].Material)
            {
                spawnedHero.SetMaterial(_materials[i]);
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
