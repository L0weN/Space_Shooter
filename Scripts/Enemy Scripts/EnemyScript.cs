using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float boundX = -11f;
    public Transform attackPoint;
    public GameObject enemyLaser;
    public Animator anim;
    public AudioSource explosionSound;
    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            }
        }
        if(canShoot)
            Invoke("Shooting", Random.Range(1f, 3f));
    }

    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
            if(temp.x < boundX)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void Shooting()
    {
        GameObject laserShoot = Instantiate(enemyLaser, attackPoint.position, Quaternion.identity);
        laserShoot.GetComponent<LasershootScripts>().isEnemyBullet = true;

        if (canShoot)
        {
            Invoke("Shooting", Random.Range(1f, 3f));
        }
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lasershoot")
        {
            canMove = false;
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("Shooting");
            }
            Invoke("TurnOffGameObject", 3f);
            explosionSound.Play();
            anim.Play("EnemyDeath");
        }
    }
}
