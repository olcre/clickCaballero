using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject camara, player;
    public GameObject coordenadasNuevas;
    public int posicionExtraJugador, posicionExtraCamaraX, posicionExtraCamaraY;


    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Entra en Puerta");
    //        player.GetComponent<Click2D>().setTocaPuerta(true); 
    //        //camara.SetActive(false);
    //        // collision.gameObject.transform.position = new Vector3(coordenadasNuevas.transform.position.x, coordenadasNuevas.transform.position.y - posicionExtraJugador, coordenadasNuevas.transform.position.z);
    //        // camara.transform.position = new Vector3 (coordenadasNuevas.transform.position.x + posicionExtraCamaraX, coordenadasNuevas.transform.position.y + posicionExtraCamaraY, coordenadasNuevas.transform.position.z - 10);
    //        //playerMov.SetActive(false);
    //    }
    //}

}
