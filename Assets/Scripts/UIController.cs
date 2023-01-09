using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;

    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(musicSlider.value);
    }
}
