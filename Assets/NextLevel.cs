using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NextLevell();
            gameObject.SetActive(false);
        }
    }
    void NextLevell()
    {
        // Lấy cấp độ hiện tại
        int currentLevel = PlayerPrefs.GetInt("Level", 1);

        // Tăng cấp độ lên 1
        int nextLevel = ++currentLevel;

        // Lưu cấp độ mới
        PlayerPrefs.SetInt("Level", nextLevel);

        // Tạo tên cảnh tiếp theo
        string sceneName = "Level " + nextLevel.ToString();

        SceneManager.LoadScene(sceneName);
    }

}
