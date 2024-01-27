using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_terminal : MonoBehaviour
{
    [SerializeField] float speed = 1.25f;
    Transform Terminal;
    bool available = false;
    SpriteRenderer spriteRenderer;
    //[SerializeField] float waitTime = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        Terminal = FindFirstObjectByType<Terminal>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento del enemigo
        Vector2 direccion = Terminal.position - transform.position;
        transform.position += (Vector3)direccion.normalized * Time.deltaTime * speed;

        //para comprobar si las terminales están desactivadas
        if (available == false)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (available == true)
        {
            spriteRenderer.color = Color.green;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Terminal") && available == false)
    //    {
    //        GameManager.Instance.ResetTerminals();
    //        StartCoroutine(WaitAndSetAvailable(5f));
    //    }
    //}

    //private IEnumerator WaitAndSetAvailable(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    available = true;
    //    Destroy(gameObject);
    //}
}
