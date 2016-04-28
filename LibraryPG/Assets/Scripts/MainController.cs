using UnityEngine;

using System.Collections.Generic;

public class MainController : MonoBehaviour
{

    #region Singleton patter
    private static MainController instance = null;

    private MainController() { }

    public static MainController GetInstance()
    {
        if (instance == null)
        {
            instance = new MainController();
        }

        return instance;
    }
    #endregion

    private List<Location> locations;
    private Location currentLocation;

    public GameObject arrowPrefab;

    void ChangeLocation(Location location)
    {
        currentLocation = location;
        RenderSettings.skybox = currentLocation.skybox;
    }

    void LoadNeighbours(Location location)
    {
        foreach (Neighbour neighbour in location.neighbours)
        {

        }
    }


}

