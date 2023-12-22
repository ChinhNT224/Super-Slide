using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public GameObject settingMusic;
    public GameObject selectMusicMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void PickLevel()
    {
        SceneManager.LoadScene("PickLevel");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingMusic()
    {
        if (settingMusic != null)
        {
            settingMusic.SetActive(!settingMusic.activeSelf);
        }
    }

    public void SelectMusicMenu()
    {
        if (selectMusicMenu != null)
        {
            selectMusicMenu.SetActive(!selectMusicMenu.activeSelf);
        }
    }

    public void CloseSettingMusic()
    {
        if (settingMusic != null)
        {
            settingMusic.SetActive(false);
        }
    }

    public void CloseSelectMusicMenu()
    {
        if (selectMusicMenu != null)
        {
            selectMusicMenu.SetActive(false);
        }
    }
}
