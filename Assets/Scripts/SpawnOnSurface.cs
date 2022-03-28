using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class SpawnOnSurface : MonoBehaviour
{
    [SerializeField] ARRaycastManager RaycastManager;
    [SerializeField] GameObject objectPrefab;
    [SerializeField] Animator bossAnim;
    [SerializeField] ARSessionOrigin arOrigin;
   // [SerializeField] GameObject reticle;
    // [SerializeField] LayerMask layer;

    private void Awake()
    {
       // reticle = Instantiate(reticle, transform);
    }

    private GameObject spawnedObject;
    void Update()
    {
        if(objectPrefab == null)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
          //  reticle.transform.position = hits[0].pose.position;

        }
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        { 
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
            Debug.Log(Vector2Extensions.IsPointOverUIObject(Input.GetTouch(0).position));
         
            if(hits.Count > 0 && !Vector2Extensions.IsPointOverUIObject(Input.GetTouch(0).position))
            {
                Debug.Log("Avoided UI");
                if (spawnedObject == null)
                {
                    
                   
                    spawnedObject =  Instantiate(objectPrefab, hits[0].pose.position, Quaternion.identity);
                  //  reticle.SetActive(false);
                    //spawnedObject.transform.LookAt(arOrigin.transform.position);
                    spawnedObject.GetComponent<AudioSource>().Play();
                }

                else
                {
                    spawnedObject.transform.position = hits[0].pose.position;
                   // spawnedObject.transform.LookAt(arOrigin.transform.position);
                }
            }
        }
        
    }
    public void ToggleDancing()
    {

        bossAnim.SetTrigger("isDancing");



    }
}
