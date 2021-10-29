using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public float followSpeed;
    Transform target;
    float previousPos;
    float nextPos;
    float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.playerMain.transform;
        previousPos = nextPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.enemyKilled)
        {
            distanceToPlayer = Vector2.Distance(transform.position, target.position);
            //Flip
            if (previousPos < nextPos)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {

                transform.localScale = new Vector3(1, 1, 1);
            }
            previousPos = nextPos;
            //Follow player
            if (distanceToPlayer > 100)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
            nextPos = transform.position.x;
        }
    }
    public void Damage(float hitPoint)
    {
        if (enemy.Health != 0)
        {
            enemy.Health -= hitPoint;
           // Debug.Log(enemy.Health);
        }
        else
        {
            //  enemy.enemyRigidBody.bodyType = RigidbodyType2D.Kinematic;
            enemy.enemyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            enemy.enemyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            enemy.Animator.SetTrigger("Death");
            GameManager.enemyKilled = true;
            Invoke("setDeathTrigger", 2f);
        
            
        }

    }
    public void setDeathTrigger()
    {
        Destroy(this.gameObject);
        EventTriggers.onEnemyDead();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Projectile")
        {
          //  Debug.Log("hello");
            Damage(10);
            Destroy(collision.gameObject);
            GameManager.canThrow = false;
        }
    }


}
