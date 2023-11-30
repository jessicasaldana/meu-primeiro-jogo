using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    public float jumpForce;
    public int life;
    public int apple;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator anim;
    public SpriteRenderer sprite;

    [Header("UI")]
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI lifeText;
    public GameObject restart;

    //privado
    private Vector2 direction; // armazena valor x e y
    private bool isGrounded;
    private bool recovery;
    
    void Start()
    {
        lifeText.text = life.ToString();
        Time.timeScale = 1; //velocidade do jogo normal 1; parado 0; lento 0.5.
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Jump();
        PlayAnim();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetInteger("transition", 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;

        }
    }

    //animaçoes
    void PlayAnim()
    {
        if(direction.x > 0)
        {
            if(isGrounded == true)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = Vector2.zero;
        }

        if(direction.x < 0)
        {
            if (isGrounded == true)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector2(0,180);
        }

        if (direction.x == 0)
        {
            if (isGrounded == true)
            {
                anim.SetInteger("transition", 0);
            }
        }

    }

    //dano
    public void Hit()
    {
        if(recovery == false)
        {
            StartCoroutine(Flick());
        }
    }

    IEnumerator Flick()
    {
        recovery = true;
        life--;
        lifeText.text = life.ToString();
        Death();
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(1, 1, 1, 1);
        recovery = false;
    }

    //ganhar pontos
    public void IncreaseScore()
    {
        apple++;
        appleText.text = apple.ToString();
    }

    //game over
    void Death()
    {
        if(life <= 0)
        {
            Time.timeScale = 0; //velocidade do jogo normal 1; parado 0; lento 0.5.
            restart.SetActive(true);
        }
    }

    //restart
    public void RestartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
