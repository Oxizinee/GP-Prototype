using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Inventory
{
    public class AbilityData
    {
        private GameObject _user;
        private Vector3 _targetedPoint;
        private IEnumerable<GameObject> _targets;

        public AbilityData(GameObject user)
        {
            _user = user;
        }

        public IEnumerable<GameObject> GetTargets()
        {
            return _targets;
        }

        public void SetTargets(IEnumerable<GameObject> targets)
        {
            _targets = targets;
        }

        public GameObject GetUser()
        {
            return _user;
        }
        public void SetTargetedPoint(Vector3 point)
        {
            _targetedPoint = point;
        }
        public Vector3 GetTargetedPoint()
        {
            return _targetedPoint;
        }
    }
}
