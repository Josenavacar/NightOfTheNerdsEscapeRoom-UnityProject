using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundObjectManager : MonoBehaviour
{
    #region singleton

    public static SoundObjectManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private List<AudioManager> audioManagers = new List<AudioManager>();

    private List<AudioManager> GetManagersByAudioName(EnumAudioName audioName){
        List<AudioManager> managers = new List<AudioManager>();
        foreach(AudioManager manager in audioManagers){
            if(manager.GetAudioName() == audioName){
                managers.Add(manager);
            }
        }
        return managers;
    }

    public void PlaySoundByAudioName(EnumAudioName audioName){
        foreach(AudioManager manager in GetManagersByAudioName(audioName)){
            manager.Activate();
        }
    }
}
