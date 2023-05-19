using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool tocado = false;

    public int direccionIA = 2, direccionAnterior = 0, direccionUltima = 0;

    public float duration = 4;

    public float velocidad = 3;

    public int vida = 10;

    public bool muerto = false;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (!muerto) 
        { 
            MovEnemy();
        }
    }

    private void MovEnemy() 
    {
        EnemyCanMove(direccionIA);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            ChangeDiretion();
            duration = ChangeTimer();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider")) 
        {
            ChangeDiretion();
        }
    }

    private void ChangeDiretion() 
    {
        int nuevaDireccion = 0;

        do
        {
            nuevaDireccion = Random.Range(0, 4);
        } while (nuevaDireccion == direccionIA || nuevaDireccion == direccionAnterior || nuevaDireccion == direccionUltima);

        direccionUltima = direccionAnterior;
        direccionAnterior = direccionIA;
        direccionIA = nuevaDireccion;
    }

    private float ChangeTimer()
    {
        return duration = Random.Range(4, 10);
    }

    private void EnemyCanMove(int num)
    {

        switch (num)
        {
            case 0:
                this.transform.Translate(Vector2.right * velocidad * Time.deltaTime);
                break;
            case 1:
                this.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
                break;
            case 2:
                this.transform.Translate(Vector2.up * velocidad * Time.deltaTime);
                break;
            case 3:
                this.transform.Translate(Vector2.down * velocidad * Time.deltaTime);
                break;
        }
    }

    private void OnMouseDown()
    {
        vida--;
        if (vida == 0) 
        {
            Debug.Log("Dragon muerto");
            muerto = true;
        }
    }


}
