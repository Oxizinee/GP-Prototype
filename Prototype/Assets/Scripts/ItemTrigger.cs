using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Item Item;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<ItemHolder>().ItemsHolding.Count <= 3 && !other.GetComponent<ItemHolder>().ItemsHolding.Contains(Item))
        {
            other.GetComponent<ItemHolder>().ItemsHolding.Add(Item);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Destroy(gameObject, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
