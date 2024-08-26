using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMechnanisms : MonoBehaviour
{
    public float distance;
    public GameObject boss;
    public int dismantle_cooldown_time;
    public int cleave_cooldown_time;
    public int attack_cooldown_time;
    public float dismantle_CooldownTime_current;
    public float cleave_Cooldown_Time_current;
    public float attack_cooldown_time_current;

    //what behaviour is being used
    public bool using_dismantle;
    public bool using_cleave;
    public bool using_attack;

    //Attacking stuff
    public bool canAttack = true;
    public bool isAttacking;
    public bool hitBox;
    private int Horizontal;
    public float dashPower;

    public GameObject particles;
    public GameObject Hitbox;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    enum SkillState
    {
        ready,
        active,
        cooldown,
        locked,
    }
    SkillState dismantle_state = SkillState.cooldown;
    SkillState cleave_state = SkillState.cooldown;
    SkillState attack_state = SkillState.cooldown;

    // Start is called before the first frame update
    void Start()
    {
        dismantle_CooldownTime_current = dismantle_cooldown_time;
        cleave_Cooldown_Time_current = cleave_cooldown_time;
        attack_cooldown_time_current = attack_cooldown_time;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(player.transform.position, boss.transform.position);
        switch (dismantle_state)
        {
            case SkillState.ready:
                if(using_cleave == false && using_attack == false)  
                {
                    using_dismantle = true;
                    StartCoroutine(dismantle());
                    dismantle_state = SkillState.cooldown;
                    dismantle_CooldownTime_current = dismantle_cooldown_time; 
                }
            break;
            case SkillState.cooldown:
                if (dismantle_CooldownTime_current > 0) {
                    dismantle_CooldownTime_current -= Time.deltaTime;
                }
                else{
                    dismantle_state = SkillState.ready;
                }
            break;
        }
        switch (cleave_state)
        {
            case SkillState.ready:
                if (using_dismantle == false && using_attack == false)
                {
                    using_cleave = true;
                    print("Cleave Used");
                    cleave_state = SkillState.cooldown;
                    cleave_Cooldown_Time_current = cleave_cooldown_time; 
                    using_cleave = false;
                }
            break;
            case SkillState.cooldown:
                if (cleave_Cooldown_Time_current > 0)
                {
                    cleave_Cooldown_Time_current -= Time.deltaTime;
                }
                else{
                    cleave_state = SkillState.ready;
                }
            break;

        }
        switch (attack_state)
        {
            case SkillState.ready:
                if (distance < 5 && using_cleave == false && using_dismantle == false)
                {
                    using_attack = true;
                    StartCoroutine(OnAttack());
                    attack_state = SkillState.cooldown;
                    attack_cooldown_time_current = attack_cooldown_time;
                }
            break;
            case SkillState.cooldown:
                if (attack_cooldown_time_current > 0)
                {
                    attack_cooldown_time_current -= Time.deltaTime;
                }
                else{
                    attack_state = SkillState.ready;
                }
            break;
        }

    }
    private IEnumerator dismantle()
    {
        BossMovement movement = boss.gameObject.GetComponent<BossMovement>();
        BossStats stats = boss.gameObject.GetComponent<BossStats>();
        DismantleAbilityScript dismantleAbility = boss.gameObject.GetComponent<DismantleAbilityScript>();
        movement.canMove = false;
        particles.SetActive(true);
        yield return new WaitForSeconds(3);
        animator.SetBool("Dismantle", true);
        yield return new WaitForSeconds(0.75f);
        dismantleAbility.Dismantle(stats.CurrentATK);
        animator.SetBool("Dismantle",false);
        yield return new WaitForSeconds(0.25f);
        movement.canMove = true;
        using_dismantle = false;
        particles.SetActive(false);
    }
    public IEnumerator OnAttack()
    {
        BossMovement movement = gameObject.GetComponent<BossMovement>();
        movement.canMove = false;
        canAttack = false;
        animator.SetBool("BossAttack", true);
        isAttacking = true;
        //animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(32/60f);
        Hitbox.SetActive(true);
        animator.SetBool("BossAttack", false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.transform.position.x < player.gameObject.transform.position.x)
        {
            Horizontal = 1;
        }
        else
        {
            Horizontal = -1;
        }
        rb.velocity = new Vector2(Horizontal * dashPower, rb.velocity.y);
        yield return new WaitForSeconds(9/60f);
        Hitbox.SetActive(false);
        yield return new WaitForSeconds(19/20f);
        movement.canMove = true;
        canAttack = true;
        using_attack = false;
    }
}
