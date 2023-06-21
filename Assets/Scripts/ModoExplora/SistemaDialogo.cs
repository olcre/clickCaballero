using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDialogo : MonoBehaviour
{
    // Start is called before the first frame update

    private bool playerEnRango = false;
    public GameObject panelDialogo, panelOpciones;
    public TMP_Text texto;
    [TextArea(4, 6)]public string[] dialogos;

    public Button[] botones;


    private bool empiezaDialogo = false;
    private int indexDialogo = 0;

    public bool esUnaCinematica = false;

    public bool tieneOpciones = false;
    public int numDialogoOpciones; 

    private float tiempoCaracter = 0.05f;

    void Start()
    {
        //panelDialogo = GameObject.FindGameObjectWithTag("PanelDialogo");
        //texto = GameObject.FindGameObjectWithTag("Dialogo");

    }

    // Update is called once per frame
    void Update()
    {
        flujoDialogos();
        controlOpciones();
    }

    private void controlOpciones()
    {
        if (tieneOpciones)
        {
            panelOpciones.SetActive(true);
        }
        else
        {
            panelOpciones.SetActive(false);
        }
    }



    private void flujoDialogos(){
        if ((playerEnRango && Input.GetButtonDown("Fire2")) || (esUnaCinematica))
        {
            if (!empiezaDialogo)
            {
                iniciaDialogo();
            }
            else if (texto.text == dialogos[indexDialogo])
            {
                if (indexDialogo == numDialogoOpciones) 
                {
                    tieneOpciones = true;
                }

                if (tieneOpciones)
                {
                    controlOpciones();
                    calculaBotones();
                }
                else
                {
                    siguienteDialogo();
                }
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                StopAllCoroutines();
                siguienteDialogo();
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                StopAllCoroutines();
                texto.text = dialogos[indexDialogo];
            }

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            finalizaDialogos();
        }
    }

    private void calculaBotones()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            int buttonIndex = i; // Variable temporal para evitar el problema de cierre
            botones[i].onClick.AddListener(() => OnButtonClicked());
        }
    }

    private void iniciaDialogo() 
    {
        empiezaDialogo = true;
        panelDialogo.SetActive(true);
        indexDialogo = 0;
        Time.timeScale = 0;
        StartCoroutine(ShowLine());

    }

    private void siguienteDialogo() 
    {
        indexDialogo++;

        if (indexDialogo < dialogos.Length)
        {
            StartCoroutine(ShowLine());
        }
        else 
        {
            finalizaDialogos();
        }
    }

    private void finalizaDialogos() 
    {
        empiezaDialogo = false;
        panelDialogo.SetActive(false);
        Time.timeScale = 1;
        esUnaCinematica = false;
    }

    private IEnumerator ShowLine() 
    {
        texto.text = string.Empty;

        foreach (char ch in dialogos[indexDialogo]) 
        {
            texto.text += ch;
            yield return new WaitForSecondsRealtime(tiempoCaracter);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Inicia dialogo");
            playerEnRango = true;
        }
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Deja dialogo");
            playerEnRango = false;
            //panelDialogo.SetActive(false);
        }
    }

    private void OnButtonClicked()
    {
        tieneOpciones = false;
    }
    /*  public GameObject panelDialogo;

      public GameObject[] texto;

      public SistemaDialogo(GameObject panelDialogo, GameObject[] texto) 
      {
          this.panelDialogo = panelDialogo;
          this.texto = texto;
      }


      private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.CompareTag("Player"))
          {
              panelDialogo.SetActive(true);
          }
      }

      private void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.gameObject.CompareTag("Player"))
          {
              panelDialogo.SetActive(true);
              for (int i = 0; i < texto.Length; i++) {
                  texto[i].SetActive(true);
              }

          }
      */


}
