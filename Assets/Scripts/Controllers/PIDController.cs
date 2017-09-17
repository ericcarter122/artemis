using UnityEngine;

public class PIDController {

	public float timeInterval;

	public float kP, kI, kD;
	public float target;
	public float lastError, errorSum;
	public bool enabled;

	public PIDController(float kP, float kI, float kD) {
		this.kP = kP;
		this.kI = kI;
		this.kD = kD;

		timeInterval = Time.fixedDeltaTime;
		enabled = true;
	}

	public void SetGains(float kP, float kI, float kD) {
		this.kP = kP;
		this.kI = kI;
		this.kD = kD;
	}

	public void SetTarget(float target) {
		this.target = target;
	}

	public float Update(float input) {

		if (!enabled)
			return target;

		// Generate error signals for all operations
		var error = target - input;
		errorSum += error;
		var dError = error - errorSum;

		// Compute PID output
		var output = kP * error + kI * errorSum + kD * dError;

		lastError = error;
		return output;
	}

}