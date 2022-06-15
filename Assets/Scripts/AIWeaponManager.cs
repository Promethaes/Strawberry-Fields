using UnityEngine;
using Canopy;
public class AIWeaponManager : MonoBehaviour
{
    [SerializeField] Blackboard blackboard;
    [SerializeField] WeaponManager weaponManager;

    private void Start()
    {
        blackboard.UpdateEntry("WeaponManager", this);
    }

    public void Attack()
    {
        weaponManager.OnPrimaryWeapon();
    }

    public bool CanAttack()
    {
        return weaponManager.CanPrimaryAttack();
    }
}