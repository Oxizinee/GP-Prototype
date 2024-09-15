using Codice.CM.Common;
using IMPossible.Combat.Missle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Ability
{
    public class ImpishMagicRune : Rune
    {
        public GameObject BulletPrefab;
        public override void Behaviour(GameObject user)
        {
            for (int i = 0; i < GetStat(RuneStat.NumberOfSpawners); i++)
            {
                GameObject go = Instantiate(BulletPrefab, new Vector3(user.transform.position.x, user.transform.localScale.y / 2, user.transform.position.z), BulletRotation(user, i));
                go.GetComponent<BasicBullet>().SetProperties(user, 10, 8, 0.5f, GetStat(RuneStat.Damage), false);
            }
        }

        private Quaternion BulletRotation(GameObject user, int i)
        {
            float arcAngle = 180f;

            if (GetStat(RuneStat.NumberOfSpawners) == 1)
            {
                return user.transform.rotation;
            }

            // Calculate the angle step between bullets (evenly distribute within the arc)
            float angleStep = arcAngle / (GetStat(RuneStat.NumberOfSpawners) - 1);

            int middleIndex = ((int)GetStat(RuneStat.NumberOfSpawners) - 1) / 2;

            // Calculate the actual angle for this specific bullet
            float bulletAngle = (i - middleIndex) * angleStep;

            return Quaternion.Euler(user.transform.rotation.eulerAngles.x, user.transform.rotation.eulerAngles.y + bulletAngle, user.transform.rotation.eulerAngles.z);
        }
    }
}
