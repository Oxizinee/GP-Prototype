using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Self Targeting", menuName = "Inventory/Targeting/Self", order = 0)]
    public class SelfTargeting : TargetingStrategy
    {
        public override void StartTargeting(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            user.GetComponent<MonoBehaviour>().StartCoroutine(ActivateTargetPlayer(user,callWhenFinished));
        }

        private IEnumerator ActivateTargetPlayer(GameObject user, Action<IEnumerable<GameObject>> callWhenFinished)
        {
            while (true)
            {
                callWhenFinished(TargetPlayer(user));
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
