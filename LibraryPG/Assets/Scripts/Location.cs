using UnityEngine;

using System.Collections.Generic;

public class Location : MonoBehaviour
{
    public string name;
    public string info;
    public List<Neighbour> neighbours;
    public Material skybox;
    
}

[System.Serializable]
public class Neighbour 
{
    public Location location;
    public Vector3 direction;

    public void GoTo()
    {
        MainController.GetInstance().ChangeLocation(location);
    }
}
