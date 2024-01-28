using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
        Debug.Log("is this working?");
    }
}
