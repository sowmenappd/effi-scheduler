using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CourseAdder : MonoBehaviour
{   
    public InputField courseCode, creditHours, courseTitle;

    public void OnAddCourse(){
        //validate the course
        //throw error if duplicate or in bad format
        if(courseCode.text == "" || creditHours.text == "" || courseTitle.text == ""){
            throw new System.Exception("Course information is not valid/complete.");
            //TODO: throw visual warning
        }

        Course c = new Course(courseCode.text, Double.Parse(creditHours.text), courseTitle.text); 
        //AppManager.Instance.selectedCourses.Add(c);

        courseCode.text = "";
        creditHours.text = "";
        courseTitle.text = "";

        //modify the courses JSON file
        string data = Utilities.LoadFileToMemory(AppManager.Instance.SubjectListsPath + "courses.json");
        List<Course> courses = JsonMapper.ToObject<Course[]>(data).ToList();
        courses.Add(c);
        data = JsonHelper.FormatJson(JsonMapper.ToJson(courses));

        StreamWriter s = new StreamWriter(AppManager.Instance.SubjectListsPath + "courses.json", false);
        s.Write(data);
        s.Close();
    }
}
