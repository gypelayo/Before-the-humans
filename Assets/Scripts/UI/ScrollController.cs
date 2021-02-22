using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    private RectTransform myRectTransform;
    [SerializeField]
    private int scrollRate = 1;
    [SerializeField]
    private RTSCameraController cameraController;
   /* [SerializeField]
    private Scrollbar scrollBar;
*/
    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        cameraController.canControl = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        cameraController.canControl = true;
    }
}

