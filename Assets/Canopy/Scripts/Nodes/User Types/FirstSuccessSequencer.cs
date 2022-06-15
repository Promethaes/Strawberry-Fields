using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Canopy;
public class FirstSuccessSequencer : CompositeNode
{
    int index = 0;
    protected override void OnStart()
    {
        index = 0;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        for (int i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var state = child.Update();
            if (state == State.Success)
                return State.Success;
            else if (state == State.Failure
                    && i + 1 > children.Count - 1)
                return State.Failure;
        }
        return State.Running;

    }

}
