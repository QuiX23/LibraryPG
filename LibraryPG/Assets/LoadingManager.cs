using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour
{

    public GameObject loadingSplash;
    // Use this for initialization
    IEnumerator Start () {
        AsyncOperation async = Application.LoadLevelAsync("main");
        yield return async;
        loadingSplash.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
