using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update;
    public float AttackDamage(float AttackDamage){

        return Mathf.Clamp(AttackDamage, 0f,100f);
    }
}
