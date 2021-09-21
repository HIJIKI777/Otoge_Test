using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public int lineNum;
    private GameController _gameController;
    private bool isInLine = false;
    private KeyCode _lineKey;
    private int JudgeCount = 0;

    void Start () {
        _gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
        _lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
    }

    void Update () {
        this.transform.position += Vector3.down * 10 * Time.deltaTime;

        if (this.transform.position.y < -5.0f) {
            Debug.Log ("false");
            Destroy (this.gameObject);
        }

        
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Input.mousePosition;
            float XmousePosition = mousePosition.x;
            float YmousePosition = mousePosition.y;
            Debug.Log("LeftClick:"+mousePosition );
            if(300.0f <= XmousePosition && XmousePosition <= 1125.0f && 0f <= YmousePosition && YmousePosition <= 625.0f){
                Debug.Log("判定圏内");
                if(isInLine && JudgeCount == 0){
                    CheckInput();
                    JudgeCount = 1;
                }
            }
        }


    }

    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log ("hit");
        isInLine = true;
    }

    void OnTriggerExit2D (Collider2D other) {
        isInLine = false;
    }

    void CheckInput () {
        if (Input.GetMouseButton(0)) {
            Debug.Log("Nice");
            Destroy (this.gameObject);
        }
    }

    void CheckInput2 () {
        Debug.Log("NiceButton");
        Destroy (this.gameObject);
    }

}
