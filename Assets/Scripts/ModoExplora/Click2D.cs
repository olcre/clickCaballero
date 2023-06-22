using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Click2D : MonoBehaviour
{
  //  public ControllScene escena;

    public Camera mainCamera;

    Vector3 worldPosition;

    public bool tocaPuerta;

    public bool estaHablando;

    private Puerta puertaX;

    public Puerta PuertaX { get => puertaX; set => puertaX = value; }

    //private bool personajeEnMovimiento = false;

    /* private Vector3 

     //private float velocidad = 5.0f;
     // Start is called before the first frame update
     void Start()
     {

     }*/

    void Awake()
    {
        estaHablando = false;
    }

    void Update()
    {
        clickMovimiento();
        verificadorDeMovimiento();
    }

    //Permite mover al jugador
    private void clickMovimiento() 
    {
        if (Input.GetMouseButtonDown(0) /*&& !tocaPuerta*/)
        {
            Vector3 mousePosition = Input.mousePosition;

            mousePosition.z = -mainCamera.transform.position.z;
            worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            
            //personajeEnMovimiento = true;
           //tocaPuerta = false;
        }
       /* else if (Input.GetMouseButtonDown(0) && tocaPuerta) 
        { 
            tocaPuerta = false; //Hay fallos
        }*/

    }

    //Verifica si el jugador puede moverse para evitar bugs al cambiar de pantalla
    public void verificadorDeMovimiento() 
    {
        //Debug.Log("La puerta ha sido " + tocaPuerta);
        if (!tocaPuerta && !estaHablando)
        {
            trasladoPersonaje();
        }
        else 
        {
            Debug.Log("Puerta afecta a player");
            transform.position = transform.position;
            worldPosition = transform.position;
            tocaPuerta = false;
        }
    }

    private void trasladoPersonaje() 
    {
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, Time.deltaTime * 5);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cambio")) 
        {
            tocaPuerta = true;
            puertaX = collision.GetComponent<Puerta>();
            

            //this.gameObject.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x, puertaX.coordenadasNuevas.transform.position.y - puertaX.posicionExtraJugador, puertaX.coordenadasNuevas.transform.position.z);
            //mainCamera.transform.position = new Vector3(puertaX.coordenadasNuevas.transform.position.x + puertaX.posicionExtraCamaraX, puertaX.coordenadasNuevas.transform.position.y + puertaX.posicionExtraCamaraY, puertaX.coordenadasNuevas.transform.position.z - 10);
            //
            //Cambia estado pantalla;

        }


       /* if (collision.gameObject.CompareTag("Castillo")) 
        {

            escena.setJugadorTocaEscenaFinal(true);

        }*/

    }

    public bool getTocaPuerta() 
    {
        return tocaPuerta;
    }

    public void setTocaPuerta(bool tocaPuerta) 
    {
        this.tocaPuerta = tocaPuerta;
    }

    public bool getEstaHablando()
    {
        return estaHablando;
    }

    public void setEstaHablando(bool estaHablando)
    {
        this.estaHablando = estaHablando;
    }

}
