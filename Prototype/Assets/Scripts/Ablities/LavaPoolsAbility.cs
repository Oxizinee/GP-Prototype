//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "Abilities/Lava Pool")]
//public class LavaPoolsAbility : Ability
//{
//    public float CooldownTime = 10, Range = 15;
//    public GameObject LavaPrefab;

//    private float _timer;
//    public override void Active(GameObject parent)
//    {
//        _timer += Time.deltaTime;

//        if (_timer > CooldownTime)
//        {
//            Instantiate(LavaPrefab, new Vector3(parent.transform.position.x + Random.Range(-Range, Range),-1.5f, parent.transform.position.z + Random.Range(-Range, Range)), Quaternion.identity);
//            _timer = 0;
//        }
//    }
//}
