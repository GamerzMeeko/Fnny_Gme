using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public GameObject congrats;
    public bool invulnerable = false;
    public BossBarScript bossBarScript;
    void Start()
    {
        BossStats bossStats = gameObject.GetComponent<BossStats>();
        bossStats.CurrentHP = bossStats.CurrentMaxHP;
        bossBarScript.SetMaxHealth(bossStats.CurrentMaxHP);
    }
    public void TakeDamage(float attack, float armor_pierce)
    {
        if (invulnerable == false)
        {
            invulnerable = true;
            StartCoroutine(invulnerbility_frames());
            BossStats bossStats = gameObject.GetComponent<BossStats>();
            bossStats.CurrentHP -= attack - (bossStats.CurrentDEF * (1 - armor_pierce));
        if (bossStats.CurrentHP <= 0)
        {
            Destroy(gameObject);
            congrats.SetActive(true);
        }
        bossBarScript.SetHealth(bossStats.CurrentHP); 
        }
    }
    IEnumerator invulnerbility_frames()
    {
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}
