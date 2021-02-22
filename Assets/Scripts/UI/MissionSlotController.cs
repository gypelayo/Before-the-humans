using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionSlotController : MonoBehaviour
{
    public bool missionSlotOpen = false;
    [SerializeField]
    private GameObject slot;
    public TextMeshProUGUI maintitleTextField;
    public TextMeshProUGUI titleTextField;
    public TextMeshProUGUI descriptionTextField;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleMissionSlot);
    }

    /// <summary>
    /// Opens mission slot
    /// </summary>
    private void ToggleMissionSlot()
    {
        missionSlotOpen = !missionSlotOpen;
        slot.SetActive(missionSlotOpen);
    }

    public void OpenSlot()
    {
        slot.SetActive(true);
    }
    public void CloseSlot()
    {
        slot.SetActive(false);
    }
}
