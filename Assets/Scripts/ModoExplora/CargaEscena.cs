using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CargaEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer video;


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
            video.Play();
            video.loopPointReached += CheckOver;
        }
    }

    void CheckOver(VideoPlayer vp) 
    {
        gameObject.SetActive(false);
    } 
    
}
