using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DamageDoer : MonoBehaviour
{
    public float damage = 1.0f;
    public UnityEvent OnDidDamage;
    public bool canDoDamage = true;
    public LayerMask collisionlayer;
    //would be nice if i could have an enum that i add to at runtime
    [SerializeField] protected string typeToLookFor = "Health";

    public virtual void DoDamage(GameObject other)
    {
        var onGoodLayer = (other.layer & collisionlayer.value) == 0;
        if (!canDoDamage || !onGoodLayer)
            return;
    Debug.Log("hit");
        var resourcePool = other.GetComponent<ResourcePool>();
        if (!resourcePool)
            return;

        var hp = resourcePool.GetResource(System.Type.GetType(typeToLookFor));
        if (!hp)
            return;

        if (hp.TakeDamage(damage))
            OnDidDamage.Invoke();
    }
}