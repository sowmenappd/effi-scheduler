using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CourseSelector : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform courseHolder;
    public Scrollbar bar;

    public Course highlightedCourse = null;

    public void LoadCourses(){
        AppManager.Instance.selectedCourses = new List<Course>();
        string data = Utilities.LoadFileToMemory(AppManager.Instance.SubjectListsPath + "courses.json");
        Course[] courses = JsonMapper.ToObject<Course[]>(data);

        foreach(Course c in courses){
            GameObject g = Instantiate(textPrefab, courseHolder.position, Quaternion.identity);
            g.transform.GetChild(1).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = c.code + " : " + c.credit + " credits";
            g.transform.SetParent(courseHolder);
        }
        bar.value = 1;
    }
}
