using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    private string play_Position;

    public void Update()
    {
        
       play_Position = Mathf.FloorToInt(player.position.z).ToString();
       

        scoreText.text =  $"{play_Position} / 745";
    }

}
