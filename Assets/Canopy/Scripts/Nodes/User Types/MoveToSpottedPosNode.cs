using UnityEngine;

using Canopy;
public class MoveToSpottedPosNode : ActionNode
{
    AINavigation navigation = null;
    protected override void OnStart()
    {
        if (navigation == null)
            navigation = blackboard.GetEntryFromThis<AINavigation>("Nav");
    }
    protected override void OnStop()
    {
    }
    protected override State OnUpdate()
    {
        var dest = blackboard.GetEntry<Vector3>("spottedPos");

        navigation.SetDestination(dest);
        if (!navigation.IsMoving())
            return State.Success;
        return State.Running;
    }
}