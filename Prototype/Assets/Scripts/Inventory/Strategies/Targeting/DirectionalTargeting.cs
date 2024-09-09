using System.Collections.Generic;
using System;
using UnityEngine;
using log4net.Util;
namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Directional Targeting", menuName = "Inventory/Targeting/Directional", order = 0)]
    public class DirectionalTargeting : TargetingStrategy
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _areaEffectRadius;
        public override void StartTargeting(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distanceToPlane;
            Vector3 direction = Vector3.zero;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                Vector3 targetPoint = ray.GetPoint(distanceToPlane);

                direction = targetPoint - user.transform.position;
                direction.y = 0f;  // Keep the direction in the XZ plane
            }
            callWhenFinished(GetEnemiesInRadius(direction));
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
