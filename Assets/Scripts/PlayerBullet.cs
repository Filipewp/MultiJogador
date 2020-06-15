using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        if (health !=null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);

        EnemyHealth enemyhealth = hit.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.TakeDamage(10);
        }
        Destroy(gameObject);
    }

}
