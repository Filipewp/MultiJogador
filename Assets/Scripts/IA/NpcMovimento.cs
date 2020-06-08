using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovimento : MonoBehaviour
{
    
    public Transform minerio;
    public Transform storage;

    public NavMeshAgent minerador;

    
    bool estado;
    // Start is called before the first frame update
    void Start()
    {
        minerador.SetDestination(minerio.transform.position);
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "minerio")
        {
            minerador.SetDestination(storage.transform.position);
        }
        else if (other.gameObject.tag == "storage")
        {
            if (minerio.gameObject.GetComponent<Recursos>().minerios == 0)
            {
                Destroy(gameObject);
            }
            minerador.SetDestination(minerio.transform.position);
        }
        else if (other.gameObject.tag == "inimigo")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "minerio")
        {
            other.gameObject.GetComponent<Recursos>().minerios--;
          
        }
        else if (other.gameObject.tag == "storage")
        {

            other.gameObject.GetComponent<Storage>().estoque++;
            Debug.Log(other.gameObject.GetComponent<Storage>().estoque);
        }
    }

  
}
