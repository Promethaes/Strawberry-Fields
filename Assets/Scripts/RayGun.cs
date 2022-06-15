using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayGun : Weapon
{
    [SerializeField] int ammo = 10;
    [SerializeField] float rayActiveTime = 0.15f;

    [Header("References")]
    [SerializeField] Transform tipOfGun = null;

    List<Transform> _bulletEmitterPoints = new List<Transform>();
    int _ammo = 0;
    // Start is called before the first frame update

    private void Start()
    {
        GetEmitterPoints();
        SetRaysActive(false);
    }

    public override void Attack()
    {
        foreach (var bep in _bulletEmitterPoints)
            if (bep.gameObject.activeSelf)
                return;
        if (!CanAttack)
            return;
        base.Attack();

        SetRaysActive(true);

        IEnumerator DisableRays()
        {
            yield return new WaitForSeconds(rayActiveTime);
            SetRaysActive(false);
        }
        StartCoroutine(DisableRays());

    }

    private void OnDrawGizmos()
    {
        if (!Application.isEditor)
            return;
        GetEmitterPoints();
        Handles.color = Color.red;
        foreach (var bep in _bulletEmitterPoints)
        {
            var dir = bep.position - tipOfGun.position;
            dir = dir.normalized;
            var p2 = bep.position + dir * 20.0f;
            Handles.DrawLine(tipOfGun.position, bep.position);
            Handles.DrawDottedLine(tipOfGun.position, p2, 20.0f);
        }
    }

    void SetRaysActive(bool yn)
    {
        foreach (var bep in _bulletEmitterPoints)
            bep.gameObject.SetActive(yn);
    }

    void GetEmitterPoints()
    {
        for (int i = 0; i < _bulletEmitterPoints.Count; i++)
            if (_bulletEmitterPoints[i] == null)
            {
                _bulletEmitterPoints.RemoveAt(i);
                i--;
            }

        var children = tipOfGun.GetComponentInChildren<Transform>();
        foreach (Transform child in children)
            if (!_bulletEmitterPoints.Contains(child))
                _bulletEmitterPoints.Add(child);
    }
}
