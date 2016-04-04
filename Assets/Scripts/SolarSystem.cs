using UnityEngine;

public class SolarSystem : MonoBehaviour {
	[SerializeField]
	public int[] levelPopMin;
	[SerializeField]
	public int[] levelPopMax;
	[SerializeField]
	public float baseOrbitSize = 10;
	[SerializeField]
	public float orbitSizeScale = 5;
	[SerializeField]
	public float massScale = 10;


	[SerializeField]
	private GameObject satellitePrefab;

	void Start () {
		createSystem(gameObject, 0);
	}

	void createSystem(GameObject parent, int depth) {
		if (depth >= levelPopMin.Length) return;
		int bodyCount = Random.Range(levelPopMin[depth], levelPopMax[depth] + 1);
		for(int i = 0; i < bodyCount; ++i) {
			GameObject satellite = Instantiate<GameObject>(satellitePrefab);
			satellite.transform.parent = parent.transform;
			Satellite satCom = satellite.GetComponent<Satellite>();
			satCom.mass = Mathf.Pow(massScale, -depth) * Random.Range(0.5f, 2.0f);
			satCom.initialPhase = Random.value * 2 * Mathf.PI;
			satCom.orbitLength = baseOrbitSize * Mathf.Pow(orbitSizeScale, -depth) * Random.Range(0.2f, 1.0f);
			createSystem(satellite, depth + 1);
		}
	}

	void Update () {
	
	}
}
