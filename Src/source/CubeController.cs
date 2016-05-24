using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	
	Vector3 earthMagneticField;

	GameObject xAxisObject, yAxisObject, zAxisObject;
	Vector3 xAxis, yAxis, zAxis;

	bool xDone, yDone, zDone;
	bool begin, finishedDetumbling;
	float startTime;
	float zLoc = 0;
	float lastZ;
	bool zDerivative; // positive = TRUE ; negative = FALSE
	Rigidbody r;

	// Use this for initialization
	void Start () {
		xDone = yDone = zDone = false;
		begin = finishedDetumbling = false;

		earthMagneticField = new Vector3(1, -1, 2);
		
		xAxisObject = GameObject.FindGameObjectWithTag("blueX");
		yAxisObject = GameObject.FindGameObjectWithTag("purpleZ");
		zAxisObject = GameObject.FindGameObjectWithTag("greenY");

		r = GetComponent<Rigidbody>();
		//r.AddRelativeTorque(new Vector3(0.1f, 0, 0f));
		startTime = Time.time;
	}
	int count = 0;
	float xTime;
	bool currentDerivative;

	Vector3 theta, lastTheta, deltaTheta;

	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > startTime + 2 && !begin) {
			begin = true;
			print ("Initiate detumbling...");
		}
		if(!begin) return;


		Vector3 pos = r.transform.InverseTransformDirection(earthMagneticField);

		Vector3 baseX = yAxisObject.transform.position;
		Vector3 removeX = pos;
		Vector3 removeY = pos;
		Vector3 removeZ = pos;
		removeX.x = 0;
		removeY.y = 0;
		removeZ.z = 0;
		theta.x = Mathf.Acos(Vector3.Dot(baseX, removeX) / (Vector3.Magnitude(baseX) * Vector3.Magnitude(removeX)));
		if(removeX.z < 0) theta.x = 2*Mathf.PI - theta.x;
		theta.y = Mathf.Acos(Vector3.Dot(pos, removeY) / (Vector3.Magnitude(pos) * Vector3.Magnitude(removeY)));
		theta.z = Mathf.Acos(Vector3.Dot(pos, removeZ) / (Vector3.Magnitude(pos) * Vector3.Magnitude(removeZ)));

		deltaTheta = theta - lastTheta; // divide by deltaTime???
		if(deltaTheta.x < 0) deltaTheta.x += 2*Mathf.PI;
		if(deltaTheta.y < 0) deltaTheta.y += 2*Mathf.PI;
		if(deltaTheta.z < 0) deltaTheta.z += 2*Mathf.PI;

		print("Calculated:  " + (deltaTheta.x / Time.deltaTime));
		print("Actual:  " + transform.InverseTransformDirection(r.angularVelocity).x);

		lastTheta = theta;


		

		// Follwing sinusoidal pattern to record rotational speed (FAILS)

		/*
		


		zDerivative = zAxisObject.transform.position.z > lastZ;

		if(zLoc == 0) {
			zLoc = zAxisObject.transform.position.z;
			xTime = Time.time;
			currentDerivative = zDerivative;
		}
		if(currentDerivative != zDerivative) {
			if(zDerivative) {
				if(zAxisObject.transform.position.z > zLoc) {
					count++;
					currentDerivative = zDerivative;
				}
			}
			else {
				if(zAxisObject.transform.position.z < zLoc) {
					count++;
					currentDerivative = zDerivative;
				}
			}
			if(count == 2) {
				print("Time: " + (Time.time - xTime) + " sec");
				print ("Actual: " + transform.InverseTransformDirection(r.angularVelocity).x + " rad/s");
				count = 0;
				zLoc = zAxisObject.transform.position.z;
				xTime = Time.time;
			}
		}
		*/



		// Once angular velocities are known, the below method successfully detumbles.  (need physics)

		/*
		Vector3 localangularvelocity = transform.InverseTransformDirection(r.angularVelocity);

		if(localangularvelocity.x > 0) r.AddRelativeTorque(new Vector3(-0.001f, 0, 0));
		if(localangularvelocity.y > 0 && localangularvelocity.x <= 0) r.AddRelativeTorque(new Vector3(0, -0.001f, 0));
		if(localangularvelocity.z < 0 && localangularvelocity.y <= 0) r.AddRelativeTorque(new Vector3(0, 0, 0.001f));

		if(localangularvelocity.x <=0 && !xDone) {
			xDone = true;
			print ("X Axis has detumbled.");
		}
		if(localangularvelocity.y <=0 && !yDone) {
			yDone = true;
			print ("Y Axis has detumbled.");
		}
		if(localangularvelocity.z >=0 && !zDone) {
			zDone = true;
			print ("Z Axis has detumbled.");
		}

		if(zDone && !finishedDetumbling) {
			finishedDetumbling = true;
			print("Detumbling complete!");
		}
		lastZ = zAxisObject.transform.position.z;
		*/
		// Start allignment

	}
}
