using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasershootScripts : MonoBehaviour
{
    public float speed = 7f;
    public float deactiveTimer = 3.5f;

    public AudioSource aud;

    [HideInInspector]
    public bool isEnemyBullet = false;
    void Start()
    {
        if (isEnemyBullet)
            speed *= -1f;
        Invoke("DeactiveLaserShoot", deactiveTimer);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactiveLaserShoot()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lasershoot" || collision.tag == "Enemy" || collision.tag == "Rock")
        {
            gameObject.SetActive(false);
        }
    }
}
