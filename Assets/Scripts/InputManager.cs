using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public Player_Controller playerController;

	public LayerMask layerMaskToClick;

	public Transform CameraPivot;

	public GameObject BackWall;
	public GameObject FrontWall;
	public GameObject RightWall;
	public GameObject LeftWall;

	private bool CameraShouldRotate = false;

	public enum CameraState
	{
		Back,
		Front,
		Right,
		Left
	}

	private CameraState CurrentCameraState;

	void Start()
	{
		CurrentCameraState = CameraState.Back;
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Clicked();
		}

		if (CameraShouldRotate)
		{

		}
	}

	private void RotateCameraToState()
	{
		CameraShouldRotate = true;

		if (CurrentCameraState == CameraState.Back)
		{

		}
		else if (CurrentCameraState == CameraState.Left)
		{

		}
		else if (CurrentCameraState == CameraState.Right)
		{
			
		}
		else if (CurrentCameraState == CameraState.Front)
		{
			
		}
	}

	private void MovePlayer(Vector3 PosToMove)
	{
		playerController.MoveToPosition(PosToMove);
	}

	private void Clicked()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray,out hit,layerMaskToClick))
		{
			if (hit.collider.gameObject.CompareTag("CanBePicked"))
			{
				if (hit.collider.gameObject.GetComponent<CanBePicked_Object>())
				{
					MovePlayer(hit.collider.gameObject.GetComponent<CanBePicked_Object>().MoveToPoint.position);
				}
			}
			else if (hit.collider.gameObject.CompareTag("Pol"))
			{
//				Vector3 newPos = new Vector3(transform.position.x,0.6f,transform.position.z);
//				Plane playerPlane = new Plane (Vector3.up, newPos);
//				float hitdist = 0.0f;
//				playerPlane.Raycast(ray, out hitdist);
//				Vector3 targetPoint = ray.GetPoint(hitdist);

				Vector3 targetPoint = hit.point;
				MovePlayer(targetPoint);
			}
		}
	}
}
