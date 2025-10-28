using FlaxEngine;

namespace Game;

/// <summary>
/// UIAnimation class.
/// </summary>
public class UIAnimations
{
    public UIControl Target { get; set; }
    public JsonAssetReference<UIAnim_Base>[] Animations { get; set; }

    public bool AreAllLooped { get; private set; } = false;
    public float PlaybackTime { get; private set; } = 0;

    public void Init()
    {
        foreach (var anim in Animations)
        {
            anim.Instance?.OnInit();
        }
        AreAllLooped = false;
        PlaybackTime = 0;
    }

    public void Start()
    {
        foreach (var anim in Animations)
        {
            anim.Instance?.OnStart(Target);
        }
        AreAllLooped = false;
        PlaybackTime = 0;
    }

    public void Update(float deltaTime)
    {
        PlaybackTime += deltaTime;
        Play(PlaybackTime);
    }

    public void Play(float time)
    {
        AreAllLooped = true;
        foreach (var anim in Animations)
        {
            int looped = anim.Instance?.Play(Target, PlaybackTime) ?? 1;
            AreAllLooped &= looped > 0;
        }
    }
}
