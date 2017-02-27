using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RaycastMovement : MonoBehaviour
{

	public GameObject raycastHolder;
	public GameObject raycastIndicator;
	public GameObject cube;

	public float height = 2;
	public float maxMoveDistance = 10;
	
	private bool moving = false;

	RaycastHit hit;
	float theDistance;


	void Update () {

        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //if (raycastHolder.activeSelf == true || raycastIndicator.activeSelf == true)
        //{
        //    raycastHolder.SetActive(false);
        //    raycastIndicator.SetActive(false);
        //}

        //return;
        //}
        //else
        //{
        Vector3 forwardDir = raycastHolder.transform.TransformDirection(Vector3.forward) * 100;
			Debug.DrawRay(raycastHolder.transform.position, forwardDir, Color.blue);

			if (Physics.Raycast(raycastHolder.transform.position, (forwardDir), out hit))
			{
				if (hit.collider.gameObject.layer == 8)
				{
					if (raycastHolder.activeSelf == false || raycastIndicator.activeSelf == false)
					{
						raycastHolder.SetActive(true);
						raycastIndicator.SetActive(true);
					}

					raycastIndicator.transform.position = hit.point;

					if (hit.distance <= maxMoveDistance)
					{
						//Teleport(hit.point);
					}
				}
                else if (hit.collider.gameObject.layer != 8)
                {
                    if (raycastHolder.activeSelf == true || raycastIndicator.activeSelf == true)
                    {
                        raycastHolder.SetActive(false);
                        raycastIndicator.SetActive(false);
                    }

                    return;
                }
			}
			else
			{
				if (raycastHolder.activeSelf == true || raycastIndicator.activeSelf == true)
				{
					raycastHolder.SetActive(false);
					raycastIndicator.SetActive(false);
				}
			}
		//}
	}

	public void Teleport(Vector3 location) {
		Camera.main.transform.parent.position = new Vector3(location.x, location.y + height, location.z);
	}

	public void OnClick()
	{
        if (hit.collider.gameObject.layer == 9)
        {
            return;
        }

		if (hit.distance <= maxMoveDistance)
		{
			Teleport(hit.point);
		}
	}
}
