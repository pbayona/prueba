using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
    public void updateGeneralVolume(UnityEngine.UI.Slider slider)
    {
        AudioManager.setGeneralVolume(slider.value);
    }

    public void updateMusicVolume(UnityEngine.UI.Slider slider)
    {
        AudioManager.setMusicVolume(slider.value);
    }

    public void updateSfxVolume(UnityEngine.UI.Slider slider)
    {
        AudioManager.setSfxVolume(slider.value);
    }
}
