using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Canopy;
public class ForceFail : DecoratorNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }
    //workaround because I want AI to either chase OR
    //wonder
    protected override State OnUpdate()
    {
        var state = child.Update();
        if(state != State.Running)
            return State.Failure;
        return State.Running;
    }
}
