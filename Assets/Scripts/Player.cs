using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    float v;
    Vector3 move;
    [SerializeField] private float speed = 5;
    [SerializeField] Transform aim;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    bool gunLoaded = true;
    [SerializeField] float fireRate = 1;
    [SerializeField] int Health = 10;

    //PowerUps

        //Aceleron
    public bool aceleron = false;
    [SerializeField] float aumento_speed = 5;
    [SerializeField] float tiempo_aceleron = 5;

        //MasCadencia
    public bool masCadencia = false;
    [SerializeField] float aumento_cadencia = 3;
    [SerializeField] float tiempo_cadencia = 5;

        //Decelerar
    public bool decelerar = false;
    [SerializeField] float disminucion_speed = 3;
    [SerializeField] float tiempo_decelerar = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        move.x = h;
        move.y = v;

        transform.position += move * Time.deltaTime * speed;
        
        //movimiento del arma
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        facingDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }
        //Powerup Aceleron
        if(aceleron == true)
        {
            aceleron = false; 
            StartCoroutine(Aceleron());
        }
        //Powerup MasCadencia
        if (masCadencia == true)
        {
            masCadencia = false;
            StartCoroutine(MasCadencia());
        }
        //Debuff Decelerar
        if (decelerar == true)
        {
            decelerar = false;
            StartCoroutine(Decelerar());
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }

    public void TakeDamage()
    {
        Health--;
        if (Health < 0)
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator MasCadencia()
    {
        float original_fireRate = fireRate;
        fireRate *= aumento_cadencia;
        yield return new WaitForSeconds(tiempo_cadencia);
        fireRate = original_fireRate;
    }

    IEnumerator Aceleron() 
    {
        float originalspeed = speed;
        speed *= aumento_speed;
        yield return new WaitForSeconds(tiempo_aceleron);
        speed = originalspeed;
    }
    IEnumerator Decelerar()
    {
        float originalspeed = speed;
        speed = disminucion_speed;
        yield return new WaitForSeconds(tiempo_decelerar);
        speed = originalspeed;
    }
}