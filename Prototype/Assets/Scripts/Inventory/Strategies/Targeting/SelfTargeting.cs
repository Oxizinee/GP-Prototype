using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Self Targeting", menuName = "Inventory/Targeting/Self", order = 0)]
    public class SelfTargeting : TargetingStrategy
    {
        public override void StartTargeting(AbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(ActivateTargetPlayer(data,callWhenFinished));
        }

        private IEnumerator ActivateTargetPlayer(AbilityData data, Action callWhenFinished)
        {
            while (true)
            {
                data.SetTargets(TargetPlayer(data.GetUser()));
                data.SetTargetedPoint(data.GetUser().transform.position);
                callWhenFinished();
                break;
            }
            yield return null;
        }
        private IEnumerable<GameObject> TargetPlayer(GameObject user)
        {
                yield return user.gameObject;
        }
    }
}
