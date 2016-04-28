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

    public RectTransform arrows;
    public RectTransform map;

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
    }

    void SetNeighbours(Location location)
    {
        DestroyNeighbours(location);
        LoadNeighbours(location);
    }

    void DestroyNeighbours(Location location)
    {
        if (arrows == null) return;

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

            go.transform.parent = arrows;

            go.transform.position = Vector3.Normalize(neighbour.direction)* arrowDistance;
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));

            var button = go.GetComponent<Button>();
            button.onClick.AddListener(delegate () { neighbour.GoTo(); });

        }
    }



}

