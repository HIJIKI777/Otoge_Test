using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;

    public string filePass;
    private int _notesCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;

    public float count = 3;

    void Start(){
        _audioSource = GameObject.Find ("BGM").GetComponent<AudioSource> ();
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV ();
    }

    void Update () {
        if (_isPlaying) {
            CheckNextNotes ();
            if(count < 0){
                _audioSource.Play ();
                count = 0;                             //countの値を0秒にしてゲーム修了時まで流さなくする
            }else if(count == 0){}
            else{
                count = count - Time.deltaTime;         //4秒の前置きを設定する
        }
        }   //OK

    }

    public void StartGame(){
        startButton.SetActive (false);
        _startTime = Time.time;
        _isPlaying = true;
    }

    void CheckNextNotes(){
        while (_timing [_notesCount] + timeOffset < GetMusicTime ()&& _timing [_notesCount] != 0) {
            SpawnNotes (_lineNum[_notesCount]);
            _notesCount++;
        }
    }

    void SpawnNotes(int num){
        Instantiate (notes[num], 
            new Vector3 (-4.0f + (2.0f * num), 15.0f, 0),
            Quaternion.identity);
    }

    void LoadCSV(){

        TextAsset csv = Resources.Load (filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader (csv.text);

        int i = 0;
        while (reader.Peek () > -1) {

            string line = reader.ReadLine ();
            string[] values = line.Split (',');
            for (int j = 0; j < values.Length; j++) {
                _timing [i] = float.Parse( values [0] );
                _lineNum [i] = int.Parse( values [1] );
            }
            i++;
        }
    }

    float GetMusicTime(){
        return Time.time - _startTime;
    }
}
