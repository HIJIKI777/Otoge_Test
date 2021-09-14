using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float count = 3;
    public AudioClip bgm;			//音源の指定
    private AudioSource audiosource;    //AudioSourceの宣言

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();  //AudioSourceの取得         
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 0){
            audiosource.PlayOneShot(bgm);             //曲を鳴らす
            count = 0;                             //countの値を0秒にしてゲーム修了時まで流さなくする
        }else if(count == 0){}
        else{
            count = count - Time.deltaTime;         //4秒の前置きを設定する
        }
    }
}
