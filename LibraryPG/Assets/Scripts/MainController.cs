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
        if (instance == null)
        {
            instance = new MainController();
        }

        return instance;
    }
    #endregion

    public Location currentLocation;

    public List<Location> locations;
    public GameObject arrowPrefab;
    public GameObject arrows;

    public float arrowDistance = 100;

    public void ChangeLocation(Location location)
    {
        currentLocation = location;
        RenderSettings.skybox = currentLocation.skybox;
        LoadNeighbours(location);
    }

    public void Start()
    {
        ChangeLocation(currentLocation);
    }

    void LoadNeighbours(Location location)
    {
        if (arrows == null) return;
        foreach (Transform arrow in arrows.transform)
        {
            Destroy(arrow.gameObject);
        }
        foreach (Neighbour neighbour in location.neighbours)
        {
            GameObject go = Instantiate(arrowPrefab);

            go.transform.parent = arrows.transform;

            go.transform.position = Vector3.Normalize(neighbour.direction)* arrowDistance;
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));

            var button = go.GetComponent<Button>();
            button.onClick.AddListener(delegate () { neighbour.GoTo(); });

        }
    }



}

