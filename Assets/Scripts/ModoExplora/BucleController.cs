using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucleController : MonoBehaviour
{
    private bool dragonMuerto;

   // private bool bucleReiniciado;

    private int buclesTotales;

    public Inventario inventario;

    SceneController scene;

    private bool bucleRoto;

    // Start is called before the first frame update
    void Start()
    {
        buclesTotales = 0;
        bucleRoto = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (bucleReiniciado)
    //    {
    //        iniciaBucle();
    //    }
        
    //}

    public void iniciaBucle() 
    {
        inventario.setArmaduraOP(false);
        inventario.setCantidadDinero(0);
        scene.setVistaIglesia(false);
        //bucleReiniciado = false;

        if (scene.getFinalDragonMuerto()) 
        {
            dragonMuerto = true;
        }
        buclesTotales++;
    }

    public void setBucleRoto(bool bucleRoto) 
    {
        this.bucleRoto = bucleRoto;
    }

    public bool getBucleRoto() 
    {
        return bucleRoto;
    }

    public void setBuclesTotales(int buclesTotales)
    {
        this.buclesTotales = buclesTotales;
    }

    public int getBuclesTotales()
    {
        return buclesTotales;
    }

    //Cuando el caballero se haya ido del callejon de sant jordi y de la calle principal, Sant Jordi ya no se encontrara en el callejon


    //Indirectamente de que final malo salga, se debe ejecutar esté metodo: 

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player")) 
    //    {
    //        iniciaBucle();
    //        buclesTotales++;

    //    }
    //}

}


