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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniciaBucle() 
    {
        inventario.setArmaduraOP(false);
        inventario.setCantidadDinero(0);
    }

    //Cuando el caballero se haya ido del callejon de sant jordi y de la calle principal, Sant Jordi ya no se encontrara en el callejon

}


