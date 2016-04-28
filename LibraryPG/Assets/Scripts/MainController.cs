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
    public GameObject arrows;

    public void ChangeLocation(Location location)
    {
        currentLocation = location;
        RenderSettings.skybox = currentLocation.skybox;
    }

    void LoadNeighbours(Location location)
    {
        foreach (Transform arrow in arrows.transform)
        {
            Destroy(arrow);
        }
        foreach (Neighbour neighbour in location.neighbours)
        {
            GameObject go = Instantiate(arrowPrefab);

            go.transform.parent = arrows.transform;

            Neighbour goNeigbour = go.GetComponent<Neighbour>();

            goNeigbour.location = neighbour.location;
            goNeigbour.direction = neighbour.direction;

            go.transform.position = Vector3.Normalize(goNeigbour.direction);
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));

        }
    }


}

