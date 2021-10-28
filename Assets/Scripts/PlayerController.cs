using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum AnimationStates {idle,run,jump,attack}
    public Player player;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float speed = 50f;
    private bool playergrounded = true;
    bool right, left, up, attack;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2D = player.Rb2D;
        animator = player.PlayerAnimator;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            up = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            attack = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            attack = false;
        }

    }
    private void FixedUpdate()
    {

        if (right)
        {
            player.CurrentState = 1;
            this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (left)
        {
            player.CurrentState = 1;
            this.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (up)
        {
            if (playergrounded)
            {
                player.CurrentState = 2;
                rb2D.AddForce(new Vector2(0, 700));
                playergrounded = false;
            }
        }
        else if (attack)
        {
            player.CurrentState = 3;
        }
        else
        {
            player.CurrentState = 0;
        }
        ChangeState();
    }
    void ChangeState()
    {
        animator.SetInteger("changeState", player.CurrentState);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playergrounded = true;
            player.CurrentState = 0;
        }
    }
}
