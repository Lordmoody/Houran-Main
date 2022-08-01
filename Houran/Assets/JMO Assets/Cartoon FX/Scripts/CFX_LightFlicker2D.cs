using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
#endif
using UnityEngine.Experimental.Rendering.Universal;
// Cartoon FX  - (c) 2015 Jean Moreno

// Randomly changes a light's intensity over time.

[RequireComponent(typeof(Light2D))]
public class CFX_LightFlicker2D : MonoBehaviour
{
	// Loop flicker effect
	public bool loop;
	
	// Perlin scale: makes the flicker more or less smooth
	public float smoothFactor = 1f;
	
	/// Max intensity will be: baseIntensity + addIntensity
	public float addIntensity = 1.0f;
	
	private float minIntensity;
	private float maxIntensity;
	private float baseIntensity;
	
	void Awake()
	{
		baseIntensity = GetComponent<Light2D>().intensity;
	}
	
	void OnEnable()
	{
		minIntensity = baseIntensity;
		maxIntensity = minIntensity + addIntensity;
	}
	
	void Update ()
	{
		GetComponent<Light2D>().intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(Time.time * smoothFactor, 0f));
	}
}
