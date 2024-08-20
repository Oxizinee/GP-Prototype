using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealingPotion : Item
{
   [SerializeField] private bool _isActive = true;
    [SerializeField] private float _timer;
    public override void Active(GameObject parent)
    {
        if (_isActive)
        {
            parent.GetComponent<HPBarBehaviour>().CurrentHP += HalfHP(parent.GetComponent<HPBarBehaviour>().FullHp);
            _isActive = false;
        }

        if (!_isActive)
        {
            _timer += Time.deltaTime;
            if (_timer >= 60)
            {
                _isActive = true;
                _timer = 0;
            }
        }
    }

    public float HalfHP(float number)
    {
        return number / 2;
    }
}
