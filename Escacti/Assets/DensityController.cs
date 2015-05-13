using UnityEngine;
using System.Collections;

public class DensityController : MonoBehaviour {

	[SerializeField]
	protected int nLowMin;
	[SerializeField]
	protected int nLowMax;
	[SerializeField]
	protected int nHighMin;
	[SerializeField]
	protected int nHighMax;

	[SerializeField]
	protected int lowIntMin;
	[SerializeField]
	protected int lowIntMax;

	[SerializeField]
	protected int highIntMin;
	[SerializeField]
	protected int highIntMax;

	private bool low;

	// Use this for initialization
	void Start () {
		low = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
