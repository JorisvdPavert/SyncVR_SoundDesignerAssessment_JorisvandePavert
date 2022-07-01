using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] AudioSource footstepsAudioSource = null;
    [SerializeField] AudioSource jumpingAudioSource = null;

    [Header("Audio Clips")]
    [SerializeField] AudioClip[] softSteps = null;
    [SerializeField] AudioClip[] hardSteps = null;
    [SerializeField] AudioClip softLanding = null;
    [SerializeField] AudioClip[] hardLandings = null;
    [SerializeField] AudioClip jump = null;

    [Header("Steps")]
    [SerializeField] float stepsTimeGap = 1f;

    private float stepsTimer;
    private int lastHardLandingIndex;

    public void PlaySteps(GroundType groundType, float speedNormalized)
    {
        if (groundType == GroundType.None)
            return;

        stepsTimer += Time.fixedDeltaTime * speedNormalized;

        if (stepsTimer >= stepsTimeGap)
        {
            var steps = groundType == GroundType.Hard ? hardSteps : softSteps;
            int index = Random.Range(0, steps.Length);
            footstepsAudioSource.PlayOneShot(steps[index]);

            stepsTimer = 0;
        }
    }

    public void PlayJump()
    {
        jumpingAudioSource.PlayOneShot(jump);
    }

    private int GetHardLandingIndex()
    {
        var hardLandingIndex = Random.Range(0, hardLandings.Length);
        if (hardLandingIndex == lastHardLandingIndex)
        {
            return GetHardLandingIndex();
        }
        return hardLandingIndex;
    }

    public void PlayLanding(GroundType groundType)
    {
        if (groundType == GroundType.Hard)
        {
            var hardLandingIndex = GetHardLandingIndex();
            lastHardLandingIndex = hardLandingIndex;
            jumpingAudioSource.PlayOneShot(hardLandings[hardLandingIndex]);
        }
        else
            jumpingAudioSource.PlayOneShot(softLanding);
    }
}
