using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerContinuous : DamageDoer
{
    private void OnCollsionStay(Collision other)
    {
        DoDamage(other.gameObject);
    }
}
