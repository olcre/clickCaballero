using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Click2D : MonoBehaviour
{
    public Camera mainCamera;

    Vector3 worldPosition;

    public bool TocaPuerta = false;

   /* private Vector3 

    //private float velocidad = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }*/

    void Update()
    {

        clickMovimiento();
        verificadorDeMovimiento();

    }

    //Permite mover al jugador
    private void clickMovimiento() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            mousePosition.z = -mainCamera.transform.position.z;
            worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            TocaPuerta = false;
        }
    }

    //Verifica si el jugador puede moverse para evitar bugs al cambiar de pantalla
    private void verificadorDeMovimiento() 
    {
        if (TocaPuerta)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, worldPosition, Time.deltaTime * 5);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puerta puertaX;

        if (collision.gameObject.CompareTag("Cambio")) 
        {
           TocaPuerta = true;

           puertaX = collision.GetComponent<Puerta>();

           this.gameObject.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x, puertaX.coordenadasNuevas.transform.position.y - puertaX.posicionExtraJugador, puertaX.coordenadasNuevas.transform.position.z);
           mainCamera.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x + puertaX.posicionExtraCamaraX, puertaX.coordenadasNuevas.transform.position.y + puertaX.posicionExtraCamaraY, puertaX.coordenadasNuevas.transform.position.z - 10);
            //Cambia estado pantalla;

        }
    }

    public bool getTocaPuerta() 
    {
        return TocaPuerta;
    }

    public void setTocaPuerta(bool TocaPuerta) 
    {
        this.TocaPuerta = TocaPuerta;
    }

}
