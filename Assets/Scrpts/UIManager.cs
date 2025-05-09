using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    [Header("Elementos de UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goalScoreText;
    public Image crow;
    public BoatController controller;



    void Start()
    {
        controller = GetComponent<BoatController>();
        goalScoreText.text = ConfigManager.Instance.WinPoint.ToString();
    }

    void Update()
    {
        scoreText.text = " " + controller.points;
        crow.enabled =  controller.winner;
    }

}
