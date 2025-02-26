using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement")]
    public float speed;
    public float jumpHeight;
    public Vector2 direction;
    [Header("Animations")]
    public SpriteRenderer _playerSpriteRenderer;
    public Sprite spriteUp, spriteDown;
    private Rigidbody2D playerRB2D;
    private Animator animator;
    public bool isGrounded = true;
    public bool DoJump = false;
    [Header("Health System")]
    public int health = 3;
    public string loseSceneName = "LoseScene";
    public Image[] healthHearts;



    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
             DoJump = true;
            animator.SetBool("IsJumping", true);
        }
        if (DoJump)
        {
            playerRB2D.AddForce(new Vector2(playerRB2D.linearVelocity.x, jumpHeight));
            DoJump = false;
        }
      //  playerRB2D.velocity = new Vector2(speed * direction, playerRB2D.velocity.y);
        // AnimatePlayerSprite();
        //Vector2 normalizedDir = playerRB2D.linearVelocity.normalized;
        //transform.right = normalizedDir;
    }
    private void Move()
    {
        Vector2 velocity = playerRB2D.linearVelocity;
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            velocity.x = speed;
            //animator.SetBool("IsMoving", true);
            _playerSpriteRenderer.flipX = (false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            velocity.x = -speed;
            //animator.SetBool("IsMoving", true);
            _playerSpriteRenderer.flipX = (true);
        }
        else
        {
            velocity.x = 0; // Stop moving when no key is pressed
            animator.SetBool("IsMoving", false);
        }
        playerRB2D.linearVelocity = velocity;
    }
    private void Jump()
    {
        //animator.SetBool("IsJumping", true);
        bool isJumping = !isGrounded;
        animator.SetBool("IsJumping", isJumping);
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(playerRB2D.linearVelocityY, 0))
        { // Ensure jumping only when grounded
            playerRB2D.linearVelocity = new Vector2(playerRB2D.linearVelocityX, jumpHeight);
        }
    }

    /*
    private void AnimatePlayerSprite()
    {
        Vector2 direction = playerRB2D.linearVelocity;
        //bool isMoving = direction.x != 0;
        bool isJumping = !isGrounded;
       animator.SetBool("IsJumping", isJumping);


        if (isJumping)
        {
            if (direction.y > 0)
            {
                animator.SetFloat("Y", 1);
            }
            else
            {
                animator.SetFloat("Y", -1);
            }
            animator.SetFloat("X", 0);
        }
        else if (direction.x != 0)
        {
            animator.SetBool("IsMoving", true);
            if (direction.x > 0)
            {
                animator.SetFloat("X", 1);
            }
            else
            {
                animator.SetFloat("X", -1);
            }
            animator.SetFloat("Y", 0);
        }
        else
        {
            animator.SetFloat("X", 0f);
            animator.SetFloat("Y", 0f);
            animator.SetBool("IsMoving", false);
        }

    } */


    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI();
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1); // Reduce health by 1 when hitting an enemy
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthHearts.Length; i++)
        {
            if (i < health)
            {
                healthHearts[i].enabled = true;
            }
            else
            {
                healthHearts[i].enabled = false;
            }
        }
    }
}
