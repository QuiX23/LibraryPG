using System;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine.UI;


public class MainController : MonoBehaviour
{
    #region Singleton patter
    private static MainController instance = null;

    private MainController() { }

    public static MainController GetInstance()
    {
        return instance ?? (instance = new MainController());
    }

    #endregion

    public Location currentLocation;
    
    public List<Location> locations;

    public GameObject arrowPrefab;
    public GameObject placemarkPrefab;

    public Dictionary <string ,Button> placemarks;

    public RectTransform arrows;
    public RectTransform map;

    private bool mapOn=false;

    public void ChangeLocation(Location location)
    {
        ColorBlock cb = placemarks[currentLocation.name].colors;
        cb.normalColor = Color.white;
        placemarks[currentLocation.name].colors = cb;

        cb = placemarks[location.name].colors;
        cb.normalColor = Color.green;
        placemarks[location.name].colors = cb;
        placemarks[location.name].Select();

        currentLocation = location;
        RenderSettings.skybox = currentLocation.skybox;
        SetNeighbours(location);
    }

    public void Start()
    {

        instance = this;
        SetupMap();
        ChangeLocation(currentLocation);
    }

    void SetupMap()
    {
        if (map == null) return;

        placemarks=new Dictionary<string, Button>();

        foreach (Location location in locations)
        {
            GameObject go = Instantiate(placemarkPrefab);
            go.name = "Placmark_" + location.name;
            go.transform.parent = map;
            go.transform.localPosition = new Vector3((location.positionOnMap.x - 0.5f )*map.rect.width,
                                                    (location.positionOnMap.y - 0.5f) *map.rect.height,
                                                    0);
            Button button = go.GetComponent<Button>();

            ColorBlock cb1 = button.colors;
            cb1.normalColor = Color.white;
            button.colors = cb1;

            placemarks.Add(location.name, button);

            //Debug.Log("Placmark_" + location.name+" "+ map.rect.width+" "+ map.rect.height);
            string tmp = location.name;
            button.onClick.AddListener(delegate () { this.MapJump(tmp); });

        }

        ColorBlock cb2 = placemarks[currentLocation.name].colors;
        cb2.normalColor = Color.green;
        placemarks[currentLocation.name].colors = cb2;
        placemarks[currentLocation.name].Select();
    }

    void SetNeighbours(Location location)
    {
        if (arrows == null) return;

        DestroyNeighbours(location);
        LoadNeighbours(location);
    }

    void DestroyNeighbours(Location location)
    {
        foreach (RectTransform arrow in arrows)
        {
            Destroy(arrow.gameObject);
        }
    }

    void LoadNeighbours(Location location)
    {

        foreach (Neighbour neighbour in location.neighbours)
        {
            GameObject go = Instantiate(arrowPrefab);
            go.name = "Arrow_" + neighbour.location.name;

            go.transform.parent = arrows;

            go.transform.transform.RotateAround(Vector3.zero, Vector3.up, neighbour.direction);
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));

            var button = go.GetComponent<Button>();

            Location temp = neighbour.location;
            button.onClick.AddListener(delegate () { this.GoTo(temp); });

        }
    }

    public void GoTo(Location location)
    {
       GetInstance().ChangeLocation(location);
    }

    public void MapJump(string name)
    {
        foreach (var location in locations)
        {
            if (location.name == name)
            {
                ChangeLocation(location);
                return;
            }
        }
   
    }

    public void ChangeView()
    {

        if (!mapOn)
        {
            arrows.gameObject.SetActive(false);
            map.gameObject.SetActive(true);
            mapOn = true;
        }
        else if (mapOn)
        {
            arrows.gameObject.SetActive(true);
            map.gameObject.SetActive(false);
            mapOn = false;
        }
    }



}

