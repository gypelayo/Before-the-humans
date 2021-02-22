using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionMenuController : MonoBehaviour
{
    private List<Button> missionButtons;

    private void CloseAllMissionSlots()
    {
        foreach (Button button in missionButtons)
        {
            if (button.GetComponent<MissionSlotController>().missionSlotOpen)
            {
                button.GetComponent<MissionSlotController>().missionSlotOpen = false;
            }
        }
    }
}
