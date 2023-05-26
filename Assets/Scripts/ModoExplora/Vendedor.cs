using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
    private bool recibeDinero;

    private Inventario inventario;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (inventario.getCantidadDinero() > 0)
            {
                recibeDinero = cobraDinero();
            }

            if (recibeDinero)
            {
                mejorarAmadura();
            }
        }
    }


    private bool cobraDinero() 
    {
        bool respuesta;
        //Funcion para preguntar si quiere que su armadura sea mejorada

        inventario.setCantidadDinero(0);

        respuesta = true;

        return respuesta;
    }

    private void mejorarAmadura() 
    {
        inventario.setArmaduraOP(true);
    }

}
