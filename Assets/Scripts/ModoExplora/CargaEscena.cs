using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CargaEscena : MonoBehaviour
{
    // Start is called before the first frame update

    //public VideoPlayer video;

    public GameObject panelCinematica;
    protected GameObject sceneController;

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
        if (Input.GetKeyDown(KeyCode.Space) && escenaCargada) 
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
        }
    }

    private void confirmarSalida()
    {
        if (this.gameObject.name == "CinematicaIglesia")
        {
            panelCinematica.SetActive(false);
            sceneController.GetComponent<SceneController>().iglesiaInvierte();
        }
        else if (this.gameObject.name == "CinematicaVendedor")
        {
            panelCinematica.SetActive(false);
            sceneController.GetComponent<SceneController>().mejorarArmadura();
        }
        else if (this.gameObject.name == "CinematicaFinal2" || this.gameObject.name == "CinematicaFinal1") 
        {
            panelCinematica.SetActive(false);

            if (this.gameObject.name == "CinematicaFinal2") 
            {
                sceneController.GetComponent<SceneController>().setFinalDragonMuerto(true);
            }

           // BucleController hay que meter los metodos aqui

        }
    }




    /*void CheckOver(VideoPlayer vp) 
    {
        gameObject.SetActive(false);
    } */

}
