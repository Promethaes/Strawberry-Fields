using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerContinuousTrigger : DamageDoer
{
    private void OnTriggerStay(Collider other)
    {
        DoDamage(other.gameObject);
    }
}
