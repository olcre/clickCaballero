using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPantallas : MonoBehaviour
{

    public GameObject[] listaPantallas;

    public GameObject player, camara;

    // Start is called before the first frame update
    void Awake()
    {
        listaPantallas[0].GetComponent<Pantalla>().setPantallaActiva(true);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pantallaActiva();
       /* if (player.GetComponent<Click2D>().getTocaPuerta()) 
        { */
        jugadorCambiaPantalla();
       // }


    }


    private void pantallaActiva()
    {
        // Calcula la distancia entre el personaje y el punto de fuga
        // for (int i=0; i<listaPantallas.Length; i++)
        //{
        int i = controlPosicion();

      //  if (!player.GetComponent<Click2D>().getTocaPuerta()) 
        //{ 
            if (!listaPantallas[i].GetComponent<Pantalla>().getPantallaActiva())
            {
                
                listaPantallas[i].GetComponent<Pantalla>().desactivaPuntoFuga();
            }
            else 
            {
                listaPantallas[i].GetComponent<Pantalla>().activaPuntoFuga();
            }
        //}
    }


    /*private int pantallaPosicion()
    {
        int num = 0;
        bool finCiclo = false;
        // Calcula la distancia entre el personaje y el punto de fuga
        while (finCiclo)
        {
            if (listaPantallas[num].GetComponent<Pantalla>().getPantallaActiva())
            {
                finCiclo = true;
            }
            num++;
            //Debug.Log("-->" + "Pantalla: " + num + " Estado: " + listaPantallas[num].GetComponent<Pantalla>().getPantallaActiva());
        }
        return num;
    }*/


    //private void activaEstaPantalla(int num) 
    //{
    //    if (listaPantallas[num].GetComponent<Pantalla>().getPantallaActiva()) 
    //    {
    //        listaPantallas[num].GetComponent<Pantalla>().activaPuntoFuga();
    //    }    
    //}

    //private void desactivaEstaPantalla(int num)
    //{
    //    if (!listaPantallas[num].GetComponent<Pantalla>().getPantallaActiva())
    //    {
    //        listaPantallas[num].GetComponent<Pantalla>().desactivaPuntoFuga();
    //    }
    //}

    private void jugadorCambiaPantalla() 
    {
        
        //Debug.Log("Posición para pantalla: "+controlPosicion());
        if (player.GetComponent<Click2D>().getTocaPuerta())
        {
            Puerta puertaX = player.GetComponent<Click2D>().PuertaX;

            Pantalla pantallaActual = listaPantallas[controlPosicion()].GetComponent<Pantalla>();
            //Tengo que averiguar cual sera la siguiente pantalla y después desactivar la que se tenia activa
            pantallaActual.setPantallaActiva(false);
            pantallaActual.pantallaRelacionada.GetComponent<Pantalla>().setPantallaActiva(true);

            player.gameObject.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x, puertaX.coordenadasNuevas.transform.position.y - puertaX.posicionExtraJugador, puertaX.coordenadasNuevas.transform.position.z);
            camara.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x + puertaX.posicionExtraCamaraX, puertaX.coordenadasNuevas.transform.position.y + puertaX.posicionExtraCamaraY, puertaX.coordenadasNuevas.transform.position.z - 10);

            player.GetComponent<Click2D>().verificadorDeMovimiento();

            //player.GetComponent<Click2D>().setTocaPuerta(false);
        }
    }


    private int controlPosicion() 
    {
        bool encuentraPosicion = false;
        int num = 0;
        while (!encuentraPosicion && num < listaPantallas.Length) 
        {
            if (listaPantallas[num].GetComponent<Pantalla>().getPantallaActiva())
            {
                encuentraPosicion = true;
            } 
            else 
            {
                num++; 
            }
        }
        return num;
    }


    private int revisionPantallas(int opcion) 
    {
        int numPosicion = -1;

        switch (opcion) {  
            case 0:
                numPosicion = 0;
                break;
            case 1:
                numPosicion = 1;
                break;
        }
        return numPosicion;
    }


}
