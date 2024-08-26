using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public GameObject magicCircle;
    public PlayerAbilities Ice_proj;
    float CooldownTime;
    float ActiveTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    public KeyCode Ice_Proj;
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(Ice_Proj))
                {
                    GameObject magicCirclefp = GameObject.FindWithTag("MagicCircleFp");
                    Instantiate(magicCircle, magicCirclefp.transform.position, gameObject.transform.rotation);
                    StartCoroutine(Ice_Projectile());
                    state = AbilityState.cooldown;
                    CooldownTime = Ice_proj.CooldownTime;
                }
            break;
            case AbilityState.cooldown:
                if (CooldownTime > 0) {
                    CooldownTime -= Time.deltaTime;
                }
                else{
                    state = AbilityState.ready;
                }
            break;
        }
    }
    IEnumerator Ice_Projectile()
    {
        yield return new WaitForSeconds(1.5f);
        Ice_proj.Activate(gameObject);
    }
}

