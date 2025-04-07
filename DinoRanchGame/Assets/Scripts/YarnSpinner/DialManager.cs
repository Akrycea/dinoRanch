using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialManager : MonoBehaviour
{
    public TimeManager timeManager;
    public ClickManager clickManager;


    [YarnCommand("startTime")]
     public void startTime()
    {
        timeManager.didGameStart = true;
    }

    [YarnCommand("blockClicking")]
    public void blockClicking()
    {
        clickManager.canClickBG = false;
    }

    [YarnCommand("unblockClicking")]
    public void unblockClicking()
    {
        clickManager.canClickBG = true;
    }

}
