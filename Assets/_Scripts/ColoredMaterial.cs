using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardColor
{
    blue, red, yellow, green
}
[System.Serializable]
public class ColoredMaterial
{
    public Material Material;
    public CardColor Color;
}