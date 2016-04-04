using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {
	[SerializeField]
	private int[] levelPopMin;
	[SerializeField]
	private int[] levelPopMax;

	[SerializeField]
	private GameObject satellitePrefab;

	// Use this for initialization
	void Start () {
		createSystem(gameObject, 0);
	}

	void createSystem(GameObject parent, int depth) {
		if (depth >= levelPopMin.Length) return;
		int bodyCount = Random.Range(levelPopMin[depth], levelPopMax[depth] + 1);
		for(int i = 0; i < bodyCount; ++i) {
			GameObject satellite = Instantiate<GameObject>(satellitePrefab);
			satellite.transform.parent = parent.transform;
			createSystem(satellite, depth + 1);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
