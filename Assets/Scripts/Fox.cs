using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fox : MonoBehaviour
{
    public AudioSource Musik;
    public AudioSource audioJump;
    public AudioSource audioDead;
    float horizontal;
    Rigidbody2D rb;
    Animator anim;
    private bool isFacingRight = true;
    bool move = true;
    float moves;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("jum", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }


    void FixedUpdate()
    {
        moves = horizontal;


        if (moves > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (moves < 0 && isFacingRight)
            Flip();


        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        if (move == true)
        {
            rb.velocity = new Vector2(Input.acceleration.x * 10f, rb.velocity.y);
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 10f, rb.velocity.y);
        }

    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform"&move==true)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 13, ForceMode2D.Impulse);
            anim.SetInteger("jum", 1);
            audioJump.Play();
        }
        if (other.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            move = false;
            anim.SetInteger("jum", 3);
            Time.timeScale = 0.1f;
            Musik.enabled = false;
            audioDead.Play();
        }
    }

    void OnCollisionExit2D(Collision2D ob)
    {
        if (move == true)
        {
            anim.SetInteger("jum", 2);
        }
        
    }

    void Dead()
    {

        BScoore.bestscore(Cherry.Score);
        Cherry.Score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");



    }
}
