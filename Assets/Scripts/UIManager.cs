using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    [Header("Interactables")]
    public InputField serverIpField;
    public InputField usernameField;
    public Button[] teamButtons = new Button[2];
    private Button connectButton;

    [Header("Player values")]
    public string playerTeam;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            connectButton = GameObject.Find("Menu/Start/Panel/ConnectButton").GetComponent<Button>();
            //teamButtons[0] = GameObject.Find("TeamSelect/Buttons/CopsTeam").GetComponent<Button>();
            //teamButtons[1] = GameObject.Find("TeamSelect/Buttons/RobbersTeam").GetComponent<Button>();
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        DisableMenu();
        Client.instance.ConnectToServer();
    }

    public void SetTeam(string _team)
    {
        playerTeam = _team;
    }

    /// <summary>
    /// Function called when a player presses "Disconnect" button from pause menu.
    /// </summary>
    public void EnableMenu()
    {
        // delete previous values
        serverIpField.text = "";
        usernameField.text = "";
        playerTeam = null;

        startMenu.SetActive(true);
        serverIpField.interactable = true;
        usernameField.interactable = true;
        //foreach (Button button in teamButtons)
        //{
        //    button.interactable = true;
        //}
        connectButton.interactable = true;
    }

    /// <summary>
    /// Function called before connecting to server. Disables all elements.
    /// </summary>
    public void DisableMenu()
    {
        startMenu.SetActive(false);
        serverIpField.interactable = false;
        usernameField.interactable = false;
        //foreach (Button button in teamButtons)
        //{
        //    button.interactable = false;
        //}
        connectButton.interactable = false;
    }
}
