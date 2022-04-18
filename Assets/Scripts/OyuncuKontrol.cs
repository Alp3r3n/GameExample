using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public AudioClip altin, dusme;
    public OyunKontrol oyunK;
    private float hiz = 10;

    // Time.deltaTime =  The interval in seconds from the last frame to the current one

    void Update()
    {
            if(oyunK.oyunAktif)
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                x *= Time.deltaTime * hiz;
                y *= Time.deltaTime * hiz;

                transform.Translate(x, 0f, y);
            }
    }
    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag.Equals("altin"))
        {
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);
            // AudioSource.PlayClipAtPoint(altin, transform.position); ustteki komudun baska bir hali (ses oyuncunun bulundugu yerde aktiflesiyor)
            oyunK.AltinArttir();
            Destroy(c.gameObject);
            if(oyunK.altinSayisi == 3)
            {
                btn.gameObject.SetActive(true);
                oyunK.oyunAktif = false;
            }
        }
        else if(c.gameObject.tag.Equals("dusman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 10f);
            oyunK.oyunAktif = false;
            btn.gameObject.SetActive(true);
        }
    }
}
