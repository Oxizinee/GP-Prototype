using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.Ability
{
    public class RuneStorage : MonoBehaviour
    {
        public List<Rune> RunesHolding = new List<Rune>();
        private bool AlreadyHasIt(Rune rune)
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


        public void AddRune(Rune rune)
        {
            if (AlreadyHasIt(rune))
            {
                rune.UpdateLevel();
            }
            else
            {
                RunesHolding.Add(rune);
                rune.OnAdd();
            }
        }

        public bool Use(int index, GameObject user)
        {
            if (RunesHolding[index] != null)
            {
                RunesHolding[index].Use(user);
                return true;
            }
            return false;
        }
    }
}