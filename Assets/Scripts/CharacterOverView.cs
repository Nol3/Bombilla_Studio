using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterOverView : MonoBehaviour
{
    [Header("Text")]
    public GameObject InputFieldBot;
    public GameObject InputFieldTop;
    public TextMeshProUGUI Obj_Text_Top;
    public TextMeshProUGUI Obj_Text_Bot;
    public TMP_InputField Display_Top;
    public TMP_InputField Display_Bot;


    [Space(10)]
    [Header("Text")]
    public Image FinalMeme;

    public void InsertText()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "Top_Text")
        {
            InputFieldBot.SetActive(false);
            InputFieldTop.SetActive(true);
            Obj_Text_Top.text = Display_Top.text;

        }
        else if (ButtonName == "Bot_Text")
        {
            InputFieldBot.SetActive(true);
            InputFieldTop.SetActive(false);
            Obj_Text_Bot.text = Display_Bot.text;

        }
    }
    
    public void ResetText()
    {
        Obj_Text_Top.text = "";
        Obj_Text_Bot.text = "";
    }

    public void SumbitMeme()
    {
        PlayerPrefs.SetString("top_text", Obj_Text_Top.text);
        PlayerPrefs.SetString("bot_text", Obj_Text_Bot.text);
        PlayerPrefs.SetString("meme_name", FinalMeme.sprite.name);
        PlayerPrefs.Save();
        Invoke("LoadSceneGame", 1);
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game");
    }

}
