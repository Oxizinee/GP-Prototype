using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Core
{
    public class DestroyEffect : MonoBehaviour
    {
        [SerializeField] private float TimeToDestroy = 2;
        void Start()
        {
            Destroy(gameObject, TimeToDestroy);
        }
    }
}
