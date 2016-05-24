using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour {

	// Use this for initialization
	GameObject probe_red, probe_orange, probe_yellow, probe_green, probe_blue, probe_purple;
	GameObject probe_red_ref, probe_orange_ref, probe_yellow_ref, probe_green_ref, probe_blue_ref, probe_purple_ref;
	GameObject camera;

	void Start () {
		probe_red = GameObject.FindGameObjectWithTag("red");
		probe_orange = GameObject.FindGameObjectWithTag("orange");
		probe_yellow = GameObject.FindGameObjectWithTag("yellow");
		probe_green = GameObject.FindGameObjectWithTag("green");
		probe_blue = GameObject.FindGameObjectWithTag("blue");
		probe_purple = GameObject.FindGameObjectWithTag("purple");
		probe_red_ref = GameObject.FindGameObjectWithTag("red_ref");
		probe_orange_ref = GameObject.FindGameObjectWithTag("orange_ref");
		probe_yellow_ref = GameObject.FindGameObjectWithTag("yellow_ref");
		probe_green_ref = GameObject.FindGameObjectWithTag("green_ref");
		probe_blue_ref = GameObject.FindGameObjectWithTag("blue_ref");
		probe_purple_ref = GameObject.FindGameObjectWithTag("purple_ref");
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		Rigidbody r = GetComponent<Rigidbody>();
		r.AddTorque(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// c_pos will reference the camera's position
		Vector3 c_pos = camera.transform.position;

		// Objects below are positioned on the 6 faces of the cube.
		// There are 2 for every face
		Vector3 p0_pos = probe_red.transform.position;
		Vector3 p1_pos = probe_orange.transform.position;
		Vector3 p2_pos = probe_yellow.transform.position;
		Vector3 p3_pos = probe_green.transform.position;
		Vector3 p4_pos = probe_blue.transform.position;
		Vector3 p5_pos = probe_purple.transform.position;
		
		Vector3 p0_ref_pos = probe_red_ref.transform.position;
		Vector3 p1_ref_pos = probe_orange_ref.transform.position;
		Vector3 p2_ref_pos = probe_yellow_ref.transform.position;
		Vector3 p3_ref_pos = probe_green_ref.transform.position;
		Vector3 p4_ref_pos = probe_blue_ref.transform.position;
		Vector3 p5_ref_pos = probe_purple_ref.transform.position;

		// These are the angles between the light sources and the faces of the cube
		float p0_theta, p1_theta, p2_theta, p3_theta, p4_theta, p5_theta;

		// These vectors are used in calculating the angle between the light source and the cube faces.
		Vector3 a, b;
		
		a = new Vector3(p0_pos.x - c_pos.x, p0_pos.y - c_pos.y, p0_pos.z - c_pos.z);
		b = new Vector3(p0_pos.x - p0_ref_pos.x, p0_pos.y - p0_ref_pos.y, p0_pos.z - p0_ref_pos.z);
		p0_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p0_theta > 90) p0_theta = 180 - p0_theta;
		
		a = new Vector3(p1_pos.x - c_pos.x, p1_pos.y - c_pos.y, p1_pos.z - c_pos.z);
		b = new Vector3(p1_pos.x - p1_ref_pos.x, p1_pos.y - p1_ref_pos.y, p1_pos.z - p1_ref_pos.z);
		p1_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p1_theta > 90) p1_theta = 180 - p1_theta;
		
		a = new Vector3(p2_pos.x - c_pos.x, p2_pos.y - c_pos.y, p2_pos.z - c_pos.z);
		b = new Vector3(p2_pos.x - p2_ref_pos.x, p2_pos.y - p2_ref_pos.y, p2_pos.z - p2_ref_pos.z);
		p2_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p2_theta > 90) p2_theta = 180 - p2_theta;
		
		a = new Vector3(p3_pos.x - c_pos.x, p3_pos.y - c_pos.y, p3_pos.z - c_pos.z);
		b = new Vector3(p3_pos.x - p3_ref_pos.x, p3_pos.y - p3_ref_pos.y, p3_pos.z - p3_ref_pos.z);
		p3_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p3_theta > 90) p3_theta = 180 - p3_theta;
		
		a = new Vector3(p4_pos.x - c_pos.x, p4_pos.y - c_pos.y, p4_pos.z - c_pos.z);
		b = new Vector3(p4_pos.x - p4_ref_pos.x, p4_pos.y - p4_ref_pos.y, p4_pos.z - p4_ref_pos.z);
		p4_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p4_theta > 90) p4_theta = 180 - p4_theta;
		
		a = new Vector3(p5_pos.x - c_pos.x, p5_pos.y - c_pos.y, p5_pos.z - c_pos.z);
		b = new Vector3(p5_pos.x - p5_ref_pos.x, p5_pos.y - p5_ref_pos.y, p5_pos.z - p5_ref_pos.z);
		p5_theta = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(a, b) / Vector3.Magnitude(a) / Vector3.Magnitude(b));
		if(p5_theta > 90) p5_theta = 180 - p5_theta;

		print("Yellow: " + p2_theta);

		//Rigidbody r = GetComponent<Rigidbody>();
		//r.AddTorque(1, -1, 0.5f);
	}
}
