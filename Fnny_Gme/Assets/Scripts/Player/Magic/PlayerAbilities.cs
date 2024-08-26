using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : ScriptableObject
{
    public new string name;
    public float CooldownTime;
    public float ActiveTime;

    public virtual void Activate(GameObject parent)
    {

    }   
}
