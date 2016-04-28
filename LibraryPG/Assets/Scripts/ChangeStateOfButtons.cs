using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeStateOfButtons : MonoBehaviour
{

    private bool isOver ;
    public GameObject childText;
    public Text text;
   
	void Start ()
	{
	    text = childText.GetComponent<Text>();
	}
    void Update ()
    {
        Debug.Log(isOver);
    }

    public void OnPointerEnter()
    {
        isOver = true;
        //text.enabled = !text.enabled;
    }

    public void OnPointerExit()
    {
        isOver = false;
        //text.enabled = !text.enabled;
    }
}
