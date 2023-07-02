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

    protected GameObject sceneController;

    public GameObject protaEscena;

    public bool empiezaDialogo = false;
    private int indexDialogo = 0;

    public bool esUnaCinematica = false;

    public bool tieneOpciones = false;
    public int numDialogoOpciones;
    public bool opcionSeleciona = false;

    private float tiempoCaracter = 0.05f;

    private bool opcionCorrecta = false;


    void Start()
    {
        //panelDialogo = GameObject.FindGameObjectWithTag("PanelDialogo");
        //texto = GameObject.FindGameObjectWithTag("Dialogo");
        //panelOpciones = GameObject.FindGameObjectWithTag("PanelOpciones");


        sceneController = GameObject.FindGameObjectWithTag("ControlScene");
        //Bug: El multiopciones puede colarse donde no debe

    }

    // Update is called once per frame
    void Update()
    {
        flujoDialogos();

        //determinarRespuestaCorrectaParaBoton();

        //controlOpciones();
        //if (opcionSeleciona && opcionCorrecta) 
        //{ 
        //    cambioDialogo();
        //}
        
    }

    private void determinarRespuestaCorrectaParaBoton()
    {
        if (this.gameObject.name == "Vagabundo")
        {
            botones[0].GetComponent<ControlBoton>().setRespuestaCorrecta(true);
            //botones[0].gameObject.GetComponentInChildren<TextMeshPro>().text = "Sí, te doy una";
            botones[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Sí, te doy una";
            botones[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "No, creo que ya no hace falta comprar nada";
            botones[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "No dispongo del dinero necesario";
        }
        else if (this.gameObject.name == "Cinematica_Vendedor")
        {
            botones[2].GetComponent<ControlBoton>().setRespuestaCorrecta(true);
            botones[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "No, no la necesitaré";
            botones[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "No dispongo del dinero necesario";
            botones[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Sí, la necesitaré";
            //botones[1].GetComponentInChildren<TextMeshPro>().text = "No, ojalá me hubieran dado una";
            //botones[2].GetComponentInChildren<TextMeshPro>().text = "No, no se de donde conseguirla";
        }
        else if (this.gameObject.name == "Cinematica_SantJordi_2")
        {
            botones[1].gameObject.SetActive(false);
            botones[0].GetComponent<ControlBoton>().setRespuestaCorrecta(true);
            //botones[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
            botones[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Si...";
            botones[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "No";
            //botones[1].GetComponentInChildren<TextMeshPro>().text = "No, ojalá me hubieran dado una";
            //botones[2].GetComponentInChildren<TextMeshPro>().text = "No, no se de donde conseguirla";
        }
    }

    private void cambioDialogo()
    {
        //Confirma bucle
        int bucleActual = sceneController.GetComponent<BucleController>().getBuclesTotales();
        int dineroVagabundo = sceneController.GetComponent<SceneController>().getPagosVagabundo();


        if (this.gameObject.name == "Vagabundo" && personajeDisponeDeLoSolicitado())
        {
            if (dineroVagabundo == 0)
            {
                dialogos[1] = "Por una moneda os puedo indicar el camino hacia el castillo. ";
                dialogos[2] = "Caminad todo recto hacia la izquierda del mundo si no me falta un tornillo.";
                //sceneController.GetComponent<SceneController>().setPagosVagabundo(dineroVagabundo + 1);
            }
            else if (dineroVagabundo == 1) 
            {
                dialogos[1] = "Muchas gracias por esta moneda mi señor.";
                dialogos[2] = "Si matar al dragón con vuestra espada no es suficiente, contratad los servicios del armero justo enfrente.";

            }
            else if (dineroVagabundo == 2)
            {
                dialogos[1] = "En el callejón a mi espalda se esconde el reflejo incomodo para aquel que se acobarda. ";
                dialogos[2] = "Un caballero que fue luz en su día, apagado al descubrir no ser tan fuerte como se creía. ";

                sceneController.GetComponent<SceneController>().setSanJordiAccesible(true);

            }
            else if (dineroVagabundo >= 3)
            {
                dialogos[1] = "¿Otra moneda? Lo lamento pero no tengo más consejos para darte.  ";
                dialogos[2] = "Me temo que tendrás que gastar tu dinero con alguien más ambicioso... ";

            }
            sceneController.GetComponent<SceneController>().setPagosVagabundo(dineroVagabundo+1);
        }
        else if (this.gameObject.name == "Vagabundo" && !personajeDisponeDeLoSolicitado()) 
        {
            dialogos[1] = "Podeis conseguir dinero en la iglesia.";
            dialogos[2] = "El amor a veces tiene un precio...";
        }
        else if (this.gameObject.name == "Cinematica_Vendedor" && personajeDisponeDeLoSolicitado())
        {
            dialogos[1] = "Ahora vuestra armadura os podra proteger de todo mal... incluido el desamor.";
        }
        else if (this.gameObject.name == "Cinematica_Vendedor" && !personajeDisponeDeLoSolicitado()) 
        {
            dialogos[1] = "Siempre podreis volver a mi tienda si cambiais de opinión...";
        }
        else if (this.gameObject.name == "Cinematica_SantJordi_2" && personajeDisponeDeLoSolicitado()) 
        {
            dialogos[1] = "¿No habían rosas? No puede ser... entonces ¿Todo era mentira? Yo... ¿Que he estado anhelando entonces?";
            dialogos[2] = "Por favor, marchaos... dejadme solo aunque sea por un momento... Tengo demasiado en lo que pensar...";

        }
        else if (this.gameObject.name == "Chica_del_Rio" && bucleActual == 0)
        {
            dialogos[1] = "Es el primer bucle";
        }
        else if (this.gameObject.name == "Chica_del_Rio" && bucleActual == 1)
        {
            dialogos[1] = "Es el segundo bucle";
        }
        else if (this.gameObject.name == "Chica_del_Rio" && bucleActual == 2)
        {
            dialogos[1] = "Es el tercer bucle";
        }
        else if (this.gameObject.name == "Chica_del_Rio" && bucleActual >= 3)
        {
            dialogos[1] = "Es el cuarto bucle";
            sceneController.GetComponent<BucleController>().setBucleRoto(true);
        }
        //else if (this.gameObject.name == "Chica_del_Rio" && )
        //{
        //    dialogos[1] = "Adios...";

        //}
    }

    public bool personajeDisponeDeLoSolicitado() 
    {
        bool objectoNecesario = false;
        if (protaEscena.GetComponent<Inventario>().getCantidadDinero() > 0 && (this.gameObject.name == "Vagabundo" || this.gameObject.name == "Cinematica_Vendedor")) 
        {
            objectoNecesario = true;
        }

        else if (sceneController.GetComponent<SceneController>().getFinalDragonMuerto() && (this.gameObject.name == "Cinematica_SantJordi_2"))
        {
            objectoNecesario = true;
        }

        return objectoNecesario;
    }


    private int confirmaBucle()
    {
        int buclesTotales = sceneController.GetComponent<BucleController>().getBuclesTotales();
        return buclesTotales;
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
            if (opcionSeleciona && opcionCorrecta)
            {
                cambioDialogo();
            }
        }
    }



    private void flujoDialogos(){
        if ((playerEnRango && Input.GetButtonDown("Fire1")) || (esUnaCinematica)) //Cambiar a cuando lo esta tocando
        {
            determinarRespuestaCorrectaParaBoton();

            protaEscena.gameObject.GetComponent<Click2D>().setEstaHablando(true);

            
            if (!empiezaDialogo)
            {
                iniciaDialogo();
            }
            else if (texto.text == dialogos[indexDialogo])
            {

                revisionDialogoMultiopcion();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                StopAllCoroutines();
                revisionDialogoMultiopcion();
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

    private void revisionDialogoMultiopcion() 
    {
        if (indexDialogo == numDialogoOpciones && !opcionSeleciona)
        {
            tieneOpciones = true;
        }

        if (tieneOpciones)
        {
            verificaBotonesPulsados();
            controlOpciones();
            //controlRompeErrores = true;

            //calculaBotones();
        }
        else
        {
            siguienteDialogo();
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
                if (botones[i].gameObject.GetComponent<ControlBoton>().getRespuestaCorrecta()) 
                    {
                        //Aqui se almacena una variable que diga si es una respuesta de cambio o no
                        opcionCorrecta = true;
                    }

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
            botones[i].GetComponent<ControlBoton>().setRespuestaCorrecta(false);
        }
        tieneOpciones = false;
        opcionSeleciona = false;
        //controlRompeErrores = false;
    }

    private void iniciaDialogo() 
    {
        empiezaDialogo = true;
        panelDialogo.SetActive(true);
        indexDialogo = 0;
        //Time.timeScale = 0;
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
        //Time.timeScale = 1;
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

        //determinarRespuestaCorrectaParaBoton();

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
