using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{

    public float speed = 1f; //Sets speed of player
    public float JumpForce = 1; //Sets jump speed of player

    private Rigidbody2D _rigidbody; //makes rigidbody

    public GameObject[] hearts;
    public int life;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * speed)); //moves constantly right

        //if down arrow is pressed flip
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.N))
        {
            transform.Rotate(Vector3.up * 180); //rotate player 180 degrees on y
        }

        //if up arrow is pressed jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f || Input.GetKeyDown(KeyCode.X) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f || Input.GetKeyDown(KeyCode.M) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }


        if(life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if(life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(hearts[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(hearts[4].gameObject);
        }
        else if (life < 6)
        {
            Destroy(hearts[5].gameObject);
        }
        else if (life < 7)
        {
            Destroy(hearts[6].gameObject);
        }
        else if (life < 8)
        {
            Destroy(hearts[7].gameObject);
        }
        else if (life < 9)
        {
            Destroy(hearts[8].gameObject);
        }
        else if (life < 10)
        {
            Destroy(hearts[9].gameObject);
        }

        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            //Debug.Log("Wall hit");
            transform.Rotate(Vector3.up * 180); //rotate player 180 degrees on y
        }

        if (collision.gameObject.tag == "Spike")
        {
            //Debug.Log("Spike Hit");
            transform.Rotate(Vector3.up * 180); //rotate player 180 degrees on y
            life -= 1;
        }
    }
}