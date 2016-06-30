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
    public Sprite InfoSprite;
    public Sprite Replacer;
    public bool Is2D;

}

[System.Serializable]
public class Neighbour 
{
    public Location location;
    public float direction;
    public AlternativeArrow altArrow;
}


[System.Serializable]
public class AlternativeArrow
{
    public float x,y;
    public float rotation;

}
