using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTimingMaker : MonoBehaviour
{

    private AudioSource audiosource;
    private float starttime = 0;
    private CSVWriter csvwriter;

    private bool isPlaying = false;
    public GameObject startbutton;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GameObject.Find("BGM").GetComponent<AudioSource> ();
        csvwriter = GameObject.Find ("CSVWriter").GetComponent<CSVWriter> ();        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying){
            DetectPush();
        }
    }

    public void StartMusic(){
        startbutton.SetActive (false);
        audiosource.Play();
        starttime = Time.time;
        isPlaying = true;
    }

    void DetectPush(){
        if(Input.GetKeyDown (KeyCode.D)){
            WriteNotesTiming (0);
        }
        if(Input.GetKeyDown (KeyCode.K)){
            WriteNotesTiming (1);
        }
    }

    void WriteNotesTiming(int num){
        Debug.Log(GetTiming());
        csvwriter.WriteCSV(GetTiming ().ToString () + "," + num.ToString());
    }

    float GetTiming(){
        return Time.time - starttime;
    }
}
