using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //public GameObject[] cinematicas;

    public GameObject[] triangulosCinematicas;

    public Inventario inventario;

    public GameObject sceneController;

    private int pagosVagabundo;

    private bool vistaIglesia, sanJordiAccesible, visitaSanJordi, finalDragonMuerto;

    public GameObject finalMaloUno, finalMaloDos;

    public GameObject santJordiUno, santJordiDos;

    // Start is called before the first frame update

    private void Awake()
    {
        inventario.setArmaduraOP(false);
        inventario.setCantidadDinero(0);
        pagosVagabundo = 0;
        sceneController = GameObject.FindGameObjectWithTag("ControlScene");
        
    }

    void Start()
    {
        vistaIglesia = false;
        sanJordiAccesible = false;
        visitaSanJordi = false;
        finalDragonMuerto = false;
        finalMaloUno.SetActive(true);
        finalMaloDos.SetActive(false);
        santJordiUno.SetActive(false);
        santJordiDos.SetActive(false);
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
            if (!getFinalDragonMuerto())
            {
                santJordiUno.SetActive(true);
                santJordiDos.SetActive(false);
            }
            else if (getFinalDragonMuerto() && visitaSanJordi)
            {
                santJordiUno.SetActive(false);
                santJordiDos.SetActive(true);
            }

        }

        if (inventario.getArmaduraOP()) 
        {
            activaSegundoFinal();
        }
    }

    private void desactivaIglesia()
    {
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

    public bool getSanJordiAccesible()
    {
        return sanJordiAccesible;
    }

    public void setSanJordiAccesible(bool sanJordiAccesible)
    {
        this.sanJordiAccesible = sanJordiAccesible;
    }


    public bool getFinalDragonMuerto()
    {
        return finalDragonMuerto;
    }

    public void setFinalDragonMuerto(bool finalDragonMuerto)
    {
        this.finalDragonMuerto = finalDragonMuerto;
    }

    public int getPagosVagabundo()
    {
        return pagosVagabundo;
    }

    public void setPagosVagabundo(int pagosVagabundo)
    {
        this.pagosVagabundo = pagosVagabundo;
    }

    public void iglesiaInvierte()
    {
        inventario.setCantidadDinero(2);
        vistaIglesia = true;
    }

    public void mejorarArmadura() 
    {
        if (inventario.getCantidadDinero() > 0) 
        { 
            inventario.setCantidadDinero(inventario.getCantidadDinero() - 1);
            inventario.setArmaduraOP(true);
        }
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
