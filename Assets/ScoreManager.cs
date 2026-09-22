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
    // public GameObject Pausebtn;

    public float totalscore_board;

    public void Update()
    {
        
       play_Position = Mathf.FloorToInt(player.position.z).ToString();
       

        scoreText.text =  $"{play_Position} / {totalscore_board}";
    }
    public void Pausebtn(){
        Time.timeScale = 0f;
    }
    public void Replay(){
        Time.timeScale = 1f;
    }
}
