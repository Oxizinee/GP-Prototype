using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Combat
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        public float HP = 10;
        public void TakeDamage(float damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            Debug.Log("Health " + HP);
        }
    }
}
