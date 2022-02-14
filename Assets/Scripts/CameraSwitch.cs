using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] Cameras;

    int currentCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
      currentCamera = 0;
      SetCam(currentCamera);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCam(int index)
    {
        for(int i = 0; i < Cameras.Length; i++)
        {
            if(i == index)
            {
                Cameras[i].SetActive(true);
            } else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void toggleCamera()
    {
        currentCamera++;
        if(currentCamera > Cameras.Length-1)
        currentCamera = 0;
        SetCam(currentCamera);
    }
}
