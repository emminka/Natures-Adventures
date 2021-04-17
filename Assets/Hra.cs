using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hra : MonoBehaviour
{
    public motylik motylik;

    public GameObject pozadie1, pozadie2, hrac, pipeka;
    [Range(0, 10f)]
    public float rychlost;
    private float vzdialenost = 0;
    private float vzdialenostOdPoslednejPipeky = 20;
    public List<GameObject> Pipeky;

    void Start()
    {
        Pipeky = new List<GameObject>();
        //hrac.transform.position = new Vector3(-5f, 2.5f, 0f);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("skoc");

            if (hrac.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                hrac.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            hrac.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
        }

        if ((hrac.transform.position.y > 4.5f) || (hrac.transform.position.y < -4.5f))
        {
            motylik.GameOver();
        }
        

        pozadie1.transform.position = pozadie1.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
        pozadie2.transform.position = pozadie2.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);

        vzdialenost += rychlost * Time.deltaTime;
        vzdialenostOdPoslednejPipeky -= rychlost * Time.deltaTime;

        foreach (GameObject pipeka in Pipeky)
        {
            pipeka.transform.position = pipeka.transform.position - new Vector3(rychlost * Time.deltaTime, 0, 0);
        }

        if (vzdialenostOdPoslednejPipeky <= 0)
        {
            float nahodnyOffset = Random.value * 2 - 1;

            GameObject novaPipeka1 = Instantiate(pipeka, new Vector3(hrac.transform.position.x + 15, 5 + nahodnyOffset, -5), Quaternion.Euler(0, 0, 0));
            GameObject novaPipeka2 = Instantiate(pipeka, new Vector3(hrac.transform.position.x + 15, -4 + nahodnyOffset, -5), Quaternion.Euler(0, 0, 180));
            Pipeky.Add(novaPipeka1);
            Pipeky.Add(novaPipeka2);

            vzdialenostOdPoslednejPipeky = 20;
        }

        if (pozadie1.transform.position.x < -21)
        {
            pozadie1.transform.position = pozadie1.transform.position + new Vector3(52, 0, 0);
        }

        if (pozadie2.transform.position.x < -21)
        {
            pozadie2.transform.position = pozadie2.transform.position + new Vector3(52, 0, 0);
        }
    }
}
