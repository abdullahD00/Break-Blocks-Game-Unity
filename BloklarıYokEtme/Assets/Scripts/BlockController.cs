using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 


public class BlockController : MonoBehaviour
{
  [SerializeField]  int Can;
    [SerializeField] int VurulmaSayisi;
    [SerializeField] Sprite[] BlockVurulmaDurumlari;
    private SpriteRenderer BlockSprite;
    private bool kirilabilirMi;
    public static int kirilabilirBlockSayisi;
    private SahneKontrol MySahne;
    public GameObject Efekt;

    
    // Start is called before the first frame update
    void Start()
    {
        kirilabilirMi = (this.tag == "kirilabilir");
        if (kirilabilirMi)
        {
            kirilabilirBlockSayisi++;
            Debug.Log(kirilabilirBlockSayisi);
        }
        VurulmaSayisi = 0;
        MySahne = GameObject.FindObjectOfType<SahneKontrol>();
        BlockSprite = this.GetComponent<SpriteRenderer>();
        
      
       
        BlockSprite.drawMode = SpriteDrawMode.Sliced;      //Bu kod değiştirdiğimiz block şeklinin size'ı ile oynamamızı sağlıyor.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (kirilabilirMi)
        {
            
            TopVurulmaKontrolu();
            GameObject.Find("1VuruşlukBlock").GetComponent<AudioSource>().Play();
            GameObject.Find("2VuruşlukBlock").GetComponent<AudioSource>().Play();
            GameObject.Find("3VuruşlukBlock").GetComponent<AudioSource>().Play();
        }
        
    }

    private void BlockSpriteGorunumDegistir()
    {
        BlockSprite.sprite = BlockVurulmaDurumlari[VurulmaSayisi - 1];
        //Block görüntü değişiliği sonrası size ı değişiyor. Aşağıdaki kod ile diğerleri ile sabit ayarda tutabiliyoruz.
        BlockSprite.size += new Vector2(0.07f, 0.01f);
        
    }
    private void TopVurulmaKontrolu()
    {

        VurulmaSayisi++;
        if (VurulmaSayisi >= Can)
        {
            kirilabilirBlockSayisi--;
            GameObject efektimiz = Instantiate(Efekt, transform.position, Quaternion.identity);
            efektimiz.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Instantiate(Efekt);
            Destroy(gameObject);
           
            Debug.Log(kirilabilirBlockSayisi);
            
            MySahne.BloklarinYokOlmasi();
            
            
            //Debug.Log(kirilabilirBlockSayisi);
            //Destroy(this.gameObject);
            //GameObject.Find("SahneKontrol").GetComponent<SahneKontrol>().BlocklarinYokOlmasi();

        }
        else
        {
            BlockSpriteGorunumDegistir();
        }
    }
}
