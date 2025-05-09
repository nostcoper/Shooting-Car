using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SetupMenuManager : MonoBehaviour
{
    [Header("Players Selector")]
    public TMP_Text playersText;
    public Button playersLeftArrow;
    public Button playersRightArrow;

    public int minPlayers = 2;
    public int maxPlayers = 4;
    private int currentPlayers = 2;

    [Header("Points Selector")]
    public TMP_Text pointsText;
    public Button pointsLeftArrow;
    public Button pointsRightArrow;

    public int minPoints = 3;
    public int maxPoints = 15;
    private int currentPoints = 3;

    void Start()
    {
        // Asignación de listeners para cada grupo de flechas
        playersLeftArrow.onClick.AddListener(() => ChangePlayers(-1));
        playersRightArrow.onClick.AddListener(() => ChangePlayers(1));

        pointsLeftArrow.onClick.AddListener(() => ChangePoints(-1));
        pointsRightArrow.onClick.AddListener(() => ChangePoints(1));

        UpdatePlayersDisplay();
        UpdatePointsDisplay();
    }

    void Update()
    {
        maxPlayers = CountGamepadDevices();
        currentPlayers = Mathf.Clamp(currentPlayers, minPlayers, maxPlayers);
        UpdatePlayersDisplay();
    }

    void ChangePlayers(int delta)
    {
        currentPlayers = Mathf.Clamp(currentPlayers + delta, minPlayers, maxPlayers);
        UpdatePlayersDisplay();
    }

    void ChangePoints(int delta)
    {
        currentPoints = Mathf.Clamp(currentPoints + delta, minPoints, maxPoints);
        UpdatePointsDisplay();
    }

    void UpdatePlayersDisplay()
    {
        playersText.text = currentPlayers.ToString();
    }

    void UpdatePointsDisplay()
    {
        pointsText.text = currentPoints.ToString();
    }

    int CountGamepadDevices()
    {
        int count = 1;
        foreach (var device in InputSystem.devices)
        {
            if (device is not Mouse)
                count++;
        }
        return count;
    }
}
