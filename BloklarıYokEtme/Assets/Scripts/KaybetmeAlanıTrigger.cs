using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaybetmeAlanıTrigger : MonoBehaviour
{

   
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("SahneKontrol").GetComponent<SahneKontrol>().KaybetmeEkranı("Kaybetme");
       // GameObject.FindObjectOfType<SahneKontrol>().KaybetmeEkranı("Kaybetme");
    }
}
 