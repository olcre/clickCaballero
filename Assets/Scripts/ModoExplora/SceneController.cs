using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //public GameObject[] cinematicas;

    public GameObject[] triangulosCinematicas;

    public Inventario inventario;

    public GameObject player;

    private bool vistaIglesia, sanJordiAccesible, visitaSanJordi, finalDragonMuerto;

    public GameObject finalMaloUno, finalMaloDos;

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
        finalMaloUno.SetActive(true);
        finalMaloDos.SetActive(false);
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

        if (inventario.getArmaduraOP()) 
        {
            activaSegundoFinal();
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

    public bool getFinalDragonMuerto()
    {
        return finalDragonMuerto;
    }

    public void setFinalDragonMuerto(bool finalDragonMuerto)
    {
        this.finalDragonMuerto = finalDragonMuerto;
    }



    public void iglesiaInvierte()
    {
        inventario.setCantidadDinero(1);
        vistaIglesia = true;
    }

    public void mejorarArmadura() 
    {
        inventario.setArmaduraOP(true);
    }


    public void santJordiQuest() 
    {
        visitaSanJordi = true;
        inventario.setCantidadDinero(inventario.getCantidadDinero() + 5);
    }

    public void activaSegundoFinal() 
    {
        finalMaloUno.SetActive(false);
        finalMaloDos.SetActive(true);
    }





}
