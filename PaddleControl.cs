using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public float speed = 10.0f;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;

        if (Input.GetKey(upKey))
        {
            move = 1;
        }

        else if (Input.GetKey(downKey))
        {
            move = -1;
        }

        rb.velocity = new Vector2(0, move * speed);
    }
}
