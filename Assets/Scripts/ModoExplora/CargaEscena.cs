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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            panelCinematica.SetActive(false);
            confirmarSalida();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Activa cinematica");
            panelCinematica.SetActive(true);

            
//            gestorCinematicas();
           /* video.Play();
            video.loopPointReached += CheckOver;*/
        }
    }

    private void confirmarSalida()
    {
        if (this.gameObject.name == "CinematicaIglesia") 
        {
            sceneController.GetComponent<SceneController>().iglesiaInvierte();
        }
    }




    /*void CheckOver(VideoPlayer vp) 
    {
        gameObject.SetActive(false);
    } */

}
