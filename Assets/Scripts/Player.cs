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
    [SerializeField] int Health = 5;
    [SerializeField] bool PowerShot;

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
            // Game over
        }
    }


//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("PowerUp"))
//        {
//            switch (collision.GetComponent<PowerUp>().powerUpType)
//            {
//                case PowerUp.PowerUpType.FireRateIncrease:
//                    {
//                        fireRate++;
//                        break;
//                    }
//                case PowerUp.PowerUpType.PowerShot:
//                    {
//                        PowerShot = true;
//                        break;
//                    }
//                //case PowerUp.PowerUpType.SpeedBoost:
//                //    {
//                //        // + velocidad
//                //        break;
//                //    }
//                //case PowerUp.PowerUpType.HealthBoost:
//                //    {
//                //        // + salud
//                //        break;
//                //    }
//                default:
//                    {
//                        // Caso por defecto si no coincide con ningún tipo de power-up conocido
//                        break;
//                    }
//            }
//        }
//    }
}