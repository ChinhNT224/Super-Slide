using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public Button[] levelButtons;

    private void Start()
    {
        UnlockLevel(0);

        for (int i = 0; i < levelPrefabs.Length; i++)
        {
            bool isUnlocked = CheckIfLevelIsUnlocked(i);
            levelButtons[i].interactable = isUnlocked;

            int levelIndex = i;
            levelButtons[i].onClick.AddListener(() => StartSelectedLevel(levelIndex));
        }
    }

    public void StartSelectedLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("SelectedLevel", levelIndex);
        SceneManager.LoadScene("Play");
    }

    private bool CheckIfLevelIsUnlocked(int levelIndex)
    {
        if (levelIndex == 0)
        {
            return true;
        }

        return PlayerPrefs.GetInt("Level" + levelIndex + "_Unlocked", 0) == 1;
    }

    private void UnlockLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("Level" + levelIndex + "_Unlocked", 1);
    }
}
