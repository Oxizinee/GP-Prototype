using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

namespace IMPossible.Ability.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Area Of Effect Targeting", menuName = "Inventory/Targeting/AOE", order = 0)]
    public class AreaOfEffect : TargetingStrategy
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _areaEffectRadius;
        [SerializeField] private GameObject _circlePrefab;

        private GameObject _circleInstance;
        public override void StartTargeting(AbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(Targeting(data, callWhenFinished));
        }

        private IEnumerator Targeting(AbilityData data, Action finished)
        {
            if(_circleInstance == null)
            {
                _circleInstance = Instantiate(_circlePrefab);
            }
            else
            {
                _circleInstance.SetActive(true);
            }
            _circleInstance.transform.localScale = new Vector3(_circlePrefab.transform.localScale.x * _areaEffectRadius, 
                _areaEffectRadius, _circlePrefab.transform.localScale.z * _areaEffectRadius);
            while (true)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(GetMouseRay(), out raycastHit, 1000, _layerMask))
                {
                    _circleInstance.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y + 0.5f, raycastHit.point.z);
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Absorb the whole mouse click
                        yield return new WaitWhile(() => Input.GetMouseButton(0));
                        data.SetTargetedPoint(raycastHit.point);
                        _circleInstance.SetActive(false);
                        data.SetTargets(GetEnemiesInRadius(raycastHit.point));
                        finished();
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
        private Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }
}
