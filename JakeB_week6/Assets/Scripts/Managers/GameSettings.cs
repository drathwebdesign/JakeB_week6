using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Start() {
        if (SoundMixerManager.Instance != null) {
            SoundMixerManager.Instance.LoadSettings();
        } else {
            Debug.LogWarning("SoundMixerManager is not initialized yet.");
        }
    }
}