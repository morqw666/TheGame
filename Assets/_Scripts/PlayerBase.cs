using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public Text HealthPlayer;
    private int healthPlayer = 2000;
    private void Start()
    {
        HealthPlayer.text = healthPlayer.ToString();
    }
    public void TakeDamage(int damage)
    {
        healthPlayer -= damage;
        HealthPlayer.text = healthPlayer.ToString();
    }
}
