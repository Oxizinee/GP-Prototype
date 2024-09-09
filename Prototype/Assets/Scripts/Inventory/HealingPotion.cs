//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;

//[CreateAssetMenu]
//public class HealingPotion : InventoryItem
//{
//    public override void Active(GameObject parent)
//    {
//        if (IsActive)
//        {
//            parent.GetComponent<HPBarBehaviour>().CurrentHP += HalfHP(parent.GetComponent<HPBarBehaviour>().FullHp);
//            IsActive = false;
//        }

//    }

//    public override void Cooldown()
//    {
//        if (!IsActive)
//        {
//            CooldownTimer += Time.deltaTime;
//            if (CooldownTimer >= 60)
//            {
//                IsActive = true;
//                CooldownTimer = 0;
//            }
//        }
//    }
//    public float HalfHP(float number)
//    {
//        return number / 2;
//    }
//}
