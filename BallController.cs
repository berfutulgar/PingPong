using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public float speed = 7.0f;

    private Rigidbody2D rb;

    //Scores
    public int ScorePlayer1 = 0;
    public int ScorePlayer2 = 0;

    //TextMeshro UGUI references
    public TextMeshProUGUI TextScorePlayer1;
    public TextMeshProUGUI TextScorePlayer2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
        UpdateScore();
    }

    void ResetBall()
    {
        // Start the ball in the center
        transform.position = Vector2.zero;
        rb.velocity = Vector2.right * (Random.Range(0, 2) == 0 ? 1 : -1) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopDownWall"))
        {
            //It will bounce off the top and bottom walls
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightWall")) 
        { 
            //If it passes through the right wall, add a score to Player 1
            ScorePlayer1++;
            UpdateScore();
            ResetBall();
        }

        else if (other.gameObject.CompareTag("LeftWall"))
        {
            //If it passes through the left wall, add a score to Player 2
            ScorePlayer2++;
            UpdateScore();
            ResetBall();
        }
    }

    void UpdateScore()
    {
        //Update the score using TextMeshPro UGUI
        TextScorePlayer1.text = ScorePlayer1.ToString();
        TextScorePlayer2.text = ScorePlayer2.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = Vector2.zero;
        }
    }
}
