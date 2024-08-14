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

    private Quaternion _barRotation, _barRotation2;
    void Start()
    {
        CurrentHP = FullHp;

        if (Type == OwnerType.Enemy)
        {
            _barRotation = HpBarGO.rotation;
            _barRotation2 = HPpivot.rotation;
        }
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
            HpBarGO.rotation = Quaternion.Euler(HpBarGO.eulerAngles.x,HpBarGO.eulerAngles.y,_barRotation.eulerAngles.z);
            HPpivot.rotation = Quaternion.Euler(HPpivot.eulerAngles.x,_barRotation2.eulerAngles.y,HPpivot.eulerAngles.z);
            HPpivot.localScale = new Vector3(Mathf.Clamp(CurrentHP, 0, FullHp) / FullHp,HPpivot.localScale.y, HPpivot.localScale.z);
        }


        if(CurrentHP <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
