using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Button[] backgroundMusicButtons;

    public AudioClip[] backgroundMusicList;
    public AudioClip playBGSound;
    public AudioClip restartSound;
    public AudioClip crackSound;
    public AudioClip winSound;

    private AudioSource musicSource;
    private AudioSource soundSource;

    private int currentBackgroundMusicIndex = 0;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        soundSource = gameObject.AddComponent<AudioSource>();

        for (int i = 0; i < backgroundMusicButtons.Length; i++)
        {
            int index = i;
            backgroundMusicButtons[i].onClick.AddListener(() => OnBackgroundMusicButtonClicked(index));
        }

        LoadSelectedBackgroundMusic();
        SetBackgroundMusicType(BackgroundMusicType.Menu);
    }

    private void OnBackgroundMusicButtonClicked(int buttonIndex)
    {
        currentBackgroundMusicIndex = buttonIndex;
        SetBackgroundMusicType(BackgroundMusicType.Menu);

        SaveSelectedBackgroundMusic();
    }

    private void SetBackgroundMusicType(BackgroundMusicType bgType)
    {
        currentBackgroundMusicType = bgType;

        if (currentBackgroundMusicType == BackgroundMusicType.Menu)
        {
            if (currentBackgroundMusicIndex < backgroundMusicList.Length)
            {
                musicSource.clip = backgroundMusicList[currentBackgroundMusicIndex];
            }
            else
            {
                Debug.LogError("Invalid background music index!");
            }
        }
        else if (currentBackgroundMusicType == BackgroundMusicType.Play)
        {
            musicSource.clip = playBGSound;
        }

        musicSource.Play();
        musicSource.loop = true;
    }

    private void LoadSelectedBackgroundMusic()
    {
        currentBackgroundMusicIndex = PlayerPrefs.GetInt("SelectedBackgroundMusicIndex", 0);
    }

    private void SaveSelectedBackgroundMusic()
    {
        PlayerPrefs.SetInt("SelectedBackgroundMusicIndex", currentBackgroundMusicIndex);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        UpdateAudioStates();
    }

    private void UpdateAudioStates()
    {
        bool isMusicOn = IsMusicOn();
        bool isSoundOn = IsSoundOn();

        if (isMusicOn)
        {
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.isPlaying)
            {
                musicSource.Pause();
            }
        }

        if (isSoundOn)
        {
            if (!soundSource.isPlaying)
            {
                soundSource.UnPause();
            }
        }
        else
        {
            if (soundSource.isPlaying)
            {
                soundSource.Pause();
            }
        }
    }

    public enum BackgroundMusicType
    {
        Menu,
        Play
    }

    private BackgroundMusicType currentBackgroundMusicType = BackgroundMusicType.Menu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusicList[currentBackgroundMusicIndex];
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayRestartSound()
    {
        soundSource.clip = restartSound;
        soundSource.Play();
    }

    public void PlayCrackSound()
    {
        soundSource.clip = crackSound;
        soundSource.Play();
    }

    public void PlayWinSound()
    {
        soundSource.clip = winSound;
        soundSource.Play();
    }

    public bool IsMusicOn()
    {
        return PlayerPrefs.GetInt("IsMusicOn", 1) == 1;
    }

    public bool IsSoundOn()
    {
        return PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
    }
}
