using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	private NavMeshAgent agent;

	private bool ShoodRotate = false;
	private Vector3 RotateTarget;
	private float RotateSpeed = 1.5f;
	private Transform AnimationTarget;

	public enum PlayerCanDo
	{
		Nothing,
		PickUpMidHeight,
		PickUpLowHeight,
		PickUpBigHeight
	}

	private PlayerCanDo nextDoing;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (ShoodRotate)
		{
			Vector3 targetDir = RotateTarget - transform.position;
			float step = RotateSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);

			if (Vector3.Angle(transform.forward, targetDir) == 0)
			{
				Debug.Log("Vector3.Angle(transform.forward, targetDir) == 0");
				PlayAnimation();
			}
		}
	}

	private void PlayAnimation()
	{
		Debug.Log("PlayAnimation");
		ShoodRotate = false;
		PickedUpAnimationPlayed();
	}

	public void DoSomethingActive(PlayerCanDo playerDo, Transform target)
	{
		//игрок должен что-то начать делать, для этого отключаем NavMesh
		DeactivateAgent();

		ShoodRotate = true;
		RotateTarget = new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z);

		nextDoing = playerDo;
		AnimationTarget = target;
	}

	private void IsFree()
	{
		//игрок закончил активные действия и снова может перемещаться
		ActivateAgent();
		AnimationTarget = null;
	}

	public void MoveToPosition(Vector3 posToMove)
	{
		//передаем координаты куда нужно двигаться NavMesh агенту
		if (agent.enabled)
		{
			agent.SetDestination(posToMove);
		}
	}

	private void DeactivateAgent()
	{
		agent.enabled = false;
	}
	
	private void ActivateAgent()
	{
		agent.enabled = true;
	}

	public void PickedUpAnimationPlayed()
	{
		//анимация подбора проиграна
		IsFree();
	}

}
