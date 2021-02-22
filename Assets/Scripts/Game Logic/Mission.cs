using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    private string missionTitle = "";
    private string missionDescription = "";
    private bool completed;
    private int researchInterest;
    private int funds;
    private float publicInterest;
    private bool success;
    //TODO: add expiration date

    public Mission(string title, string description, int researchInterest, int funds, float publicInterest)
    {
        missionTitle = title;
        missionDescription = description;
        completed = false;
        this.researchInterest = researchInterest;
        this.publicInterest = publicInterest;
        this.funds = funds;
    }

    /// <summary>
    /// Random reward generation mission
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public Mission(string title, string description) //Era fxe criar um sistema de criar textos procedurally generated para as missoes
    {
        missionTitle = title;
        missionDescription = description;
        completed = false;
        this.researchInterest = Mathf.RoundToInt(Random.Range(0, 100000));
        this.publicInterest = Random.Range(0, 1);
        this.funds = Mathf.RoundToInt(Random.Range(0, 1000000));
    }

    /// <summary>
    /// Ends the mission
    /// </summary>
    /// <param name="success"></param>
    public void EndMission(bool success)
    {
        completed = true;
        this.success = success;

        if (!success)
        {
            publicInterest = 0;
            researchInterest = 0;
            funds = 0;
        }
    }

    public string getMissionTitle()
    {
        return this.missionTitle;
    }

    public void setMissionTitle(string missionTitle)
    {
        this.missionTitle = missionTitle;
    }

    public string getMissionDescription()
    {
        return this.missionDescription;
    }

    public void setMissionDescription(string missionDescription)
    {
        this.missionDescription = missionDescription;
    }

    public bool isCompleted()
    {
        return this.completed;
    }

    public void setCompleted(bool completed)
    {
        this.completed = completed;
    }

    public int getResearchInterest()
    {
        return this.researchInterest;
    }

    public void setResearchInterest(int researchInterest)
    {
        this.researchInterest = researchInterest;
    }

    public int getFunds()
    {
        return this.funds;
    }

    public void setFunds(int funds)
    {
        this.funds = funds;
    }

    public float getPublicInterest()
    {
        return this.publicInterest;
    }

    public void setPublicInterest(float publicInterest)
    {
        this.publicInterest = publicInterest;
    }

    public bool isSuccess()
    {
        return this.success;
    }

    public void setSuccess(bool success)
    {
        this.success = success;
    }

}
