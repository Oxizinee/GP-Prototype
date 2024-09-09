using System.Collections.Generic;
using System;
using UnityEngine;
using log4net.Util;
using System.Collections;

namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Area Of Effect Targeting", menuName = "Inventory/Targeting/AOE", order = 0)]
    public class AreaOfEffect : TargetingStrategy
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _areaEffectRadius;
        public override void StartTargeting(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            user.GetComponent<MonoBehaviour>().StartCoroutine(Targeting(callWhenFinished));
        }

        private IEnumerator Targeting(Action<IEnumerable<GameObject>> finished)
        {
            while (true)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 1000, _layerMask))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Absorb the whole mouse click
                        yield return new WaitWhile(() => Input.GetMouseButton(0));
                        finished(GetEnemiesInRadius(raycastHit.point));
                        break;
                    }
                }
                yield return null;
            }
        }
        private IEnumerable<GameObject> GetEnemiesInRadius(Vector3 point)
        {
            RaycastHit[] hits = Physics.SphereCastAll(point, _areaEffectRadius, Vector3.up, 0);
            foreach (var hit in hits)
            {
                yield return hit.collider.gameObject;
            }
        }
    }
}
