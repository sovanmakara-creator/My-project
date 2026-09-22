using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void GW1_level_1()
    {
        SceneManager.LoadScene("GW1_Level1");
    }

    public void GW1_level_2()
    {
        SceneManager.LoadScene("GW1_Level2");
    }
     public void GW1_level_3()
    {
        SceneManager.LoadScene("GW1_Level3");
    }

    public void GW2_level_1()
    {
        SceneManager.LoadScene("GW2_Level1");
    }

    public void GW2_level_2()
    {
        SceneManager.LoadScene("GW2_Level2");
    }
     public void GW2_level_3()
    {
        SceneManager.LoadScene("GW2_Level3");
    }

    public void GW3_level1()
    {
        SceneManager.LoadScene("GW3_Level1");
    }

    public void GW3_level2()
    {
        SceneManager.LoadScene("GW3_Level2");
    }

    public void GW3_level3()
    {
        SceneManager.LoadScene("GW3_Level3");
    }
    public void Main_menu(){

        SceneManager.LoadScene("Main_menu");
    }
}