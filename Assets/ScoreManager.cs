using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    public void Update()
    {
        scoreText.text = Mathf.FloorToInt(player.position.z).ToString();
    }

}
