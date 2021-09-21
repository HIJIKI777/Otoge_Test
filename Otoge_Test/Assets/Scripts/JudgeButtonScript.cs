using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeButtonScript : MonoBehaviour
{
    public bool push = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInput2 () {
        Debug.Log("button hit");            
    }

    public void PushCheck(){
        Debug.Log("押したよ");
        push = true;
    }

    public void Removecheck(){
        Debug.Log("離したよ");
        push = false;        
    }
}
