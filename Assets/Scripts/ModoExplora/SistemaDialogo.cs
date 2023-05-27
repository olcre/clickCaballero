using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelDialogo;

    public GameObject[] texto;

    public GameObject[] respuestaJugador;

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
            panelDialogo.SetActive(true);
            /*for (int i = 0; i < texto.Length; i++) {
                texto[i].SetActive(true);
            }*/
            
        }
    }


}
