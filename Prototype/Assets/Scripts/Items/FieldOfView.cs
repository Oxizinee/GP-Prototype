using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public bool IsActive = false;
    public List<Collider> EnemiesHit = new List<Collider>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")//&& Input.GetMouseButtonDown(0) && IsActive) 
        {
            EnemiesHit.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemiesHit.Remove(other);
        }
    }
    
    void Update()
    {
        if (IsActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                foreach (Collider collision in EnemiesHit)
                {
                    collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP = collision.gameObject.GetComponent<HPBarBehaviour>().CurrentHP - 150;
                }
                IsActive = false;
                gameObject.SetActive(false);
                EnemiesHit.Clear();
            }
        }
    }



}
