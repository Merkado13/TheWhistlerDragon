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

    private bool alreadyActivated = false;

    // Update is called once per frame
    void Update()
    {

        if (isGazeInteractive)
        {
            if (isBeingActivated)
            {
                upLoad();          
            }
            else if (currentLoading > 0)
            {
                downLoad();
            }
        }

        currentLoading = Mathf.Clamp(currentLoading, 0.0f, timeNeeded);
        imgLoaded.fillAmount = currentLoading/timeNeeded;
    }

    public void upLoad()
    {
        //isBeingActivated = true;
        currentLoading += Time.deltaTime;
        if (currentLoading >= timeNeeded && !alreadyActivated)
        {
            currentLoading = 0.0f;
            isBeingActivated = false;
            alreadyActivated = false;
            GVRClick.Invoke();
        }
    }

    public void downLoad()
    {
        currentLoading -= Time.deltaTime * loadDownSpeed;
        if(currentLoading/timeNeeded < 0.75f)
        {
            alreadyActivated = false;
        }
    }

    public void GVROnEnter()
    {
        if (isGazeInteractive)
        {
            isBeingActivated = true;
            Debug.Log("Entro");
        }
    }

    public void GRVOnExit()
    {
        if (isGazeInteractive)
        {
            isBeingActivated = false;
            Debug.Log("Salgo");
        }
    }

    public void setIsGazeInteractive(bool isGazeInteractive)
    {
        this.isGazeInteractive = isGazeInteractive;
    }

    public void setIsBeingActivated(bool isBeingActivated)
    {
        this.isBeingActivated = isBeingActivated;
    }
}
