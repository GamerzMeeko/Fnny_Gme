using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public KeyCode Spellcast;
    public KeyCode Spellcast2;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spellcast2))
        {
            StartCoroutine(SpellCasting2());
        }
        if (Input.GetKeyDown(Spellcast))
        {
            StartCoroutine(SpellCasting());
        }
        
    }
    IEnumerator SpellCasting()
    {
        animator.SetBool("Casting", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("Casting", false);
    }
    IEnumerator SpellCasting2()
    {
        animator.SetBool("Casting2", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("Casting2",false);
    }
}
