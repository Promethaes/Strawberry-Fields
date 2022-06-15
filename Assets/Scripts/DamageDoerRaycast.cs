using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerRaycast : DamageDoer
{
    [SerializeField] private float maxDistance = 100.0f;
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, collisionlayer, QueryTriggerInteraction.Ignore))
            DoDamage(hit.collider.gameObject);
    }

    public float GetMaxDistance()
    {
        return maxDistance;
    }

    public LayerMask GetCollisionMask()
    {
        return collisionlayer;
    }
}
