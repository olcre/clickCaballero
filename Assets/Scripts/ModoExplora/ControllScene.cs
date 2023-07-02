using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScene : MonoBehaviour
{
    // Start is called before the first frame update

    Inventario inventario;

    BucleController bucle;

    private bool jugadorTocaEscenaFinal;

    public GameObject player;

    public Camera mainCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (jugadorTocaEscenaFinal) 
    //    {
    //        activaFinalFalso();
    //    }
    //}




    //private void activaFinalFalso() 
    //{
    //    if (inventario.getArmaduraOP())
    //    {
    //        //Muestra cinematica con Dragon muriendo
    //    }
    //    else 
    //    {
    //        //Muestra cinematica con herue muriendo
    //    }

    //    reiniciaBucle();

    //}

    //private void reiniciaBucle() 
    //{
    //    bucle.setBucleReiniciado(true);
    //    player.gameObject.transform.position = new Vector2(0, 0); //Queda pulir
    //    //Mismo a camara
    //}

    public void setJugadorTocaEscenaFinal(bool jugadorTocaEscenaFinal) 
    {
        this.jugadorTocaEscenaFinal = jugadorTocaEscenaFinal;
    }


}
