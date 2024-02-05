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
    public GameObject GameObject;

    public void InsertText()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "Top_Text")
        {
            InputFieldTop.SetActive(true);
            InputFieldBot.SetActive(false);
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
        Obj_Text_Top.text = "Texto de Arriba";
        Obj_Text_Bot.text = "Texto de Abajo";
        FinalMeme.sprite = null;
        GameObject.GetComponent<FulllManager>().Selected = false;
    }

    public void SumbitMeme()
    {
        PlayerPrefs.SetString("top_text", Obj_Text_Top.text);
        PlayerPrefs.SetString("bot_text", Obj_Text_Bot.text);
        PlayerPrefs.SetString("meme_name", FinalMeme.sprite.name);
        Debug.Log(PlayerPrefs.GetString("top_text"));
        Debug.Log(PlayerPrefs.GetString("bot_text"));
        Debug.Log(PlayerPrefs.GetString("meme_name"));

        PlayerPrefs.Save();
        StartCoroutine(LoadSceneGameAfterDelay(1));
    }

    private IEnumerator LoadSceneGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadSceneGame();
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Scenes/FinalBuild/4-Game");
        Debug.Log("t");
    }
}
