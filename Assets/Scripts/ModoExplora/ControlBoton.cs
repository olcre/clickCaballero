using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoton : MonoBehaviour
{
    // Start is called before the first frame update

    private bool botonPulsado = false;
    public bool respuestaCorrecta;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SePulso() 
    {
        botonPulsado = true;
    }

    public bool getBotonPulsado() 
    {
        return botonPulsado;
    }

    public void setBotonPulsado(bool botonPulsado) 
    {
        this.botonPulsado = botonPulsado;
    }

    public bool getRespuestaCorrecta()
    {
        return respuestaCorrecta;
    }

    public void setRespuestaCorrecta(bool respuestaCorrecta)
    {
        this.respuestaCorrecta = respuestaCorrecta;
    }


}
