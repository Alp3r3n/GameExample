using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public OyunKontrol oyunK;
    float hassasiyet = 5f;
    float yumusaklik = 2f;

    Vector2 gecisPos;
    Vector2 camPos;

    GameObject oyuncu;

    // Start is called before the first frame update
    void Start()
    {
        oyuncu = transform.parent.gameObject; // player and cam. connection   
        camPos.y = 12f;
        camPos.x = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if(oyunK.oyunAktif)
        {
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); // 2D loc.
            farePos = Vector2.Scale (farePos, new Vector2 (hassasiyet*yumusaklik, hassasiyet*yumusaklik)); // farepos = (first loc, second loc)
            gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklik); // kamera gecis (Lerp belirli bir sure icerisinde belirli bir noktadan diger noktaya gecisi saglar)
            gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklik);

            camPos += gecisPos;

            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right); // loaclRotation kendi ekseni etrafindaki eksenlere gore islem yapar  
            oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up); // faremizden aldigimiz x degerimize gore olusturdugumuz kamera poz. degiskeninin x degerine göre (kamera degil kamera doner(ikiside doner))
        }
    }
}
