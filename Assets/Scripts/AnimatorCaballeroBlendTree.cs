using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCaballeroBlendTree : MonoBehaviour
{

    [SerializeField] Click2D ReferenciaClick2D;
    Animator Animator;
    



    void Start()
    {
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = (ReferenciaClick2D.BlendTreeValue.x*5);
        float y = (ReferenciaClick2D.BlendTreeValue.y*5);


        Animator.SetFloat("x", -x);
        Animator.SetFloat("y", -y);

    }

    void ActualizaPosicion()
    {
        Debug.Log("actualiza frame)");

        transform.position = ReferenciaClick2D.transform.position;
        
    }

}
