using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("top_text"));
        Debug.Log(PlayerPrefs.GetString("bot_text"));
        Debug.Log(PlayerPrefs.GetString("meme_name"));
    }

    
}
