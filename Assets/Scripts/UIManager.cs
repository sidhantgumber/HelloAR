using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SessionManager sessionManager;

    public RectTransform messagePanel;
    public RectTransform startARButton;
    public RectTransform stopARButton;
    public TMP_Text messageText;

    void Start()
    {
        messagePanel.gameObject.SetActive(false);
        startARButton.gameObject.SetActive(true);
        stopARButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMessage(string message)
    {
        messagePanel.gameObject.SetActive(true);
        messageText.text = message;
        Invoke(nameof(DisableMessage), 2f);

    }
    private void DisableMessage()
    {
        messagePanel.gameObject.SetActive(false);
    }

    public void StartAR()
    {
        if(sessionManager.StartAR())
        {
            startARButton.gameObject.SetActive(false);
            stopARButton.gameObject.SetActive(true);
            ShowMessage("AR Started");
            Invoke(nameof(DisableMessage), 2f);
        }
    }
    public void StopAR()
    {
        sessionManager.StopAR();
        startARButton.gameObject.SetActive(true);
        stopARButton.gameObject.SetActive(false);
        ShowMessage("AR Stopped");
        Invoke(nameof(DisableMessage), 2f);
    }


}
