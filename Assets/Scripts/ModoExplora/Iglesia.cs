using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iglesia : MonoBehaviour
{
    private bool primeraVisita;

    private Inventario inventario;
    private bool v;

    public Iglesia(bool v)
    {
        this.v = v;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void iglesiaInvierte() 
    {
        if (primeraVisita)
        {
            inventario.setCantidadDinero(4);
            primeraVisita = false;
        }
        else 
        { 
            //Que explique cosillas del reino
        }
        
    }

    public void setPrimeraVisita(bool primeraVisita) 
    {
        this.primeraVisita = primeraVisita;
    }

    public bool getPrimeraVisita() 
    {
        return primeraVisita;
    }

}
