using UnityEngine;

using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class Location : MonoBehaviour
{
    
    
    public string name;
    public string info;
    public List<Neighbour> neighbours;
    public Vector2 positionOnMap;
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
