using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    [Header("Elementos de UI")]
    public TextMeshProUGUI scoreText;
    public BoatController controller;



    void Start()
    {
        controller = GetComponent<BoatController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {controller.points}";
    }
}
