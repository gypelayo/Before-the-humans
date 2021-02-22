using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    [SerializeField]
    private Transform missionPanel;
    [SerializeField]
    private GameObject missionPrefab;
    private int totalMissions = 0;
    [SerializeField]
    private int maxNumberOfMissions = 13;
    private Mission noMissionAvailable;
    [SerializeField]
    private List<Mission> plannedMissions;

    private void Start()
    {
        noMissionAvailable = new Mission("Sem missões", "Something", 0, 0, 0.1f);
        plannedMissions = new List<Mission>();

        AddMission(noMissionAvailable);
        for (int i = 0; i < maxNumberOfMissions; i++)
        {
            Mission mission1 = new Mission("Mission", "Something");
            AddMission(mission1);
        }
    }

    private void UpdateMissionList()//TODO: Create method to update mission list form variable
    {

    }

    /// <summary>
    /// Adds new mission to mission scroll pane
    /// </summary>
    public void AddMission(Mission mission)
    {
        if (mission.getMissionTitle() == "Sem missões")
        {
            GameObject newMission = Instantiate(missionPrefab, missionPanel);
            newMission.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -37.5f - totalMissions * 70);
            newMission.GetComponent<MissionSlotController>().maintitleTextField.text = mission.getMissionTitle();
            newMission.GetComponent<Button>().interactable = false;
        }
        else
        {
            if (totalMissions == 0)
            {
                Destroy(missionPanel.GetChild(0).gameObject);
            }
            GameObject newMission = Instantiate(missionPrefab, missionPanel);
            newMission.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -37.5f - totalMissions * 70);
            newMission.GetComponent<MissionSlotController>().maintitleTextField.text = mission.getMissionTitle();
            newMission.GetComponent<MissionSlotController>().titleTextField.text = "Inv: " + mission.getResearchInterest().ToString() + " $ " + mission.getFunds().ToString();
            newMission.GetComponent<MissionSlotController>().descriptionTextField.text = mission.getMissionDescription();
            totalMissions++;
        }
    }
}
