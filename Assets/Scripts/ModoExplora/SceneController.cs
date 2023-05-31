using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //public GameObject[] cinematicas;

    public GameObject[] triangulosCinematicas;

    public Inventario inventario;

    private bool vistaIglesia, sanJordiAccesible, visitaSanJordi, finalDragonMuerto;

    // Start is called before the first frame update

    private void Awake()
    {
        inventario.setArmaduraOP(false);
        inventario.setCantidadDinero(0);
    }

    void Start()
    {
        vistaIglesia = false;
        sanJordiAccesible = false;
        visitaSanJordi = false;
        finalDragonMuerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (vistaIglesia) 
        {
            desactivaIglesia();
        }

        if (sanJordiAccesible) 
        { 
            
        }
    }

    private void desactivaIglesia()
    {
        //.gameObject.name
        //cinematicas[0].SetActive(false);
        triangulosCinematicas[0].SetActive(false);
    }

    public bool getVisitaIglesia() 
    {
        return vistaIglesia;
    }

    public void setVistaIglesia(bool vistaIglesia) 
    {
        this.vistaIglesia = vistaIglesia;
    }

    public bool getVisitaSanJordi()
    {
        return visitaSanJordi;
    }

    public void setVisitaSanJordi(bool visitaSanJordi)
    {
        this.visitaSanJordi = visitaSanJordi;
    }



    public void iglesiaInvierte()
    {
        inventario.setCantidadDinero(1);
        vistaIglesia = true;
    }

    public void santJordiQuest() 
    {
        visitaSanJordi = true;
        inventario.setCantidadDinero(inventario.getCantidadDinero() + 5);
    }


}
