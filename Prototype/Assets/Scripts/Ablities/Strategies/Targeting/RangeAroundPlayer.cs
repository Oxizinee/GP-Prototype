using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

namespace IMPossible.Ability.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Range Around Player", menuName = "Inventory/Targeting/Range Around Player", order = 0)]
    public class RangeAroundPlayer : TargetingStrategy
    {
        [SerializeField] private float _areaEffectRadius;
        [SerializeField] private GameObject _circlePrefab;

        private GameObject _circleInstance;
        public override void StartTargeting(AbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(Targeting(data, callWhenFinished));
        }

        private IEnumerator Targeting(AbilityData data, Action finished)
        {
            if (_circleInstance == null)
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
                data.SetTargetedPoint(new Vector3(data.GetUser().transform.position.x, data.GetUser().transform.position.y + 0.1f, data.GetUser().transform.position.z));
                _circleInstance.transform.position = new Vector3(data.GetUser().transform.position.x, data.GetUser().transform.position.y + 0.1f, data.GetUser().transform.position.z);
                data.SetTargets(GetEnemiesInRadius(data.GetUser().transform.position));
                finished();
                yield return new WaitForSeconds(3);
            }
        }
        private IEnumerable<GameObject> GetEnemiesInRadius(Vector3 playerPosition)
        {
            RaycastHit[] hits = Physics.SphereCastAll(playerPosition, _areaEffectRadius, Vector3.up, 0);
            foreach (var hit in hits)
            {
                yield return hit.collider.gameObject;
            }
        }
    }
}
