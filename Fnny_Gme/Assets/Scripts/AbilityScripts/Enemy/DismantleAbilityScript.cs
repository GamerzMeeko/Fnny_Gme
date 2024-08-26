using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DismantleAbilityScript : MonoBehaviour
{
    public GameObject dismantle;
    public Transform bulletPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dismantle(float ATK)
    {
        DismantleScript dismantleScript = dismantle.GetComponent<DismantleScript>();
        Instantiate(dismantle, bulletPos.position, Quaternion.identity);
        dismantleScript.boss_atk = ATK;
    }
}
