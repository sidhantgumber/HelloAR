using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class SpawnOnSurface : MonoBehaviour
{
    public ARRaycastManager RaycastManager;
    public GameObject objectPrefab;

    private GameObject spawnedObject;
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        { 
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);

            if(hits.Count > 0)
            {
                if (spawnedObject == null)
                {
                  spawnedObject =  Instantiate(objectPrefab, hits[0].pose.position, hits[0].pose.rotation);
                }

                else
                {
                    spawnedObject.transform.position = hits[0].pose.position;
                }
            }
        }
        
    }
}
