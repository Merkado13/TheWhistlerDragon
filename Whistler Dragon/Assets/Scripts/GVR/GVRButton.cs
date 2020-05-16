using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GVRButton : MonoBehaviour
{

    [SerializeField]
    private Image imgLoaded;
    [SerializeField]
    private float timeNeeded = 2.0f;
    [SerializeField]
    private UnityEvent GVRClick;
    [SerializeField]
    private bool isGazeInteractive = true;
    [SerializeField]
    private float loadDownSpeed = 2.0f;

    private bool isBeingActivated = false;
    private float currentLoading = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (isBeingActivated)
        {
            currentLoading += Time.deltaTime;
            if(currentLoading >= timeNeeded)
            {
                GVRClick.Invoke();
            }
        }
        else if(currentLoading > 0)
        {
            currentLoading -= Time.deltaTime * loadDownSpeed;
        }

        currentLoading = Mathf.Clamp(currentLoading, 0.0f, timeNeeded);

        imgLoaded.fillAmount = currentLoading/timeNeeded;
    }

    public void GVROnEnter()
    {
        isBeingActivated = true;
        Debug.Log("Entro");
    }

    public void GRVOnExit()
    {
        isBeingActivated = false;
        Debug.Log("Salgo");
    }
}
