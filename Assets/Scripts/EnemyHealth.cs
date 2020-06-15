using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EnemyHealth : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            CmdDestroy();
        }

    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }
    [Command]
    void CmdDestroy()
    {
        NetworkBehaviour.Destroy(gameObject);
    }
    
}
