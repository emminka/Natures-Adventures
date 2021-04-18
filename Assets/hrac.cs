using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hrac : MonoBehaviour
{
    public motylik motylik;
    public Hra Hra;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        motylik.GameOver();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hra.score++;
        motylik.ScoreText.text = Hra.score.ToString(); //zmena score
        Debug.Log(Hra.score);
    }

    public void Zastav()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }
}
