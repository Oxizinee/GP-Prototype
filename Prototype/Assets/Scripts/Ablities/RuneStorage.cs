using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Ability
{
    public class RuneStorage : MonoBehaviour
    {
        public List<Rune> RunesHolding = new List<Rune>();

        public bool AlreadyHasIt(Rune rune)
        {
            for (int i = 0; i < RunesHolding.Count; i++)
            {
                if (object.ReferenceEquals(RunesHolding[i], rune))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Use(int index, GameObject user)
        {
            if (RunesHolding[index] != null)
            {
                RunesHolding[index].GetPassiveEffect(user);
                return true;
            }
            return false;
        }
    }
}