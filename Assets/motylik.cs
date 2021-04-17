using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motylik : MonoBehaviour
{
    public Hra Hra;
    public hrac hrac;

    public GameObject PlayButton, OptionButton, QuitButton;
    public GameObject VrstvaVyberPozadie, VrstvaKoniecHry, VrstvaStart, VrstvaHraj, VrstvaVyberPostavu;
    public GameObject[] layers;

    public void DisableLayers() //func na vypnutie vsetkych vrstiev
    {
        foreach (GameObject lay in layers)
        {
            lay.SetActive(false);
        }
    }


    public void vyber_pozadi()
    {
        DisableLayers();
        VrstvaVyberPozadie.SetActive(true);
    }

    public void vyber_postav()
    {
        DisableLayers();
        VrstvaVyberPostavu.SetActive(true);
    }

    public void bakc_to_menu()
    {
        DisableLayers();
        VrstvaStart.SetActive(true);
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, 0f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        foreach (GameObject pipeka in Hra.Pipeky)
        {
            Destroy(pipeka);
        }
        Hra.Pipeky.Clear();
        Hra.Pipeky.Clear();

    }

    public void play_game()
    {
        DisableLayers();
        VrstvaHraj.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()

    {
        DisableLayers();
        VrstvaStart.SetActive(true);

    }
    public void GameOver()
    {
       // 
        DisableLayers();
        Debug.Log("koniec");
        VrstvaHraj.SetActive(true);
        Hra.enabled = false;
        hrac.Zastav();
        VrstvaKoniecHry.SetActive(true);
    }
    public void restartujeme()
    {
        DisableLayers();
        VrstvaHraj.SetActive(true);
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, 0f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        foreach (GameObject pipeka in Hra.Pipeky)
        {
            Destroy(pipeka);
        }
        Hra.Pipeky.Clear();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit() //applikacia sa vypne
    {
        Application.Quit();
    }
}
