using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public Camera[] cameras;
    private int currrentCameraIndex;
    
    void Start()
    {
        currrentCameraIndex = 0;
        cameras[1].gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameras[currrentCameraIndex].gameObject.SetActive(false);
            if (currrentCameraIndex + 1 == cameras.Length)
            {
                currrentCameraIndex = 0;
            }
            else
            {
                currrentCameraIndex++;
            }
            cameras[currrentCameraIndex].gameObject.SetActive(true);
        }
    }
}

