using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    // Start is called before the first frame update

    public bool armaduraOP;

    public int cantidadDinero;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCantidadDinero(int nuevoDinero) 
    {
        cantidadDinero = nuevoDinero;
    }

    public int getCantidadDinero() 
    {
        return cantidadDinero;
    }

    public void setArmaduraOP(bool estadoArmadura) 
    {
        armaduraOP = estadoArmadura;
    }
    public bool getArmaduraOP() 
    {
        return armaduraOP;
    }


}
