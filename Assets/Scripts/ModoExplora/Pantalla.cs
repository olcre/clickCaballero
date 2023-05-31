using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    public GameObject puntoFuga;

    public GameObject player;

    public GameObject pantallaRelacionada;

    // public int pantallaId;

    // public int pantallaRelaciona;


    //private Vector3 scaleChange;

    private Vector3 escalaRealPersonaje;

    float minEscala = 0.2f, maxEscala = 2f;

    public bool pantallaActiva = false;

   // private bool pantallaActiva;

    //public bool pantallaActiva { get => pantallaActiva; set => pantallaActiva = value; }

    private void Awake()
    {
        escalaRealPersonaje = player.GetComponent<Transform>().localScale;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

    // Update is called once per frame
    void Update()
    {
        // Calcula la distancia entre el personaje y el punto de fuga
        if (pantallaActiva /*&& !player.GetComponent<Click2D>().getTocaPuerta()*/)
        {
            personajeEnPuntoDeFuga();
        }
    }

    //  Metodo de calculo para el punto de fuga
    private void personajeEnPuntoDeFuga()
    {

        //float distance = Vector2.Distance(player.transform.position, puntoFuga.transform.position);

        float distancia = puntoFuga.transform.position.y - player.transform.position.y;

        //float escalaNueva = Mathf.Lerp(minEscala, maxEscala, distancia * 0.1f);

        float escalaNueva = (escalaRealPersonaje.y / Mathf.Lerp(minEscala, maxEscala, distancia * 0.1f));

        player.transform.localScale = escalaRealPersonaje / (escalaNueva);
    }

    public void activaPuntoFuga()
    {
        puntoFuga.SetActive(true);
    }

    public void desactivaPuntoFuga()
    {
        puntoFuga.SetActive(false);
    }


    //Metodo activar
    public bool getPantallaActiva()
    {
        return pantallaActiva;
    }

    //Metodo desactivar
    public void setPantallaActiva(bool pantallaActiva)
    {
        this.pantallaActiva = pantallaActiva;
    }

}
