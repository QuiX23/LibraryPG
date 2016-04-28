using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Neighbour : MonoBehaviour
{

   public Location location;
   public Vector3 direction;
    
    public void Start()
    {
        transform.LookAt(new Vector3(0,transform.position.y,0));
    }

    public void GoTo()
    {
        MainController.GetInstance().ChangeLocation(location);
    }
}
