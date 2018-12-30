using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;
using System.Linq;
using TMPro;

public class LocationSelector : MonoBehaviour
{
    public Transform locationHolder;

    public GameObject locationPrefab;

    public Scrollbar bar;

    public void LoadLocations(){
        string loc_data = Utilities.LoadFileToMemory(AppManager.Instance.LocationsPath + "locations.json");
        List<string> _data = JsonMapper.ToObject<string[]>(loc_data).ToList();
        List<Location> data = new List<Location>();
        foreach(string s in _data){
            data.Add(new Location(s));
        }

        foreach(Location l in data){
            var t = Instantiate(locationPrefab, locationHolder.position, Quaternion.identity);
            t.transform.SetParent(locationHolder);
            t.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = l.name.ToString();
        }
        bar.value = 1;
    }
}
