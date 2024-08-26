using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cleave : MonoBehaviour {
    //the percentage that the ATK will get multiplied by to calculate damage
    public float DmgMultiplier;
    //the amount of cuts that cleave will perform
    public int CleaveCount;
    //the amount of damage that will be sent to the player
    public float Damage;
    
    //we use the gameobject boss to find the bossess ATK which we need for the damage calculuation
    public GameObject Boss;


    public IEnumerator cleave()
    {
        //a for statement to loop the amount of times that we will cut the player
        for (int i = 0; i < CleaveCount; i++)
        {
            StartCoroutine(Cut());
        }
        yield return new WaitForSeconds(5);
    }
    IEnumerator Cut()
    {
        //finding player hp to allow them to take damage
        GameObject player = GameObject.FindWithTag("Player");
        PlayerHP playerhp = player.gameObject.GetComponent<PlayerHP>();

        //finding boss ATK for the damage calculuation
        BossStats bosshp = Boss.gameObject.GetComponent<BossStats>();
        //Damage = bosshp.ATK * DmgMultiplier;
        //playerhp.TakeDamage(Damage);
        yield return new WaitForSeconds(1);
    }





}