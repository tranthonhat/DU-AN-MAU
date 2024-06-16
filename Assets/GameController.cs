using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text txtLevel;

    private void Start()
    {
        // Kiểm tra và thiết lập cấp độ nếu chưa có
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        txtLevel.text = "Level " + PlayerPrefs.GetInt("Level");
    }

    // Hàm này sẽ được gọi khi nhấn vào button "Play"
    public void OnPlayButtonClicked()
    {


        // Lấy cấp độ hiện tại
        int currentLevel = PlayerPrefs.GetInt("Level");
        
        // Tải cảnh tương ứng với cấp độ hiện tại
        string sceneName = "Level " + currentLevel.ToString();
        SceneManager.LoadScene(sceneName);
    }

    // Hàm này sẽ được gọi khi nhấn vào button "Reset"
    public void OnResetButtonClicked()
    {
        // Đặt lại cấp độ về 1
        PlayerPrefs.SetInt("Level", 1);
        Debug.Log("Progress has been reset to Level 1.");
    }
}
