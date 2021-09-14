using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    public string filename;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WriteCSV(string txt){
        StreamWriter streamwriter;
        FileInfo fileinfo;
        fileinfo = new FileInfo(Application.dataPath +"/"+ filename + ".csv");
        streamwriter = fileinfo.AppendText();
        streamwriter.WriteLine(txt);
        streamwriter.Flush();
        streamwriter.Close();
    }
}
