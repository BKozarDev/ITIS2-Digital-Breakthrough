using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public bool isRight;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public CircleCollider2D coll;

    private float startDelay;
    private float timer;

    void Start()
    {
        startDelay = Random.Range(0, 0.3f);
        timer = startDelay;
        if (isRight)
            sr.color = Color.green;
        else
            sr.color = Color.red;
        Debug.Log(rb.gravityScale);
        rb.gravityScale = 0;
        coll.enabled = false;
    }

    void Update()
    {
        if (timer <= 0)
        {
            rb.gravityScale = 1;
            coll.enabled = true;
        }
        else
            timer -= Time.deltaTime;
    }
}
