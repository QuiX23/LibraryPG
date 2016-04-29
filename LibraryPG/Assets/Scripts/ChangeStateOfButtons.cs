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
        
        //Debug.Log(isOver);
        if (isOver)
        {
            text.enabled = true;

        }
        else
        {
            text.enabled = false;
        }
    }

    public void OnPointerEnterZ()
    {
        isOver = true;
       // blockMouse.isOver = true;
        //blockMouse.isOver = true;
    }

    public void OnPointerExitZ()
    {
        isOver = false;
       // blockMouse.isOver = false;
        //blockMouse.isOver = false;
    }
}
