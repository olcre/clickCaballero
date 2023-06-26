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

    public GameObject protaEscena;

    private bool empiezaDialogo = false;
    private int indexDialogo = 0;

    public bool esUnaCinematica = false;

    public bool tieneOpciones = false;
    public int numDialogoOpciones;
    public bool opcionSeleciona = false;

    private float tiempoCaracter = 0.05f;

    //private int posicionArrayBotones;

    private bool opcionCorrecta = false;

    void Start()
    {
        //panelDialogo = GameObject.FindGameObjectWithTag("PanelDialogo");
        //texto = GameObject.FindGameObjectWithTag("Dialogo");
        //panelOpciones = GameObject.FindGameObjectWithTag("PanelOpciones");


        //Bug: Parece que necesita ser pulsado dos veces seguidas el boton, esto nos lleva ha pensar que por alguna raz�n cuesta detectar el primer click

    }

    // Update is called once per frame
    void Update()
    {
        flujoDialogos();

        //determinarRespuestaCorrectaParaBoton();

        //controlOpciones();
        if (opcionSeleciona && opcionCorrecta) 
        { 
            cambioDialogo();
        }
        
    }

    private void determinarRespuestaCorrectaParaBoton()
    {
        if (this.gameObject.name == "Vagabundo")
        {
            botones[0].GetComponent<ControlBoton>().respuestaCorrecta = true;
            //botones[0].gameObject.GetComponentInChildren<TextMeshPro>().text = "S�, te doy una";
            botones[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "S�, te doy una";
            //botones[1].GetComponentInChildren<TextMeshPro>().text = "No, ojal� me hubieran dado una";
            //botones[2].GetComponentInChildren<TextMeshPro>().text = "No, no se de donde conseguirla";
        }
    }

    private void cambioDialogo()
    {
        //Confirma bucle
      // int bucleActual = confirmaBucle();
        if (this.gameObject.name == "Vagabundo") 
        { 
            dialogos[1] = "Me has dado una moneda.";
            dialogos[2] = "Ahora te doy informaci�n";
        }
    }

    private int confirmaBucle()
    {
        //M�s adelante programar contador de bucles
        return 0;
    }

    private void controlOpciones()
    {
        if (tieneOpciones && !opcionSeleciona) //Mirar control boton
        {
            panelOpciones.SetActive(true);
        }
        else
        {
            panelOpciones.SetActive(false);
        }
    }



    private void flujoDialogos(){
        if ((playerEnRango && Input.GetButtonDown("Fire1")) || (esUnaCinematica))
        {
            protaEscena.gameObject.GetComponent<Click2D>().setEstaHablando(true);
            if (!empiezaDialogo)
            {
                iniciaDialogo();
            }
            else if (texto.text == dialogos[indexDialogo])
            {

                if (indexDialogo == numDialogoOpciones && !opcionSeleciona)
                {
                    tieneOpciones = true;
                }

                if (tieneOpciones)
                {
                    verificaBotonesPulsados();
                    controlOpciones();
                    
                    //calculaBotones();
                }
                else
                {
                    siguienteDialogo();
                }
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                StopAllCoroutines();
                siguienteDialogo();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                StopAllCoroutines();
                texto.text = dialogos[indexDialogo];
            }

        }
        else if (playerEnRango && Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            finalizaDialogos();
        }
    }

    private void verificaBotonesPulsados()
    {
        bool botonEncontrado = false;
        //int posicion = 0;
        for (int i = 0; i < botones.Length && !botonEncontrado; i++)
        {
            if (botones[i].gameObject.GetComponent<ControlBoton>().getBotonPulsado())
            {
                botonEncontrado = true;
                opcionSeleciona = true;
                tieneOpciones = false;
            }

            if (botones[i].gameObject.GetComponent<ControlBoton>().respuestaCorrecta) 
            {
                //Aqui se almacena una variable que diga si es una respuesta de cambio o no
                opcionCorrecta = true;
            }


           // posicion = i;
            //int buttonIndex = i; // Variable temporal para evitar el problema de cierre
            //botones[i].onClick.AddListener(() => OnButtonClicked());
            //Debug.Log("iNICIA BOTON");
        }



        //return posicion;
    }


    private void resetearValoresBotones() 
    {
        for (int i = 0; i < botones.Length; i++) 
        {
            botones[i].GetComponent<ControlBoton>().setBotonPulsado(false);
            botones[i].GetComponent<ControlBoton>().respuestaCorrecta = false;
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
        protaEscena.gameObject.GetComponent<Click2D>().setEstaHablando(false);

        //Resetear valores de botones
        resetearValoresBotones();

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

        determinarRespuestaCorrectaParaBoton();

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

    //private void OnButtonClicked()
    //{
    //    tieneOpciones = false;
    //}

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
