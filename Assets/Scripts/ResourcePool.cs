using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcePool : MonoBehaviour
{
    [SerializeField] List<Health> resourcePool = new List<Health>();

    [SerializeField] UnityEvent OnDie = null;

    public bool isDead { get; private set; }
    bool died = false;
    private void Start()
    {
        IEnumerator DeathCheck()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                foreach (var health in resourcePool)
                    isDead |= health.died;
                if (isDead && !died)
                {
                    died = true;
                    OnDie.Invoke();
                }
            }
        }
        StartCoroutine(DeathCheck());
    }

    public Health GetResource(System.Type type)
    {
        foreach (var resource in resourcePool)
            if (resource.GetType() == type)
                return resource;
        return null;
    }


}
