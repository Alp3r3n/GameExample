using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button yenidenBasla;
    public UnityEngine.UI.Text altinSayisiText;
    public UnityEngine.UI.Button baslaButonu;
    // public bool isGameEnded = false;
    public bool oyunAktif = true;
    public int altinSayisi = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    public void AltinArttir()
    {
        altinSayisi += 1;
        altinSayisiText.text = "" + altinSayisi;
    }

    public void OyunaBasla()
    {
        oyunAktif = true;
        baslaButonu.gameObject.SetActive(false);
    }
}
