using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_ProjScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerWalking playerWalking = player.gameObject.GetComponent<PlayerWalking>();
        if (playerWalking.isFacingRight != true)
        {
            Speed = -Speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerWalking playerWalking = player.gameObject.GetComponent<PlayerWalking>();
        rb.velocity = new Vector2(Speed, 0);

    }
}
