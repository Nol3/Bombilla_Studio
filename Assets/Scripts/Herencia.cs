using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herencia : MonoBehaviour
{
    /// ---------------------------------------------
    /// Componentes
    /// ---------------------------------------------
    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public Collider2D gameCollider;

    /// ---------------------------------------------
    /// función para inicializar los componenes y los manehadores
    /// ---------------------------------------------  
    public void Init()
    {
        ///conseguir componentes
        rigidBody = GetComponent<Rigidbody2D>();
        gameCollider = GetComponent<Collider2D>();
    }
}