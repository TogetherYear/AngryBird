using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAudioManager : TSingleton<TAudioManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    [SerializeField]
    private List<AudioClip> birdCollision;

    [SerializeField]
    private List<AudioClip> birdSelect;

    [SerializeField]
    private List<AudioClip> birdFlying;

    [SerializeField]
    private List<AudioClip> pigCollision;

    [SerializeField]
    private List<AudioClip> woodCollision;

    [SerializeField]
    private List<AudioClip> woodDestroyed;

    private Dictionary<TAudioType, List<AudioClip>> audios = new Dictionary<TAudioType, List<AudioClip>>();

    private void Start()
    {
        audios.Add(TAudioType.BirdCollision, birdCollision);
        audios.Add(TAudioType.BirdSelect, birdSelect);
        audios.Add(TAudioType.BirdFlying, birdFlying);
        audios.Add(TAudioType.PigCollision, pigCollision);
        audios.Add(TAudioType.WoodCollision, woodCollision);
        audios.Add(TAudioType.WoodDestroyed, woodDestroyed);
    }

    public void PlayAudio(TAudioType type, Vector3 position, float volume = 1.0f)
    {
        List<AudioClip> current;
        if (audios.TryGetValue(type, out current))
        {
            AudioSource.PlayClipAtPoint(current[Random.Range(0, current.Count)], position, volume);
        }
    }
}

public enum TAudioType
{
    BirdCollision,
    BirdSelect,
    BirdFlying,
    PigCollision,
    WoodCollision,
    WoodDestroyed,
}
