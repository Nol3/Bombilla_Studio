using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFace : MonoBehaviour
{
    public Sprite[] PosiblesMemes;
    public GameObject ImageMeme;
    public int RandoMemeNu;
    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < PosiblesMemes.Length; i++)
       {
            RandoMemeNu = Random.Range(0, PosiblesMemes.Length - 1);
            ImageMeme.GetComponent<SpriteRenderer>().sprite = PosiblesMemes[RandoMemeNu];
            SpriteRenderer.sprite.transform.localScale = new Vector3(512, 512, 512);
       }
    }
}
