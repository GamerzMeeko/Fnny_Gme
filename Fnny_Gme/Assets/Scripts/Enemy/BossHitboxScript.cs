using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitboxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject boss = GameObject.FindWithTag("Boss");
            BossStats bossStats = boss.gameObject.GetComponent<BossStats>();
            PlayerHP playerHP = other.gameObject.GetComponent<PlayerHP>();
            playerHP.TakeDamage(bossStats.CurrentATK, 0);   
        }
       
    }
}
