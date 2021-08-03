using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [Header("Player game object")]
    public PlayerManager player;

    [Header("Player stats")]
    public GameObject statsArea;
    public Slider healthBar;
    public Slider staminaBar;
    public Text scoreCount;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        scoreCount.text = "Score: 0";
    }

    private void Update()
    {
        // if the player presses ESC...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorMode();
        }
    }

    private void FixedUpdate()
    {
        staminaBar.value = player.stamina;
        healthBar.value = player.health;
        scoreCount.text = "Score: " + player.score;
    }

    /// <summary>
    /// Toggles the Cursor's lock state.
    /// </summary>
    public void ToggleCursorMode()
    {
        Cursor.visible = !Cursor.visible;

        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            statsArea.SetActive(true);
            pauseMenu.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            statsArea.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }

    /// <summary>
    /// Disconnect player and reenable pause menu. 
    /// </summary>
    public void Disconnect()
    {
        pauseMenu.SetActive(false);
        Client.instance.Disconnect();
        UIManager.instance.EnableMenu();

        Destroy(GameManager.players[player.id].gameObject);
        GameManager.players.Remove(player.id);

        Cursor.lockState = CursorLockMode.None;
    }
}
