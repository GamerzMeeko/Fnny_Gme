using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Ice_proj : PlayerAbilities
{
    public GameObject magicCircle;
    public GameObject gameObject;
    
    

    public override void Activate(GameObject parent)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject fp = GameObject.FindWithTag("Fp");
        PlayerWalking playerWalking = player.gameObject.GetComponent<PlayerWalking>();
        if (playerWalking.isFacingRight == true)
        {
            Instantiate(gameObject, fp.transform.position, player.transform.rotation);
        }
        else
        {
            Vector3 LocalScale = gameObject.transform.localScale;
            LocalScale.x *= -1f;
            gameObject.transform.localScale = LocalScale;
            Instantiate(gameObject, fp.transform.position, gameObject.transform.rotation);
            LocalScale.x *= -1f;
            gameObject.transform.localScale = LocalScale;
        }
    }
}
