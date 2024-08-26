using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerWalking playerWalking = player.gameObject.GetComponent<PlayerWalking>();
        PlayerHP playerHP = player.gameObject.gameObject.GetComponent<PlayerHP>();
        if (other.gameObject.tag == "Boss" && playerWalking.sword_out == true)
        {
            BossHP bossHP = other.gameObject.GetComponent<BossHP>();
            bossHP.TakeDamage(playerHP.ATK, 0);   
        }
       
    }
}
