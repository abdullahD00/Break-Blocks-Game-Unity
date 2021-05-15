using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunTopuKontrolü : MonoBehaviour
{
    [SerializeField] OyunBarıKontrolü OyunBari;
    bool OyunBasladimi;
    private Vector3 TopİleBarArasindakiMesafe;
    // Start is called before the first frame update
    void Start()
    {
        TopİleBarArasindakiMesafe = this.transform.position - OyunBari.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OyunBasladimi)
        {
            this.transform.position = OyunBari.transform.position + TopİleBarArasindakiMesafe;
             if (Input.GetMouseButtonDown(0))
            {
                  OyunBasladimi = true;
                 this.GetComponent<Rigidbody2D>().velocity = new Vector3(3f, 15f,0f);
            
             }
        
        }
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 UfakSarpma = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));

        if (collision.transform.tag=="Zemin")
        {
            GameObject.Find("ball").GetComponent<AudioSource>().Stop();
        }
        else
        {
            GameObject.Find("ball").GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + UfakSarpma;
        }
        
    }
}
