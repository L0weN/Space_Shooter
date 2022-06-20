using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -4.3f, maxY = 4.3f;

    [SerializeField]
    private GameObject laserShoot;

    [SerializeField]
    private Transform firstShootPoint, secondShootPoint;

    public Animator anim;

    public float attackTimer = 2f;
    private float currentAttackTimer;
    private bool canAttack;
    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    void Update()
    {
        MoveSpaceship();
        Attack();
    }

    void MoveSpaceship()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed* Time.deltaTime;
            if (temp.y > maxY)
            {
                temp.y = maxY;
            }
            transform.position = temp;
            
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < minY)
            {
                temp.y = minY;
            }
            transform.position = temp;
        }
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attackTimer = 0f;
                anim.SetBool("Attack", true);
                Instantiate(laserShoot, firstShootPoint.position, Quaternion.identity);
                Instantiate(laserShoot, secondShootPoint.position, Quaternion.identity);
                Invoke("DeactiveAttack", 0.1f);
            }

        }
    }
    void DeactiveAttack()
    {
        anim.SetBool("Attack", false);
    }
}
