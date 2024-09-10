using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Range Around Player With Click Targeting", menuName = "Inventory/Targeting/Range Around Player With Click", order = 0)]
    public class RangeAroundPlayerWithClick : TargetingStrategy
    {
        [SerializeField] private float _areaEffectRadius;
        [SerializeField] private GameObject _circlePrefab;

        private GameObject _circleInstance;
        public override void StartTargeting(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            user.GetComponent<MonoBehaviour>().StartCoroutine(Targeting(user,callWhenFinished));
        }

        private IEnumerator Targeting(GameObject user, Action<IEnumerable<GameObject>> finished)
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
                    _circleInstance.transform.position = new Vector3(user.transform.position.x, user.transform.position.y + 0.1f, user.transform.position.z);
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Absorb the whole mouse click
                        yield return new WaitWhile(() => Input.GetMouseButton(0));
                        _circleInstance.SetActive(false);
                        finished(GetEnemiesInRadius(user.transform.position));
                        break;
                    }
                yield return null;
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
