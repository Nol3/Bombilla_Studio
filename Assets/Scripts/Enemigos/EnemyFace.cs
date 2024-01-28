using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFace : MonoBehaviour
{
    public Image[] PosiblesMemes;
    public Image ImageMeme;
    public int RandoMemeNu;
    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < PosiblesMemes.Length; i++)
       {
            RandoMemeNu= PosiblesMemes.Length - 1;
            ImageMeme.gameObject.GetComponent<SpriteRenderer>().sprite = PosiblesMemes[RandoMemeNu].sprite;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
