using Canopy;

public class CheckBool : DecoratorNode
{
    public string query;
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (!blackboard.ContainsEntry(query) || !blackboard.GetEntry<bool>(query))
            return State.Failure;
        return child.Update();
    }
}