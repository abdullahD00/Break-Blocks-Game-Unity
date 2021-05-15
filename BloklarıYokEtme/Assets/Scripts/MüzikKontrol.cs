using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MüzikKontrol : MonoBehaviour
{
    static MüzikKontrol TekMüzikKontrol = null;
    // Start is called before the first frame update
    

    //Awake fonksiyonu start fonksiyonundan bile önce çalışan fonksiyondur. İlk çalışan fonksiyondur.
    //Saniyelik işlerde ilk çalışması gereken şeyler bu fonksiyon üzerinden yapılabilir.
    //RigidBody de kinematic demek kendi özelliklerini kendimiz belirleyeceğiz demek anlamına geliyor.
    private void Awake()
    {
        if (TekMüzikKontrol!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            TekMüzikKontrol = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }



    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
