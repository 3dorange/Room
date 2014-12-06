using UnityEngine;
using System.Collections;

public class TargetToLookAt : MonoBehaviour 
{
	public Transform Target;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<Player_Controller>().DoSomethingActive(Player_Controller.PlayerCanDo.PickUpMidHeight, Target);
		}
	}
}
