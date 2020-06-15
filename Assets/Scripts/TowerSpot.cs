using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

public class TowerSpot : NetworkBehaviour
{
	
	void OnMouseUp()
	{

		Debug.Log("TowerSpot clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if (bm.selectedTower != null)
		{
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
			if (sm.money < bm.selectedTower.GetComponent<Tower>().cost)
			{
				Debug.Log("Not enough money!");
				return;
			}

			sm.money -= bm.selectedTower.GetComponent<Tower>().cost;

			
			// FIXME: Right now we assume that we're an object nested in a parent.
			GameObject InstantiateTower = Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
			NetworkServer.Spawn(InstantiateTower);
			Destroy(transform.parent.gameObject);
		}
	}

	
}
