using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameWin;
    public GameObject setting;
    public GameObject GameWin;
    public GameObject pauseSetting;
    public GameObject[] levelPrefabs;
    private GameObject currentLevelPrefab;  
    private const string menuScene = "Menu";
    private const string pickLevelScene = "PickLevel";  

    private void Start()
    {
        gameWin = false;
        Time.timeScale = 1;
        int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        currentLevelPrefab = Instantiate(levelPrefabs[selectedLevel], new Vector2(0f, 0f), Quaternion.identity);
    }

    private void UnlockNextLevel(int levelIndex)
    {
        int nextLevel = levelIndex + 1;
        PlayerPrefs.SetInt("Level" + nextLevel + "_Unlocked", 1);
    }

    private void LoadNextLevel(int currentLevel)
    {
        int nextLevel = currentLevel + 1;

        if (nextLevel < levelPrefabs.Length && PlayerPrefs.GetInt("Level" + nextLevel + "_Unlocked", 0) == 1)
        {
            currentLevelPrefab = Instantiate(levelPrefabs[nextLevel], new Vector2(0f, 0f), Quaternion.identity);
        }
        else
        {
            SceneManager.LoadScene(pickLevelScene);
        }
    }

    void Update()
    {
        if (gameWin)
        {
            Time.timeScale = 0;
            GameWin.SetActive(true);
            int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
            UnlockNextLevel(selectedLevel);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void PauseGame()
    {
        if (pauseSetting != null)
        {
            pauseSetting.SetActive(!pauseSetting.activeSelf);
        }
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (pauseSetting != null)
        {
            pauseSetting.SetActive(false);
        }
    }

    public void NextLevelButton()
    {
        GameWin.SetActive(false);
        gameWin = false;
        Time.timeScale = 1;
        int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        Debug.Log(selectedLevel);
        PlayerPrefs.SetInt("SelectedLevel", selectedLevel + 1);
        PlayerPrefs.Save();
        Destroy(currentLevelPrefab);
        LoadNextLevel(selectedLevel);
    }

    public void RestartGame()
    {
        if (setting != null)
        {
            setting.SetActive(false);
        }
        AudioManager.instance.PlayRestartSound();
        GameWin.SetActive(false);
        gameWin = false;
        Time.timeScale = 1;
        Destroy(currentLevelPrefab);
        int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        currentLevelPrefab = Instantiate(levelPrefabs[selectedLevel], new Vector2(0f, 0f), Quaternion.identity);
    }
}
