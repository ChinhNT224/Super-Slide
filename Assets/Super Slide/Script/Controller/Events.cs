using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public GameObject setting;
    public GameObject settingMusic;
    public GameObject selectMusicMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void Pick()
    {
        SceneManager.LoadScene("Pick");
    }
    public void PickLevel()
    {
        SceneManager.LoadScene("PickLevel");
    }
    public void PickLevel1()
    {
        SceneManager.LoadScene("PickLevel Square");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        if (setting != null)
        {
            setting.SetActive(!setting.activeSelf);
        }
    }
    public void SettingMusic()
    {
        if (setting != null)
        {
            setting.SetActive(!setting.activeSelf);
        }

        if (settingMusic != null)
        {
            settingMusic.SetActive(!settingMusic.activeSelf);
        }
    }

    public void SelectMusicMenu()
    {
        if (settingMusic != null)
        {
            settingMusic.SetActive(!settingMusic.activeSelf);
        }

        if (selectMusicMenu != null)
        {
            selectMusicMenu.SetActive(!selectMusicMenu.activeSelf);
        }
    }

    public void CloseSetting()
    {
        if (setting != null)
        {
            setting.SetActive(false);
        }
    }

    public void CloseSettingMusic()
    {
        if (settingMusic != null)
        {
            settingMusic.SetActive(false);
        }

        if (setting != null)
        {
            setting.SetActive(true);
        }
    }

    public void CloseSelectMusicMenu()
    {
        if (selectMusicMenu != null)
        {
            selectMusicMenu.SetActive(false);
        }

        if (settingMusic != null)
        {
            settingMusic.SetActive(true);
        }
    }
}
