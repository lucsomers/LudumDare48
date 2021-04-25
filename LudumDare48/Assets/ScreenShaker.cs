using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    #region SingleTon

    public static ScreenShaker instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

	#endregion

	[SerializeField] private float shakeDuration = 1f;
	[SerializeField] private float shakeAmount = 0.7f;
	[SerializeField] private float decreaseFactor = 1.0f;

	private Transform camTransform;
	private Vector3 originalPos;

	private bool isShaking = false;

	void Start()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent<Camera>().transform;
		}
	}

	public void ShakeScreen()
    {
		originalPos = camTransform.localPosition;
		StartCoroutine(Shake());
	}

	private IEnumerator Shake()
	{
		//The screenshake code comes from
		//https://gist.github.com/ftvs/5822103#:~:text=118%20Forks%2018-,Simple%20camera%20shake%20effect%20for%20Unity3d%2C%20written%20in%20C%23.,shaking%20if%20it%20is%20enabled.

		float originalShakeDuration = shakeDuration;
		isShaking = true;

		while (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;

			yield return new WaitForEndOfFrame();
		}

		shakeDuration = originalShakeDuration;
		camTransform.localPosition = originalPos;
		isShaking = false;
	}

	public bool IsShaking { get => isShaking; }
}
