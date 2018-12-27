using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using TMPro;

public class RoutineLoader : MonoBehaviour
{   
    public Course[] courses;
    public GameObject textPrefab;

    public Transform courseHolder;

    private string jsonData = "";

    public void Start(){
        jsonData = Utilities.LoadJsonToMemory("courses.json");
        courses = JsonMapper.ToObject<Course[]>(jsonData);
        
        foreach(Course c in courses){
            GameObject g = Instantiate(textPrefab, courseHolder.position, Quaternion.identity);
            g.transform.GetChild(1).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.parent = courseHolder;
        }

        //Utilities.CopyToFile(Application.dataPath + "/Resources/courses.json", Application.dataPath + "/Resources/" +"courses_new.json");
    }

    

}
