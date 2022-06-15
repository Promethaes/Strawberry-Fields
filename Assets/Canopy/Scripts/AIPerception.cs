using UnityEngine;
using UnityEngine.Events;

namespace Canopy
{
    public class AIPerception : MonoBehaviour
    {
        [SerializeField] protected LayerMask layerMask;
        [SerializeField] float staleTime = 10.0f;

        [Header("References")]
        [SerializeField] protected Blackboard blackboard = null;

        public UnityEvent OnPerceive;
        public UnityEvent OnStale;
        GameObject target = null;
        float senseTime = 0.0f;


        private void OnTriggerEnter(Collider other)
        {
            if ((other.gameObject.layer & ~layerMask) == 0)
                return;
            target = other.gameObject;
            blackboard.UpdateEntry("spottedPos", target.transform.position);
            senseTime = 0.0f;
            OnPerceive.Invoke();
        }

        private void Update()
        {
            if (target == null)
                return;
            senseTime += Time.deltaTime;
            if (senseTime >= staleTime)
            {
                OnStale.Invoke();
                senseTime = 0.0f;
                target = null;
            }
            else
                blackboard.UpdateEntry("spottedPos", target.transform.position);

        }

        public void ClearSpottedPos()
        {
            blackboard.UpdateEntry("spottedPos", null);
        }

        //problem: each BT controller sets the name property of
        //the blackboard provided to the gameObject's name.
        //This means that multiple entities using the same blackboard
        //will overwrite the blackboard's name, breaking some stuff.

        //Solutions:
        //- make the blackboard programatically for each BT controller.
        //could clone it like we do for the BT. Only thing is we won't
        //have a global blackboard for each zombie.
        //- keep a dictionary of owner names inside the blackboard
        //need to figure out a way to match given name
        public void SetWithinRange(bool yn)
        {
            blackboard.UpdateEntry("withinRange", yn);
        }
        
        //For attacking:
        // -stop agent in place (navigation)
        // -tell agent to attack (weapon manager)
        // -tell agent to continue (navigation)

        //problem: how to add weapon manager to blackboard
        //solution: AIWeaponManager, includes a WM reference
        //and takes reference to a blackboard, stores itself in the
        //blackboard
    }
}