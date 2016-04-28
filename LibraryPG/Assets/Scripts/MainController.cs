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

    public float arrowDistance = 100;

    public void ChangeLocation(Location location)
    {
        currentLocation = location;
        RenderSettings.skybox = currentLocation.skybox;
        SetNeighbours(location);
    }

    public void Start()
    {
        instance = this;
        ChangeLocation(currentLocation);
        SetupMap();
    }

    void SetupMap()
    {
        if (map == null) return;

        foreach (Location location in locations)
        {
            GameObject go = Instantiate(placemarkPrefab);
            go.name = "Placmark_" + location.name;
            go.transform.parent = map;
            go.transform.localPosition = new Vector3((location.positionOnMap.x - 0.5f )*map.rect.width,
                                                    (location.positionOnMap.y - 0.5f) *map.rect.height,
                                                    0);
            placemarks.Add(location.name, go.GetComponent<Button>());
            //Debug.Log("Placmark_" + location.name+" "+ map.rect.width+" "+ map.rect.height);

        }
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

            go.transform.position = Vector3.Normalize(neighbour.direction)* arrowDistance;
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));

            var button = go.GetComponent<Button>();
            button.onClick.AddListener(delegate () { neighbour.GoTo(); });

        }
    }



}

