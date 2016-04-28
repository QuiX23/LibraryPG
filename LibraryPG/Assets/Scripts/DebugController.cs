using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{

    public Transform fpsController;
    public Text AngleText;
	void Update ()
	{

#if UNITY_EDITOR
        AngleText.gameObject.SetActive(true);
        AngleText.text = "Angle "+Mathf.Round(fpsController.eulerAngles.y);
#endif
    }
}
