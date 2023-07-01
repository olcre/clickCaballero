using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagabundo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sceneController;

    private void Awake()
    {
        sceneController = GameObject.FindGameObjectWithTag("ControlScene");
    }

    // Update is called once per frame
    //public void vagabundoRecibeMoneda() 
    //{
    //    int dineroVagabundo = sceneController.GetComponent<SceneController>().getPagosVagabundo();
    //    sceneController.GetComponent<SceneController>().setPagosVagabundo(dineroVagabundo + 1);
    //}

}
