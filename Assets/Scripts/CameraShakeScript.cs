using Cinemachine;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public static CameraShakeScript Instance { get; private set; }

    private CinemachineVirtualCamera cmVC;
    private CinemachineBasicMultiChannelPerlin cmVCBMCP;

    private float startingIntensity;
    private float shakeDuration;
    private float shakeTimerTotal;

    private void Awake()
    {
        Instance = this;
        cmVC = GetComponent<CinemachineVirtualCamera>();
        cmVCBMCP = cmVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Takes the intensity for a camera shake and the duration of it from another script

    public void ShakeCamera(float intensity, float time)
    {
        cmVCBMCP.m_AmplitudeGain = intensity;

        startingIntensity = intensity; //Starting intensity for the starting point of from where to lower in the Mathf.Lerp statement
        shakeTimerTotal = time; //Timer on gradually setting the intensity to lower
        shakeDuration = time; // Duration of the shake
    }

    private void Update()
    {
        if (shakeDuration > 0f)
        {
            shakeDuration -= Time.deltaTime;
            if (shakeDuration <= 0f)
            {
                cmVCBMCP.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeDuration / shakeTimerTotal)); //Sets the intensity of the camera shake to lower gradually over a given time
            }
        }
    }
}
