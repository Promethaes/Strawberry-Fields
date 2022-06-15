using UnityEngine;

using Canopy;
public class MeleeAttack : ActionNode
{
    AINavigation navigation = null;
    AIWeaponManager weaponManager = null;
    protected override void OnStart()
    {
        if (navigation == null)
            navigation = blackboard.GetEntryFromThis<AINavigation>("Nav");
        if (weaponManager == null)
            weaponManager = blackboard.GetEntry<AIWeaponManager>("WeaponManager");

        navigation.GetNavMeshAgent().isStopped = true;
        weaponManager.Attack();
    }
    protected override void OnStop()
    {
        navigation.GetNavMeshAgent().isStopped = false;
    }
    //make a test melee weapon
    protected override State OnUpdate()
    {
        if (!weaponManager.CanAttack())
            return State.Running;
        return State.Success;
    }
}