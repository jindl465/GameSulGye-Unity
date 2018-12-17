using UnityEngine;
using System.Collections;

//카메라를 컨트롤하는 스크립트입니다.

public class CameraControl : MonoBehaviour
{
    public Camera[] cameras;
    private int currrentCameraIndex; //현재 어느 카메라인지 알려주는 변수입니다.
    
    void Start()
    {
        //시작은 현재 카메라 인덱스를 처음인 0으로 만들고 현재 카메라를 제외한 다른 카메라의 active 상태를 false로 만들어 줍니다.
        //현재 프로젝트에서는 카메라를 두개만 사용하기 때문에 다음 인덱스인 1에 해당하는 카메라만 false상태로 만들었습니다.
        currrentCameraIndex = 0;
        cameras[1].gameObject.SetActive(false);
    }
    void Update()
    {
        //F키를 누르면 다른 카메라로 바꿉니다.
        if (Input.GetKeyDown(KeyCode.F))
        {
            //현재 카메라를 false 상태로 만들어줍니다.
            cameras[currrentCameraIndex].gameObject.SetActive(false);
            if (currrentCameraIndex + 1 == cameras.Length) //현재 카메라가 마지막 카메라였다면 다시 인덱스를 0으로 만들어줍니다.
            {
                currrentCameraIndex = 0;
            }
            else //현재 카메라가 마지막 카메라가 아니라면 인덱스를 1 추가합니다.
            {
                currrentCameraIndex++;
            }
            //카메라 인덱스 설정이 끝나고 다음 카메라를 true로 설정합니다.
            cameras[currrentCameraIndex].gameObject.SetActive(true);
        }
    }
}

