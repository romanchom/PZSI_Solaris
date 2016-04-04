using UnityEngine;
using System.Collections;

public class Satellite : CelestialBody {
	[HideInInspector]
	public float orbitLength;
	[HideInInspector]
	public float initialPhase;

	float orbitPeriod;
	void Start () {
		CelestialBody parent = transform.parent.GetComponent<CelestialBody>();
		orbitPeriod = Mathf.Sqrt(Mathf.Pow(orbitLength, 3) / parent.mass) * 50;
		transform.GetChild(0).transform.localScale = Vector3.one * Mathf.Pow(mass, 1.0f / 3.0f);
	}
	
	void Update () {
		float phase = Mathf.Repeat(Time.time / orbitPeriod, 1) * 2 * Mathf.PI + initialPhase;
		transform.localPosition = orbitLength * new Vector3(Mathf.Cos(phase), Mathf.Sin(phase), 0);
	}
}
