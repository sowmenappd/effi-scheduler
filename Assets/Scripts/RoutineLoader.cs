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
        
    }

    public void LoadCourses(){
        // if(courseHolder.childCount != 0){
        //     foreach(Transform t in courseHolder.GetComponentsInChildren<Transform>())
        //         Destroy(t.gameObject);
        // }

        jsonData = Utilities.LoadFileToMemory(AppManager.Instance.SubjectListsPath + "courses.json");
        courses = JsonMapper.ToObject<Course[]>(jsonData);

        AppManager.Instance.selectedCourses = new List<Course>(courses);

        foreach(Course c in courses){
            GameObject g = Instantiate(textPrefab, courseHolder.position, Quaternion.identity);
            g.transform.GetChild(1).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.SetParent(courseHolder);
            //g.transform.SetAsLastSibling();
        }
        courseHolder.parent.parent.GetChild(1).GetComponent<Scrollbar>().value = 1;
    }

    

}
