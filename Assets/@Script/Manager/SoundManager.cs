using UnityEngine;

public class SoundManager
{
    private AudioSource _bgmPlayer;
    private AudioSource BgmPlayer
    {
        get
        {
            if (_bgmPlayer == null)
            {
                _bgmPlayer = new GameObject("BGM").AddComponent<AudioSource>();
                GameObject.DontDestroyOnLoad(_bgmPlayer.gameObject);
                _bgmPlayer.loop = true;
            }
            return _bgmPlayer;
        }
    }

    private AudioSource _sfxPlayer;
    private AudioSource SfxPlayer
    {
        get
        {
            if (_sfxPlayer == null)
            {
                _sfxPlayer = new GameObject("SFX").AddComponent<AudioSource>();
                GameObject.DontDestroyOnLoad(_sfxPlayer.gameObject);
            }
            return _sfxPlayer;
        }
    }

    private float _masterVolume;
    private float _sfxVolume;
    private float _bgmVolume;

    public float MasterVolume
    {
        get { return _masterVolume; }
        set
        {
            _masterVolume = value;
            SfxPlayer.volume = _sfxVolume * _masterVolume;
            BgmPlayer.volume = _bgmVolume * _masterVolume;
        }
    }
    public float SfxVolume
    {
        get { return _sfxVolume; }
        set
        {
            _sfxVolume = value;
            SfxPlayer.volume = _sfxVolume * _masterVolume;
        }
    }
    public float BgmVolume
    {
        get { return _bgmVolume; }
        set
        {
            _bgmVolume = value;
            BgmPlayer.volume = _bgmVolume * _masterVolume;
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SfxPlayer.PlayOneShot(audioClip);
    }

    public void SetBGM(AudioClip audioClip)
    {
        if (audioClip == BgmPlayer.clip)
            return;

        BgmPlayer.clip = audioClip;
        if (audioClip != null)
            BgmPlayer.Play();
        else
            BgmPlayer.Stop();
    }
}
