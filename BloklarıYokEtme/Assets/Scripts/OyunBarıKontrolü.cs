using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunBarıKontrolü : MonoBehaviour
{

    public bool OtomotikOynatma = false;
    private OyunTopuKontrolü OyunTopu;

    void Start()
    {
        OyunTopu = GameObject.FindObjectOfType<OyunTopuKontrolü>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (OtomotikOynatma)
        {
            OtomatikHareket();
        }
        else
        {
            FaremizinHareketi();
        }
       
    }


    void FaremizinHareketi()
    {
        Vector3 OyunBariKonumu = new Vector3(0f, this.transform.position.y, 0f);
        float MouseKonumX = Input.mousePosition.x / Screen.width * 16;
        OyunBariKonumu.x = Mathf.Clamp(MouseKonumX, -6.69f, 6.68f);
        this.transform.position = OyunBariKonumu;
    }

    void OtomatikHareket()
    {
        Vector3 OyunBariKonumu = new Vector3(0f, this.transform.position.y, 0f);
        Vector3 TopunKonumu = OyunTopu.transform.position;
        OyunBariKonumu.x = Mathf.Clamp(TopunKonumu.x,1f,15f);
        this.transform.position = OyunBariKonumu;
    }
}
