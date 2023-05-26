using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucleController : MonoBehaviour
{
    private bool dragonMuerto;

    private bool bucleReiniciado;

    private int buclesTotales;

    private Inventario inventario;

    private Iglesia iglesia = new Iglesia(false);

    private bool bucleRoto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bucleReiniciado)
        {
            iniciaBucle();
        }
        
    }

    public void iniciaBucle() 
    {
        inventario.setArmaduraOP(false);
        inventario.setCantidadDinero(0);
        bucleReiniciado = false;
    }

    public void setBucleReiniciado(bool bucleReiniciado) 
    {
        this.bucleReiniciado = bucleReiniciado;
    }

    public bool getBucleReiniciado() 
    {
        return bucleReiniciado;
    }



    //Cuando el caballero se haya ido del callejon de sant jordi y de la calle principal, Sant Jordi ya no se encontrara en el callejon

}


