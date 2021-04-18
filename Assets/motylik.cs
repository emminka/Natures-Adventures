using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class motylik : MonoBehaviour
{
    public Hra Hra;
    public hrac hrac;
    public hrac hrac_vcela_skript;

    public GameObject PlayButton, OptionButton, QuitButton, obdlznik1, obdlznik2, obdlznik3, obdlznik4, obdlznik_motyl, obdlznik_vcela;
    public GameObject VrstvaVyberPozadie, VrstvaKoniecHry, VrstvaStart, VrstvaHraj, VrstvaScore, VrstvaVyberPostavu;
    public GameObject[] layers;
    public TextMeshProUGUI ScoreText, GameoverScoreText;

    
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
        ScoreText.text = 0.ToString();
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, -1f);
        Hra.hracvcela.transform.position = new Vector3(-5f, 2.5f, -1f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        hrac_vcela_skript.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        Hra.pozadie3.transform.position = new Vector3(3f, 0f, 0f);
        Hra.pozadie4.transform.position = new Vector3(25.89f, 0f, 0f);
        Hra.pozadie5.transform.position = new Vector3(6f, 0f, 0f);
        Hra.pozadie6.transform.position = new Vector3(34.23f, 0f, 0f);
        Hra.pozadie7.transform.position = new Vector3(0.5f, 0f, 0f);
        Hra.pozadie8.transform.position = new Vector3(17.82f, 0f, 0f);
        Hra.vzdialenostOdPoslednejPipeky = 0;
        Hra.posunutie = 0;
        Hra.pocet_pipok = 0;
        Hra.score = 0;

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
        VrstvaScore.SetActive(true);

    }

    public void hrac_motylik()
    {
        Hra.typHraca = 1;
        obdlznik_motyl.SetActive(true);
        obdlznik_vcela.SetActive(false);

        Debug.Log("motyl");
    }
    public void hrac_vcela()
    {
        Hra.typHraca = 2;
        obdlznik_motyl.SetActive(false);
        obdlznik_vcela.SetActive(true);
        
        Debug.Log("vcela");
    }

    public void pozadie_prve()
    {
        Hra.typPozadia = 1;
        obdlznik1.SetActive(true);
        obdlznik2.SetActive(false);
        obdlznik3.SetActive(false);
        obdlznik4.SetActive(false);
        Debug.Log("prve");
    }
    public void pozadie_druhe()
    {
        Hra.typPozadia = 2;
        obdlznik1.SetActive(false);
        obdlznik2.SetActive(true);
        obdlznik3.SetActive(false);
        obdlznik4.SetActive(false);
        Debug.Log("druhe");

    }
    public void pozadie_tretie()
    {
        Hra.typPozadia = 3;
        obdlznik1.SetActive(false);
        obdlznik2.SetActive(false);
        obdlznik3.SetActive(true);
        obdlznik4.SetActive(false);
        Debug.Log("tretie");

    }
    public void pozadie_stvrte()
    {
        Hra.typPozadia = 4;
        Debug.Log("svrte");
        obdlznik1.SetActive(false);
        obdlznik2.SetActive(false);
        obdlznik3.SetActive(false);
        obdlznik4.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()

    {
        DisableLayers();
        VrstvaStart.SetActive(true);
        ScoreText.text = 0.ToString();
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, -1f);
        Hra.hracvcela.transform.position = new Vector3(-5f, 2.5f, -1f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        hrac_vcela_skript.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        Hra.pozadie3.transform.position = new Vector3(3f, 0f, 0f);
        Hra.pozadie4.transform.position = new Vector3(25.89f, 0f, 0f);
        Hra.pozadie5.transform.position = new Vector3(6f, 0f, 0f);
        Hra.pozadie6.transform.position = new Vector3(34.23f, 0f, 0f);
        Hra.pozadie7.transform.position = new Vector3(0.5f, 0f, 0f);
        Hra.pozadie8.transform.position = new Vector3(17.82f, 0f, 0f);
        Hra.vzdialenostOdPoslednejPipeky = 0;
        Hra.posunutie = 0;
        Hra.pocet_pipok = 0;
        Hra.score = 0;
        Hra.typPozadia = 1;
        obdlznik1.SetActive(true);
        obdlznik2.SetActive(false);
        obdlznik3.SetActive(false);
        obdlznik4.SetActive(false);
        obdlznik_motyl.SetActive(true);
        obdlznik_vcela.SetActive(false);  
    }
    public void GameOver()
    {
       // 
        DisableLayers();
        Debug.Log("koniec");
        VrstvaHraj.SetActive(true);
        Hra.enabled = false;
        hrac.Zastav();
        hrac_vcela_skript.Zastav();
        VrstvaKoniecHry.SetActive(true);
        GameoverScoreText.text = "YOUR SCORE IS " + Hra.score.ToString(); //zmena score
    }
    public void restartujeme()
    {
        DisableLayers();
        VrstvaHraj.SetActive(true);
        VrstvaScore.SetActive(true);
        ScoreText.text = 0.ToString();
        Hra.hrac.transform.position = new Vector3(-5f, 2.5f, -1f);
        Hra.hracvcela.transform.position = new Vector3(-5f, 2.5f, -1f);
        hrac.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        hrac_vcela_skript.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        Hra.enabled = true;
        Hra.pozadie1.transform.position = new Vector3(4f, 0f, 0f);
        Hra.pozadie2.transform.position = new Vector3(30f, 0f, 0f);
        Hra.pozadie3.transform.position = new Vector3(3f, 0f, 0f);
        Hra.pozadie4.transform.position = new Vector3(25.89f, 0f, 0f);
        Hra.pozadie5.transform.position = new Vector3(6f, 0f, 0f);
        Hra.pozadie6.transform.position = new Vector3(34.23f, 0f, 0f);
        Hra.pozadie7.transform.position = new Vector3(0.5f, 0f, 0f);
        Hra.pozadie8.transform.position = new Vector3(17.82f, 0f, 0f);
        Hra.vzdialenostOdPoslednejPipeky = 0;
        Hra.posunutie = 0;
        Hra.pocet_pipok = 0;
        Hra.score = 0;
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
