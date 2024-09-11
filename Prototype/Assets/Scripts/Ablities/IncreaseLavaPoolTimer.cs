//using IMPossible.Combat.Missle;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "Abilities/Increase Lava Pool Timer")]
//public class IncreaseLavaPoolTimer : Ability
//{
//    public LavaPool[] lavaPools;
//    public float NewTime = 12;
//    public override void Active(GameObject parent)
//    {

//        lavaPools = FindObjectsByType <LavaPool>(FindObjectsSortMode.None);
//        if (lavaPools != null)
//        {
//            foreach(var pool in lavaPools)
//            {
//                pool.TimeToDie = NewTime;
//            }
//        }
//    }
//}
