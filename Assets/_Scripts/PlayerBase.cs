using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public Text HealthPlayer1;
    [SerializeField] public Text HealthPlayer2;
    private int healthPlayer1 = 200;
    private int healthPlayer2 = 200;
    private void Start ()
    {
        HealthPlayer1.text = healthPlayer1.ToString();
        HealthPlayer2.text = healthPlayer2.ToString();
    }
    public void TakeDamageToPlayer1(int damage)
    {
        healthPlayer1 -= damage;
        HealthPlayer1.text = healthPlayer1.ToString();
        GameOver();
    }
    public void TakeDamageToPlayer2(int damage)
    {
        healthPlayer2 -= damage;
        HealthPlayer2.text = healthPlayer2.ToString();
        GameOver();
    }
    private void GameOver()
    {
        if (healthPlayer1 <= 0 || healthPlayer2 <= 0)
        {
            if (healthPlayer1 > healthPlayer2)
                Lose.winner = "player1";
            else if (healthPlayer2 > healthPlayer1)
                Lose.winner = "player2";
            else
            SceneManager.LoadScene(2);
        }
    }
}
