using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacementController : MonoBehaviour
{
    [SerializeField]
    GameObject[] placeableObjects;

    GameObject currentPlaceableObject;

    float mouseWheelRotation;

    int currentPrefabIndex = -1;

    float camRayLength = 100f;

    int floorMask;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update ()
    {
        HandleNewObject();

        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateByMouseWheel();
            ReleaseWhenClicked();
        }
	}

    void HandleNewObject()
    {
        for (int i = 0; i < placeableObjects.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1+ i))
            {
                if (PressedKeyOfCurrentPrefab(i))
                {
                    Destroy(currentPlaceableObject);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentPlaceableObject != null)
                    {
                        Destroy(currentPlaceableObject);
                    }

                    currentPlaceableObject = Instantiate(placeableObjects[i]);
                    currentPrefabIndex = i;
                }

                break;
            }
        }
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
    }

    void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    void RotateByMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    void ReleaseWhenClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }


}
