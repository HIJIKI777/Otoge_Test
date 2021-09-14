using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtil
{

    public static KeyCode GetKeyCodeByLineNum(int linenum){
        switch(linenum){
            case 0:
            return KeyCode.D;
            case 1:
            return KeyCode.K;
            default:
            return KeyCode.None;
        }
    }
}
