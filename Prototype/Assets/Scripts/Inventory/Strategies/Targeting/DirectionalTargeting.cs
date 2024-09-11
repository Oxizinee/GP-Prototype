﻿using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
using log4net.Util;
namespace IMPossible.Inventory.Strategies.Targeting
{
    [CreateAssetMenu(fileName = "Directional Targeting", menuName = "Inventory/Targeting/Directional", order = 0)]
    public class DirectionalTargeting : TargetingStrategy
    {
        public override void StartTargeting(AbilityData data, Action callWhenFinished)
        {
            data.GetUser().GetComponent<MonoBehaviour>().StartCoroutine(Targeting(data, callWhenFinished));
        }

        private IEnumerator Targeting(AbilityData data, Action callWhenFinished)
        {
            while (true)
            {
                Vector3 playersPos = new Vector3(data.GetUser().transform.position.x, data.GetUser().transform.localScale.y / 2, data.GetUser().transform.position.z);
                    if (Input.GetMouseButtonDown(0))
                    {
                        yield return new WaitWhile(() => Input.GetMouseButton(0));
                        data.SetTargetedPoint(playersPos);
                        callWhenFinished();
                        break;
                    }
                yield return null;
            }
        }

        
    }
}
