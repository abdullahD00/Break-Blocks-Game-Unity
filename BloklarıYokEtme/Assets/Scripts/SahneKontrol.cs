using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrol : MonoBehaviour
{
    
  public void OyunaBasla()
    {
        SceneManager.LoadScene(1);

        
    }
    public void OyundanCikis()
    {
        Application.Quit();
    }
    public void  MenuyeDon()
    {
        SceneManager.LoadScene(0);
       
    }
    public void SonrakiBolüm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void KaybetmeEkranı(string Kaybetme)
    {
        SceneManager.LoadScene(Kaybetme);
        
    }
    public void KazanmaEkrani(string Kazanma)
    {
        SceneManager.LoadScene(Kazanma);
    }
   public void BloklarinYokOlmasi()
    {
        if (BlockController.kirilabilirBlockSayisi <= 0)
        {
            SonrakiBolüm();
        }
    }
   
}
