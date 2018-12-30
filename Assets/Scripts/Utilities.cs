using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static string LoadFileToMemory(string filePath){
        StreamReader sr = new StreamReader(filePath);

        string line, data = "";

        while((line = sr.ReadLine()) != null){
            data += (line + "\n");
        }

        sr.Close();
        return data;
    }

    public static void CopyToFile(string fileToReadPath, string path){

        StreamReader sr = new StreamReader(fileToReadPath);
        string line;
        string[] data = new string[100000];
        int i = 0;
        while((line = sr.ReadLine()) != null){
            data[i++] = line;
        }
        sr.Close();

        int j = 0;
        StreamWriter sw = new StreamWriter(System.IO.File.Create(path));
        
        try{
            while(j != i){
                sw.Write(data[j++] + "\n");
            }
        } catch(Exception e){
            MonoBehaviour.print(e.Message.ToString());
        }
        sw.Close();
    }

    
}
