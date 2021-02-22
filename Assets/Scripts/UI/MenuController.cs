using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Button menuButton;
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private Sprite white;

    [SerializeField]
    private Sprite black;
    [SerializeField]
    private Sprite current;

    private bool isMenuOpen = false;

    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(ToggleMenu);
        current = transform.GetChild(0).GetComponent<Image>().sprite;
    }

    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menu.SetActive(isMenuOpen);

        if (current == black)
        {
            current = white;
        }
        else
        {
            current = black;
        }
        transform.GetChild(0).GetComponent<Image>().sprite = current;
    }
}
