using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float HP = 0;
    public float MaxHP = 10000;
    public float ATK = 3000;
    public float DEF = 200;
    public float Mana = 10000;
    public float Mana_Regen = 250;
    public float RP = 10000;
    public float RP_Regen = 50;
    public bool invulnerable;
    public PlayerHealthBarScript playerHealthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        playerHealthBarScript.SetMaxHealth(MaxHP);
    }
    public void TakeDamage(float attack, float armor_pierce)
    {
        if (invulnerable == false)
        {
            invulnerable = true;
            HP -= attack - (DEF * (1 - armor_pierce));
            playerHealthBarScript.SetHealth(HP);
            StartCoroutine(invulnerbility_frames());
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator invulnerbility_frames()
    {
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}
