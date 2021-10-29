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
    public float jumpForce = 50;
    private bool playergrounded = true;
    bool right, left, up, attack;
    float playerFall = 2.5f;
    Rigidbody2D projectileRB;
    // Start is called before the first frame update
    void Start()
    {

        rb2D = player.playerRigidBody;
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
            ThrowProjectile();
            attack = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            attack = false;
        }

    }
    public void ThrowProjectile()
    {
        if (!GameManager.canThrow)
        {
            GameObject proj = Instantiate(player.PlayerProjectile);
            proj.transform.parent = GameManager.instance.mainCanvas.transform;
            proj.transform.SetSiblingIndex(1);
            proj.transform.position = GameManager.instance.playerMain.transform.position;
            proj.transform.localScale = new Vector3(1f, 1f, 1f);
            projectileRB = proj.GetComponent<Rigidbody2D>();
            projectileRB.AddForce(new Vector2(150f, 10f), ForceMode2D.Impulse);
            GameManager.canThrow = true;
        }

    }
    private void FixedUpdate()
    {

        if (right)
        {
            player.CurrentState = (int)AnimationStates.run;
            this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (left)
        {
            player.CurrentState = (int)AnimationStates.run;
            this.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (attack)
        {
            player.CurrentState = (int)AnimationStates.attack;
          
        }
        else
        {
            player.CurrentState = (int)AnimationStates.idle;
        }

        if (up)
        {
            if (playergrounded)
            {

                player.CurrentState = (int)AnimationStates.jump;
                // rb2D.AddForce(new Vector2(0, 500*speed*Time.deltaTime));
                rb2D.velocity = Vector2.up * jumpForce;
                if (rb2D.velocity.y < 0)
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerFall - 1) * Time.deltaTime;
                }
                playergrounded = false;
            }
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
              player.CurrentState = (int)AnimationStates.idle;
            ChangeState();
        }
    }
}
