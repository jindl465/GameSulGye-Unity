using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public static Vector3 originPosition;
    public static Quaternion originQuaternion;
    public Camera[] cameras;
    private int currrentCameraIndex;
    void Start()
    {
        currrentCameraIndex = 0;
        cameras[1].gameObject.SetActive(false);
        originPosition = transform.position;
        originQuaternion = transform.rotation;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
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

