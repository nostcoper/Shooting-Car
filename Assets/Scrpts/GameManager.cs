using UnityEngine;
using System.Collections.Generic;
using CarControllerwithShooting;
using UnityEngine.InputSystem;
using UnityPlayerInput = UnityEngine.InputSystem.PlayerInput;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Configutation Game")]
    public int numberPlayer;
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    public int pointWin;

    [Header("Components")]
    public List<GameObject> playerList;
    public List<Camera> playerCameras = new List<Camera>();

    private bool gameEnded = false;
    void Start()
    {
        for (int i = 0; i < numberPlayer; i++)
        {
            addPlayer(i);
        }
        AdjustCameraView(playerList.Count);
    }

    void addPlayer(int id)
    {
        UnityPlayerInput currentPlayer;
        
        // Para los dos primeros jugadores, compartimos el teclado
        if (id < 2)
        {
            string controlScheme = id == 0 ? "WASD" : "Arrows";
            string actionMap = controlScheme;
            
            currentPlayer = UnityPlayerInput.Instantiate(
                playerPrefab,
                controlScheme: controlScheme,
                pairWithDevice: Keyboard.current
            );
            
            currentPlayer.SwitchCurrentControlScheme(controlScheme, Keyboard.current);
            currentPlayer.SwitchCurrentActionMap(actionMap);
        }
        // Para el resto de jugadores usamos gamepads disponibles
        else
        {
            // Verificamos si hay suficientes gamepads disponibles
            if (Gamepad.all.Count >= id - 1)
            {
                currentPlayer = UnityPlayerInput.Instantiate(
                    playerPrefab,
                    controlScheme: "Gamepad",
                    pairWithDevice: Gamepad.all[id - 2]  // Restamos 2 porque los dos primeros usan teclado
                );
                
                currentPlayer.SwitchCurrentControlScheme("Gamepad", Gamepad.all[id - 2]);
                currentPlayer.SwitchCurrentActionMap("Gamepad");
            }
            else
            {
                Debug.LogError($"No hay suficientes gamepads conectados para el jugador {id + 1}");
                return;
            }
        }
        
        // Configuración común para todos los jugadores
        currentPlayer.transform.position = spawnPoints[playerList.Count].position;
        currentPlayer.transform.rotation = spawnPoints[playerList.Count].rotation;
        playerCameras.Add(currentPlayer.transform.Find("Camera").GetComponent<Camera>());
        currentPlayer.name = $"Player {playerList.Count + 1}";
        playerList.Add(currentPlayer.gameObject);
    }
    

    private void AdjustCameraView(int playerCount)
    {
        switch (playerCount)
        {
            case 2:
                playerCameras[0].rect = new Rect(0f, 0f, 0.5f, 1);
                playerCameras[1].rect = new Rect(0.5f, 0, 0.5f, 1);
                break;
                
            case 3:
                playerCameras[0].rect = new Rect(0f, 0.5f, 0.5f, 0.5f); // Arriba izquierda
                playerCameras[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f); // Arriba derecha
                playerCameras[2].rect = new Rect(0f, 0f, 1f, 0.5f); // Abajo a lo largo
                break;
            case 4:
                playerCameras[0].rect = new Rect(0f, 0.5f, 0.5f, 0.5f); // Arriba izquierda
                playerCameras[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f); // Arriba derecha
                playerCameras[2].rect = new Rect(0f, 0f, 0.5f, 0.5f); // Abajo izquierda
                playerCameras[3].rect = new Rect(0.5f, 0f, 0.5f, 0.5f); // Abajo derecha
                break;
        }
    } 

 void Update()
    {
        if (gameEnded) return;

        foreach (GameObject player in playerList)
        {
            BoatController controller = player.GetComponent<BoatController>();
            if (controller != null && controller.points >= pointWin)
            {
                gameEnded = true;
                Debug.Log(player.name + " ha ganado con " + controller.points + " puntos.");
                // Aquí podrías llamar a un método para mostrar pantalla de victoria, detener el juego, etc.
                break;
            }
        }
    }
}
