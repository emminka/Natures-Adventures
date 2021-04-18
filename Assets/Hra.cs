using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hra : MonoBehaviour
{
    public motylik motylik;

    public GameObject pozadie1, pozadie2, pozadie3, pozadie4, pozadie5, pozadie6, pozadie7, pozadie8, hrac, hracvcela, pipeka, trigger;
    [Range(0, 10f)]
    public float rychlost;
    private float vzdialenost = 0;
    public float vzdialenostOdPoslednejPipeky = 0;
    public List<GameObject> Pipeky;
    public int pocet_pipok = 0;
    public float posunutie = 0;
    public float score = 0;
    public float typPozadia = 1;
    public float typHraca = 1;

   /*
    * ScoreText.text = 0.ToString();
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, -1f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        Hra.vzdialenostOdPoslednejPipeky = 0;
        Hra.posunutie = 0;
        Hra.pocet_pipok = 0;
        Hra.score = 0;
   */

    void Start()
    {
        Pipeky = new List<GameObject>();
        //hrac.transform.position = new Vector3(-5f, 2.5f, 0f);

    }

    void Update()
    {
        if (typHraca == 1)
        {
            hrac.SetActive(true);
            hracvcela.SetActive(false);
        }
        if (typHraca == 2)
        {
            hrac.SetActive(false);
            hracvcela.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("skoc");

            if (typHraca == 1)
            {
                if (hrac.GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    hrac.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }

                hrac.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            }

            if (typHraca == 2)
            {
                if (hracvcela.GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    hracvcela.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }

                hracvcela.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            }
        }

        if ((hrac.transform.position.y > 4.5f) || (hrac.transform.position.y < -4.5f) || (hracvcela.transform.position.y < -4.5f) || (hracvcela.transform.position.y > 4.5f))
        {
            motylik.GameOver();
        }
        
        if ( typPozadia == 1) {
            pozadie1.SetActive(true);
            pozadie2.SetActive(true);
            pozadie3.SetActive(false);
            pozadie4.SetActive(false);
            pozadie5.SetActive(false);
            pozadie6.SetActive(false);
            pozadie7.SetActive(false);
            pozadie8.SetActive(false);
            pozadie1.transform.position = pozadie1.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
            pozadie2.transform.position = pozadie2.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
        }
        else if (typPozadia == 2)
        {
            pozadie1.SetActive(false);
            pozadie2.SetActive(false);
            pozadie3.SetActive(true);
            pozadie4.SetActive(true);
            pozadie5.SetActive(false);
            pozadie6.SetActive(false);
            pozadie7.SetActive(false);
            pozadie8.SetActive(false);
            pozadie3.transform.position = pozadie3.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
            pozadie4.transform.position = pozadie4.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
        }
        else if (typPozadia == 3)
        {
            pozadie1.SetActive(false);
            pozadie2.SetActive(false);
            pozadie3.SetActive(false);
            pozadie4.SetActive(false);
            pozadie5.SetActive(true);
            pozadie6.SetActive(true);
            pozadie7.SetActive(false);
            pozadie8.SetActive(false);
            pozadie5.transform.position = pozadie5.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
            pozadie6.transform.position = pozadie6.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
        }
        else if (typPozadia == 4)
        {
            pozadie1.SetActive(false);
            pozadie2.SetActive(false);
            pozadie3.SetActive(false);
            pozadie4.SetActive(false);
            pozadie5.SetActive(false);
            pozadie6.SetActive(false);
            pozadie7.SetActive(true);
            pozadie8.SetActive(true);
            pozadie7.transform.position = pozadie7.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
            pozadie8.transform.position = pozadie8.transform.position - new Vector3(rychlost * Time.deltaTime / 2, 0, 0);
        }

        vzdialenost += rychlost * Time.deltaTime;
        vzdialenostOdPoslednejPipeky -= rychlost * Time.deltaTime;

        foreach (GameObject pipeka in Pipeky)
        {
            pipeka.transform.position = pipeka.transform.position - new Vector3(rychlost * Time.deltaTime, 0, 0);
        }

        if (vzdialenostOdPoslednejPipeky <= 0)
        {
            float nahodnyOffset = Random.value * 2 - 1;

            if (typHraca == 1)
            {
                GameObject novyTrigger = Instantiate(trigger, new Vector3(hrac.transform.position.x + 16, 0, -5), Quaternion.Euler(0, 0, 0));
                GameObject novaPipeka1 = Instantiate(pipeka, new Vector3(hrac.transform.position.x + 15, 6 + nahodnyOffset - posunutie, -5), Quaternion.Euler(0, 0, 0));
                GameObject novaPipeka2 = Instantiate(pipeka, new Vector3(hrac.transform.position.x + 15, -5 + nahodnyOffset + posunutie, -5), Quaternion.Euler(0, 0, 180));
                Pipeky.Add(novaPipeka1);
                Pipeky.Add(novaPipeka2);
                Pipeky.Add(novyTrigger);
            }
            if (typHraca == 2)
            {
                GameObject novyTrigger = Instantiate(trigger, new Vector3(hracvcela.transform.position.x + 16, 0, -5), Quaternion.Euler(0, 0, 0));
                GameObject novaPipeka1 = Instantiate(pipeka, new Vector3(hracvcela.transform.position.x + 15, 6 + nahodnyOffset - posunutie, -5), Quaternion.Euler(0, 0, 0));
                GameObject novaPipeka2 = Instantiate(pipeka, new Vector3(hracvcela.transform.position.x + 15, -5 + nahodnyOffset + posunutie, -5), Quaternion.Euler(0, 0, 180));
                Pipeky.Add(novaPipeka1);
                Pipeky.Add(novaPipeka2);
                Pipeky.Add(novyTrigger);
            }





            pocet_pipok += 1;

            vzdialenostOdPoslednejPipeky = 1.75f + 3.5f * Mathf.Exp(-pocet_pipok / 45f);
            posunutie = 14f - 14f * Mathf.Exp(-pocet_pipok / 900f);
            rychlost = 0.6f + 4.4f * Mathf.Exp(pocet_pipok / 150f);
        }

        /* PRVE POZADIE*/
        if (pozadie1.transform.position.x < -21)
        {
            pozadie1.transform.position = pozadie1.transform.position + new Vector3(52, 0, 0);
        }

        if (pozadie2.transform.position.x < -21)
        {
            pozadie2.transform.position = pozadie2.transform.position + new Vector3(52, 0, 0);
        }

        /* DRUHE POZADIE*/
        if (pozadie3.transform.position.x < -19.5)
        {
            pozadie3.transform.position = pozadie3.transform.position + new Vector3(45.78f, 0, 0);
        }

        if (pozadie4.transform.position.x < -19.5)
        {
            pozadie4.transform.position = pozadie4.transform.position + new Vector3(45.78f, 0, 0);
        }

        /* TRETIE POZADIE*/
        if (pozadie5.transform.position.x < -22)
        {
            pozadie5.transform.position = pozadie5.transform.position + new Vector3(56.46f, 0, 0);
        }
        if (pozadie6.transform.position.x < -22)
        {
            pozadie6.transform.position = pozadie6.transform.position + new Vector3(56.46f, 0, 0);
        }
        /* STVRTE POZADIE*/
        if (pozadie7.transform.position.x < -16.8)
        {
            pozadie7.transform.position = pozadie7.transform.position + new Vector3(34.64f, 0, 0);
        }
        if (pozadie8.transform.position.x < -16.8)
        {
            pozadie8.transform.position = pozadie8.transform.position + new Vector3(34.64f, 0, 0);
        }
    }
}
