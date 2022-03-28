using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



public class SessionManager : MonoBehaviour
{
    private ARSession _arSession;
    public UIManager uiManager;

    private void Awake()
    {
        _arSession = GetComponent<ARSession>();
    }

    void Start()
    {
        _arSession.enabled = false;
    }

    
    void Update()
    {
        
    }
    public bool StartAR()
    {
        if(ARSession.state == ARSessionState.Unsupported)
        {
            uiManager.ShowMessage("Device unsupported");
            

        }
        else if(ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.Ready || ARSession.state == ARSessionState.SessionTracking)
        {
            _arSession.enabled = true;
            return true;
        }
        return false;
    }
    public void StopAR()
    {
        _arSession.enabled = false;
    }
}
