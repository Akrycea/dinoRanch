using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialManager : MonoBehaviour, IDataManager
{
    public TimeManager timeManager;
    public ClickManager clickManager;
    public DialogueRunner dialogueRunner;
    public bool tutorialPlayed = false;
    private void Start()
    {
        
        StartCoroutine(waitASecond());
           
        
    }
    IEnumerator waitASecond()
    {
        yield return new WaitForSeconds(1);
        if (tutorialPlayed == false)
        {
            dialogueRunner.StartDialogue("NarratorTalk");
        }
        else if (tutorialPlayed == true) 
        {
            clickManager.canClickBG = true;
            timeManager.didGameStart = true;
        }
    }

    [YarnCommand("endTutorial")]
    public void endTutorial()
    {
        tutorialPlayed = true;
    }

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

    

    //DO £ADOWANIA I ZAPISYWANIA GRY
    public void LoadData(DinoData data)
    {
        this.tutorialPlayed = data.tutorialPlayed;
    }

    public void SaveData(ref DinoData data)
    {
        data.tutorialPlayed = this.tutorialPlayed;
    }

}
