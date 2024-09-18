using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IMPossible.Ability
{
    public class RuneStorage : MonoBehaviour
    {
        public Rune[] RunesHolding;

        public event Action OnStorageChanged;

        private int _storageSize = 3;

        private void Awake()
        {
            RunesHolding = new Rune[_storageSize];
        }
        private bool AlreadyHasIt(Rune rune)
        {
            for (int i = 0; i < RunesHolding.Length; i++)
            {
                if (object.ReferenceEquals(RunesHolding[i], rune))
                {
                    return true;
                }
            }
            return false;
        }

        public Rune GetRune(int id)
        {
            if (RunesHolding.GetValue(id) != null)
            {
                return RunesHolding[id];
            }
            return null;
        }

        public int GetLevelInSlot(int slot)
        {
            if (RunesHolding.GetValue(slot) != null)
            {
                return RunesHolding[slot].GetCurrentLevel();
            }
            return 0;
        }
        public void AddToFirstEmptySlot(Rune rune)
        {
            if (AlreadyHasIt(rune))
            {
                rune.UpdateLevel();
                OnStorageChanged?.Invoke();
            }
            else
            {
                int i = FindEmptySlot();

                RunesHolding[i] = rune;
                rune.OnAdd();
            }

            OnStorageChanged?.Invoke();
        }
        private int FindEmptySlot()
        {
            for (int i = 0; i < RunesHolding.Length; i++)
            {
                if (RunesHolding[i] == null)
                {
                    return i;
                }
            }
            return -1; // returns -1 if all slots are full
        }

        public bool Use(int index, GameObject user)
        {
            if (RunesHolding.GetValue(index) != null)
            {
                RunesHolding[index].Use(user);
                return true;
            }
            return false;
        }
    }
}