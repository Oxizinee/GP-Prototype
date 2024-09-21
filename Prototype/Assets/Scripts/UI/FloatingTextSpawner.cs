using IMPossible.Supplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IMPossible.UI
{
    public class FloatingTextSpawner :MonoBehaviour
    {
        [SerializeField] FloatingText _floatingText;

        private void Awake()
        {
            GetComponent<Health>().OnDamageTaken += Spawn;
        }

        private void Spawn(float damageAmount)
        {
            FloatingText text = Instantiate(_floatingText, transform.position, Quaternion.identity, transform);
            text.SetValue(damageAmount);
        }
    }
}
