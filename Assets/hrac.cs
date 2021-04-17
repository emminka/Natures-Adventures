using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hrac : MonoBehaviour
{
    public motylik motylik;
    public Hra Hra;

    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        motylik.GameOver();
    }

    public void Zastav()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }
}
