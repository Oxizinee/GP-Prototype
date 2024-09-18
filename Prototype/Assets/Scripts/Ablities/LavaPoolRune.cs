using IMPossible.Combat.Missle;
using UnityEngine;

namespace IMPossible.Ability
{
    public class LavaPoolRune : Rune 
    {
        public GameObject LavaPoolPrefab;
        public float Range = 6;
        public override void Behaviour(GameObject user)
        {
                for (int i = 0; i < GetStat(RuneStat.NumberOfSpawners); i++)
                {
                    GameObject lavaPool = Instantiate(LavaPoolPrefab, new Vector3(user.transform.position.x + Random.Range(-Range, Range), -1.5f, user.transform.position.z + Random.Range(-Range, Range)), Quaternion.identity);
                lavaPool.GetComponent<LavaPool>().SetLavaPool(user, GetStat(RuneStat.Damage), GetStat(RuneStat.Radius), GetStat(RuneStat.Duration));
                    
                }
        }
    }
}
