using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;
public class BlockMouse : MonoBehaviour

{
    private FirstPersonController controller;
    public bool isOver = false;
    public GameObject arrow;
    void Start()
    {
        controller = GetComponent<FirstPersonController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) &&
            !MainController.GetInstance().InfoOn &&
            !MainController.GetInstance().MapOn)
        {
            controller.m_MouseLook.XSensitivity = 2f;
            controller.m_MouseLook.YSensitivity = 2f;
        }
        else
        {
            Screen.lockCursor = false;
            controller.m_MouseLook.XSensitivity = 0f;
            controller.m_MouseLook.YSensitivity = 0f;
        }
    }

    public void OnPointerEnter()
    {

        //arrow.SetActive(true);
        isOver = true;
    }

    public void OnPointerExit()
    {
        //Debug.Log("Mouse exit");
        isOver = false;
        //arrow.SetActive(false);

    }
}
