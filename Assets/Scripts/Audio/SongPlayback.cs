using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPlayback : MonoBehaviour
{
    public Transform fullWindow;

    public float songProgress;
    public Slider progressBar;
    public AudioClip[] audioClipArray;
    // 0 = Track0
    // 1 = Track1
    // 2 = Track2

    public int currentSong;

    public GameObject playpauseButton;
    public Image buttonImage;
    public Sprite playImage;
    public Sprite pauseImage;

    private AudioSource audioSource;
    private bool isPlaying;

    public GameObject albumArt;

    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipArray[0];
        currentSong = 0;

        buttonImage = playpauseButton.GetComponent<Image>();
        isPlaying = false;
    }

    void Update()
    {
        songProgress = audioSource.time / audioSource.clip.length * 100;

        progressBar.maxValue = audioSource.clip.length;
        progressBar.value = songProgress;

        // For progress bar testing:
        // UnityEngine.Debug.Log(songProgress + "%" + " out of " + audioSource.clip.length + " seconds");

        if (progressBar.value == progressBar.maxValue)
        {
            NextSong();
        }

        if (isPlaying == false)
        {
            buttonImage.sprite = playImage;
        }

        else
        {
            buttonImage.sprite = pauseImage;
        }
    }
    
    public void PlayPause()
    {
        if (isPlaying == false)
        {
            buttonImage.sprite = pauseImage;

            audioSource.Play();
            isPlaying = true;
        }

        else
        {
            buttonImage.sprite = playImage;

            audioSource.Pause();
            isPlaying = false;
        }

        fullWindow.SetAsLastSibling();
    }

    public void SelectSong0()
    {
        audioSource.Stop();
        audioSource.clip = GetSong(0);
        currentSong = 0;

        audioSource.Play();
        buttonImage.sprite = pauseImage;
        isPlaying = true;

        CheckAlbumArt();

        fullWindow.SetAsLastSibling();
    }

    public void SelectSong1()
    {
        audioSource.Stop();
        audioSource.clip = GetSong(1);
        currentSong = 1;

        audioSource.Play();
        buttonImage.sprite = pauseImage;
        isPlaying = true;

        CheckAlbumArt();

        fullWindow.SetAsLastSibling();
    }

    public void SelectSong2()
    {
        audioSource.Stop();
        audioSource.clip = GetSong(2);
        currentSong = 2;

        audioSource.Play();
        buttonImage.sprite = pauseImage;
        isPlaying = true;

        CheckAlbumArt();

        fullWindow.SetAsLastSibling();
    }

    public AudioClip GetSong(int songNumber)
    {
        return audioClipArray[songNumber];
    }

    public void NextSong()
    {
        audioSource.Stop();

        if (currentSong == 2)
        {
            currentSong = 0;
        }

        else
        {
            currentSong = currentSong + 1;
        }

        audioSource.clip = GetSong(currentSong);
        audioSource.Play();

        if (isPlaying == false)
        {
            audioSource.Pause();
        }

        CheckAlbumArt();

        fullWindow.SetAsLastSibling();
    }

    public void PreviousSong()
    {
        audioSource.Stop();

        if (songProgress > 5)
        {
            audioSource.Play();
        }

        else
        {
            if (currentSong == 0)
            {
                currentSong = 2;
            }

            else
            {
                currentSong = currentSong - 1;
            }

            audioSource.clip = GetSong(currentSong);
            audioSource.Play();
        }

        if (isPlaying == false)
        {
            audioSource.Pause();
        }

        CheckAlbumArt();

        fullWindow.SetAsLastSibling();
    }

    public void CheckAlbumArt()
    {
        if (currentSong == 0)
        {
            albumArt.GetComponent<Image>().sprite = image0;
        }

        if (currentSong == 1)
        {
            albumArt.GetComponent<Image>().sprite = image1;
        }

        if (currentSong == 2)
        {
            albumArt.GetComponent<Image>().sprite = image2;
        }
    }
}
