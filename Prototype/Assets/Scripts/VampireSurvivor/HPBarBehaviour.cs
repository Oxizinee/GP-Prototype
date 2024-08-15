using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OwnerType
{
    Player,
    Enemy
}

public class HPBarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public OwnerType Type;
    public float FullHp = 10, CurrentHP;
    public Image HPBar;
    public Transform HPpivot;
    public Transform HpBarGO;

    void Start()
    {
        CurrentHP = FullHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Type == OwnerType.Player)
        {
            HPBar.fillAmount = Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp;
        }
        else
        {
            HPpivot.localScale = new Vector3(Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp,HPpivot.localScale.y, HPpivot.localScale.z);
            if (CurrentHP <= 0)
            {
                Destroy(gameObject);
                GetComponent<Enemy>().Player.GetComponent<XPBar>().XPCurrent++;
            }
        }


        
    }
}
