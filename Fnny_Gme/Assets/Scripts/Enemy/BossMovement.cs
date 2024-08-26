using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject boss;
    public Rigidbody2D rb;
    public bool player_side_left;
    public int horizontal = 1;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (boss.transform.position.x < player.gameObject.transform.position.x)
        {
            horizontal = 1;
            if (canMove)
            {
                Move_right();
            }
        }
        else
        {
            horizontal = -1;
            if (canMove)
            {
                Move_left();
            }
        }
    }

    void Move_right()
    {
        BossStats bossStats = boss.GetComponent<BossStats>();
        rb.velocity = new UnityEngine.Vector2(horizontal * bossStats.speed, rb.velocity.y);
    }
    void Move_left()
    {
        BossStats bossStats = boss.GetComponent<BossStats>();
        rb.velocity = new UnityEngine.Vector2(horizontal * bossStats.speed, rb.velocity.y);
    }
    private void Turn()
    {
        if (player_side_left && horizontal < 0f || !player_side_left && horizontal > 0f)
        {
            player_side_left = !player_side_left;
            UnityEngine.Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }
    }
}
