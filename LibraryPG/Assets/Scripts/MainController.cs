﻿using System;
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

    public GameObject infoGO;

    public RectTransform arrows;
    public RectTransform map;
    public RectTransform info;

    private bool mapOn=false;
    private bool infoOn = false;

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

        if (mapOn)ChangeView();
        ChangeInfo();
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
            map.gameObject.SetActive(true);
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

            Text text = go.GetComponentInChildren<Text>();
            if (text!=null)
            text.text = location.name;

            //Debug.Log("Placmark_" + location.name+" "+ map.rect.width+" "+ map.rect.height);
            string tmp = location.name;
            button.onClick.AddListener(delegate () { this.MapJump(tmp); });

        }

        ColorBlock cb2 = placemarks[currentLocation.name].colors;
        cb2.normalColor = Color.green;
        placemarks[currentLocation.name].colors = cb2;
        placemarks[currentLocation.name].Select();
        map.gameObject.SetActive(false);
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
            var go = Instantiate(arrowPrefab);
            go.name = "Arrow_" + neighbour.location.name;

            go.transform.parent = arrows;

            go.transform.transform.RotateAround(Vector3.zero, Vector3.up, neighbour.direction);
            go.transform.LookAt(new Vector3(0, transform.position.y, 0));
            go.transform.transform.RotateAround(go.transform.position, Vector3.up, 180);

            bool temp2 = false;
            if (!arrows.gameObject.activeSelf)
            {
                temp2 = true;
                arrows.gameObject.SetActive(true);
            }

            var button = go.GetComponentInChildren<Button>();

            Location temp = neighbour.location;

            arrows.gameObject.SetActive(true);
            var text = go.GetComponentInChildren<Text>();
            if (text != null)
                text.text = neighbour.location.name;


            if (temp2)
            {
                arrows.gameObject.SetActive(false);
            }


            button.onClick.AddListener(delegate () { GoTo(temp); });
         
        }
    }

    public void GoTo(Location location)
    {
      ChangeLocation(location);
    }

    public void ShowText(Text text)
    {
        text.gameObject.SetActive(true);
    }

    public void HideText(Text text)
    {
        text.gameObject.SetActive(false);
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


    public void ChangeInfo()
    {

        if (!infoOn&& currentLocation.InfoSprite!=null)
        {
            arrows.gameObject.SetActive(false);
            infoGO.SetActive(true);
            infoOn = true;

           var image= info.GetComponent<Image>();
           image.sprite = currentLocation.InfoSprite;
        }
        else if (infoOn)
        {
            arrows.gameObject.SetActive(true);
            infoGO.SetActive(false);
            infoOn = false;
        }
    }



}

