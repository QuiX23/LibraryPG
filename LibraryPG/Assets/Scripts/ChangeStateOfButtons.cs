using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeStateOfButtons : MonoBehaviour
{

    private bool isOver=false ;
    public Text text;
    private BlockMouse blockMouse;
	void Start ()
	{
	    blockMouse = Object.FindObjectOfType<BlockMouse>();
	}
    void Update ()
    {
        text.enabled = isOver;
    }

    public void OnPointerEnterZ()
    {
        isOver = true;
        //blockMouse.isOver = true;
    }

    public void OnPointerExitZ()
    {
        isOver = false;
       // blockMouse.isOver = false;
    }
}
