using System.Collections.Generic;
using UnityEngine;

namespace Canopy
{

    public class BehaviourTreeController : MonoBehaviour
    {
        public BehaviourTree behaviourTree;
        public Blackboard blackboard;

        private void Awake()
        {
            behaviourTree = behaviourTree.Clone();
            
            //might cause issues with references in editor?
            //seems to be fine...
            blackboard = blackboard.Copy();
            behaviourTree.SetBlackboard(blackboard);
            blackboard.SetBlackboardName(gameObject.name);
        }

        private void Update()
        {
            behaviourTree.Update();
        }
    }

}