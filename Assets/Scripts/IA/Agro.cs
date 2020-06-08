using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agro : MonoBehaviour
{
    public NavMeshAgent inimigo;
    
     GameObject[] targets;

    void Start()
    {

    }

    void Update()
    {

    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "npc")
        {
            inimigo.SetDestination(other.gameObject.transform.position);
        }
    }
    void findenemy(string tag) {

        targets = GameObject.FindGameObjectsWithTag(tag);
    }
        
}
