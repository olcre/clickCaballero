using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CargaEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelCinematica;
    public GameObject sceneController;

    //public GameObject protaEscena;

    private bool escenaCargada = false;
    private void Awake()
    {
       // Debug.Log("Desactiva cinematica: " + panelCinematica.gameObject.name);
        panelCinematica.SetActive(false);
        sceneController = GameObject.FindGameObjectWithTag("ControlScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && escenaCargada && !panelCinematica.GetComponent<SistemaDialogo>().empiezaDialogo) 
        {
            confirmarSalida();
            Time.timeScale = 1;
        }

        //

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Activa cinematica");
            panelCinematica.SetActive(true);
            escenaCargada = true;

            //protaEscena = collision.gameObject;

           // protaEscena.GetComponent<Click2D>().setEstaHablando(true);
        }
    }

    public void confirmarSalida()
    {
        //int contadorBucles = 0;
        panelCinematica.SetActive(false);

        if (this.gameObject.name == "CinematicaIglesia")
        { 
            sceneController.GetComponent<SceneController>().iglesiaInvierte();
        }
        else if (this.gameObject.name == "CinematicaVendedor")
        {
            sceneController.GetComponent<SceneController>().mejorarArmadura();  
        }
        else if (this.gameObject.name == "Cinematica_SantJordi_1")
        {
            sceneController.GetComponent<SceneController>().santJordiQuest();
        }
        else if (this.gameObject.name == "Cinematica_SantJordi_2")
        {
            
            //sceneController.GetComponent<SceneController>().santJordiQuest();
        }
        else if (this.gameObject.name == "CinematicaFinal2" || this.gameObject.name == "CinematicaFinal1") 
        {
            //contadorBucles = sceneController.GetComponent<BucleController>().getBuclesTotales();
            //sceneController.GetComponent<BucleController>().setBuclesTotales(contadorBucles + 1);
            if (this.gameObject.name == "CinematicaFinal2") 
            {
                sceneController.GetComponent<SceneController>().setFinalDragonMuerto(true);
            }

            // BucleController hay que meter los metodos aqui
            sceneController.GetComponent<BucleController>().iniciaBucle();
            Debug.Log("Bucles actuales: " + sceneController.GetComponent<BucleController>().getBuclesTotales());
            //setVistaIglesia

        }
        escenaCargada = false;
        //protaEscena.gameObject.GetComponent<Click2D>().setEstaHablando(false);
    }




    /*void CheckOver(VideoPlayer vp) 
    {
        gameObject.SetActive(false);
    } */

}
