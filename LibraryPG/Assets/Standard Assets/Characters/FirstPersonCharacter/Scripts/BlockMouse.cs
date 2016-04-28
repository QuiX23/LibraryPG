using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class BlockMouse : MonoBehaviour
{
    public FirstPersonController controller;    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<FirstPersonController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Screen.lockCursor = true;
            Debug.Log("coo1");
            controller.m_MouseLook.XSensitivity = 2f;
            controller.m_MouseLook.YSensitivity = 2f;
        }
        else
        {
            Screen.lockCursor = false;

            Debug.Log("coo2");
            controller.m_MouseLook.XSensitivity = 0f;
            controller.m_MouseLook.YSensitivity = 0f;
        }
    }
}
