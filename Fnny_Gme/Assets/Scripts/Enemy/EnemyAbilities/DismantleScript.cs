using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismantleScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float lifeTime;
    public float damage;
    public float damage_multiplier;
    public float boss_atk;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        GameObject player = GameObject.FindWithTag("Player"); 
        GameObject boss = GameObject.FindWithTag("Boss");
        Vector3 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.transform.position);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed; 
        BossStats bossStats = boss.gameObject.GetComponent<BossStats>();
        damage = damage_multiplier * bossStats.CurrentATK;  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {   
            PlayerHP playerhealth = other.gameObject.GetComponent<PlayerHP>();
            playerhealth.TakeDamage(damage, 0.25f);   
        }
       
    }
}
