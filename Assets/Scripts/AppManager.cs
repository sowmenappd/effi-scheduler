using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    #region Data

    public List<Course> selectedCourses = new List<Course>();
    public List<Location> selectedLocations = new List<Location>();

    #endregion


    public string SubjectListsPath { get{ return Application.dataPath + "/Resources/SubjectLists/"; } }
    public string LocationsPath { get{ return Application.dataPath + "/Resources/Locations/"; } }
    public string GeneratedSchedulePath { get{ return Application.dataPath + "/Resources/GeneratedSchedules/"; } }
    //public string SubjectListsPath{ get{ return Application.dataPath + "Resources/SubjectLists/"; } }

    #region Singleton

    private static GameObject _gameObject;
    private static AppManager instance;

    public List<Transform> panels;

    public static AppManager Instance {
        get {
            if(instance == null){
                _gameObject = GameObject.Find("_AppManager");
                instance = _gameObject.GetComponent<AppManager>();
                _gameObject.transform.SetAsFirstSibling();
            }
            return instance;
        }
    }
    #endregion

    void Start(){
        AppManager.Instance.Initialize();
    }

    public void Initialize(){ 
        print("app init");
        AttachButtons();
        SetPanelActive("panel5");
    }

    void AttachButtons(){
        if(GameObject.Find("Make rtn button"))
            GameObject.Find("Make rtn button").GetComponent<Button>().onClick.AddListener(AppManager.Instance.MakeRoutine);

        if(GameObject.Find("View rtn button"))
            GameObject.Find("View rtn button").GetComponent<Button>().onClick.AddListener(AppManager.Instance.ViewRoutine);

        if(GameObject.Find("select subjects button"))
             GameObject.Find("select subjects button").GetComponent<Button>().onClick.AddListener(AppManager.Instance.SelectCourses);

        if(GameObject.Find("add subjects to list button"))
            GameObject.Find("add subjects to list button").GetComponent<Button>().onClick.AddListener(AppManager.Instance.AddCourse);
    }

    void MakeRoutine(){

    }

    void ViewRoutine(){
        
    }

    void AddCourse(){
        SetPanelActive(panels[2]);
    }

    // void ViewCourses(){
    //     SetPanelActive(panels[3]);
    //     panels[3].GetComponentInChildren<RoutineLoader>().LoadCourses();
    // }

    void SelectCourses(){
        SetPanelActive(panels[4]);
        panels[4].GetComponent<CourseSelector>().LoadCourses();
    }

    public void SetPanelActive(Transform p){
        for(int i=0; i<panels.Count; i++){
            if(panels[i] == p)
                panels[i].gameObject.SetActive(true);
            else
                panels[i].gameObject.SetActive(false);
        }
    }

    public void SetPanelActive(string panelName){
        for(int i=0; i<panels.Count; i++){
            if(panels[i].name == panelName)
                panels[i].gameObject.SetActive(true);
            else
                panels[i].gameObject.SetActive(false);
        }
    }


}
