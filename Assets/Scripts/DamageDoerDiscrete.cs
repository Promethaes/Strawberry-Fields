using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerDiscrete : DamageDoer
{
    private void OnCollisionEnter(Collision other)
    {
        DoDamage(other.gameObject);
    }
}
