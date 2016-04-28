using UnityEngine;
using System.Collections;

public class ChangeStateOfButtons : MonoBehaviour
{

    private bool isOver ;
    public GameObject childText;
   
	void Start ()
	{

    }
    void Update ()
    {
        Debug.Log(isOver);
    }

    public void OnPointerEnter()
    {
        isOver = true;
     //   childText.SetActive(true);
    }

    public void OnPointerExit()
    {
        isOver = false;
      //  childText.SetActive(false);
    }
}
