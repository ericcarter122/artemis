using UnityEngine;
public class PID : MonoBehaviour {
	public float timeInterval;
	public float kP, kI, kD;
	public float target;
	float errorSum, lastError;

	public float GetOutput(float input) {
		
		// Compute errors for all metrics
		float error = target - input;
		errorSum += error;
		float dError = error - errorSum;

		// Compute PID output
		float output = kP * error + kI * errorSum + kD * dError;

		lastError = error;
		return output;
	}

}
