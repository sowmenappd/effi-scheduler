using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CourseHighlight : MonoBehaviour
{
    string courseCode;
    bool _checked = false;
    public Transform checkButton; //#2ecc71

    string GetCourseCode(){
        string[] str = transform.GetChild(1).GetComponent<Text>().text.Split(' ');
        courseCode = str[0];
        return courseCode;
    }

    public void OnHighlighted(){
        GetCourseCode();
        print(courseCode);


        _checked = !_checked;
        checkButton.gameObject.SetActive(_checked);

        if(_checked){
            GetComponent<Image>().color = new Color(46, 204, 113, 255);
            OnAdded();
        }
        else{
            GetComponent<Image>().color = Color.white;
            OnRemoved();
        }
    }

    public void OnRemoved(){
        string _courseCode = GetCourseCode();

        string data = Utilities.LoadFileToMemory(AppManager.Instance.SubjectListsPath + "courses.json");
        List<Course> courses = JsonMapper.ToObject<Course[]>(data).ToList();

        Course c = courses.Find(course => course.code == _courseCode);
        Course temp = AppManager.Instance.selectedCourses.Find(x => x.code == c.code);
        if(temp != null){
            AppManager.Instance.selectedCourses.Remove(temp);
        }

        //TODO: this needs a rework for permanent course removal option

        // if(idx >= 0 && idx < courses.Count)
        //     courses.RemoveAt(idx);

        // data = JsonMapper.ToJson(courses);
        // data = JsonHelper.FormatJson(data);
        // StreamWriter sw = new StreamWriter(AppManager.Instance.SubjectListsPath + "courses.json");
        // sw.Write(data);
        // sw.Close();
        //Destroy(gameObject);
    }

    public void OnAdded(){
        string _courseCode = courseCode;

        string data = Utilities.LoadFileToMemory(AppManager.Instance.SubjectListsPath + "courses.json");
        List<Course> courses = JsonMapper.ToObject<Course[]>(data).ToList();

        Course temp = courses.Find(x => x.code == _courseCode);

        AppManager.Instance.selectedCourses.Add(temp);
    }
}
