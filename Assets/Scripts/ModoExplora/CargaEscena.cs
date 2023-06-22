using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CargaEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelCinematica;
    protected GameObject sceneController;

 //   public GameObject protaEscena;

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
        if (Input.GetKeyDown(KeyCode.Space) && (escenaCargada || panelCinematica.GetComponent<SistemaDialogo>().esUnaCinematica)) 
        {
            confirmarSalida();
        }

        Time.timeScale = 1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Activa cinematica");
            panelCinematica.SetActive(true);
            escenaCargada = true;

            //collision.gameObject.GetComponent<Click2D>().setEstaHablando(true);
        }
    }

    private void confirmarSalida()
    {
        panelCinematica.SetActive(false);

        if (this.gameObject.name == "CinematicaIglesia")
        { 
            sceneController.GetComponent<SceneController>().iglesiaInvierte();
        }
        else if (this.gameObject.name == "CinematicaVendedor")
        {
            sceneController.GetComponent<SceneController>().mejorarArmadura();
        }
        else if (this.gameObject.name == "CinematicaFinal2" || this.gameObject.name == "CinematicaFinal1") 
        {
            if (this.gameObject.name == "CinematicaFinal2") 
            {
                sceneController.GetComponent<SceneController>().setFinalDragonMuerto(true);
            }

           // BucleController hay que meter los metodos aqui

        }

        //protaEscena.gameObject.GetComponent<Click2D>().setEstaHablando(false);
    }




    /*void CheckOver(VideoPlayer vp) 
    {
        gameObject.SetActive(false);
    } */

}
