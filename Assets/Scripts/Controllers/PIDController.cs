using UnityEngine;
using System.Collections.Generic;

public class PIDController {

	public float timeInterval;

    public List<float> errors;
    public float lastOutput = 0; //start at zero
	public float kP, kI, kD;
    public float target = 0; //default zero
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

        errors.Add(error);
        if (errors.Count > 3) errors.RemoveAt(0);

        float a = kP + kI * timeInterval / 2 + kD / timeInterval;
        float b = -kP + kI * timeInterval / 2 - 2 * kD / timeInterval;
        float c = kD / timeInterval;

        int i = 3;
        //Compute PID output
        float output = lastOutput + a * errors(i) + b * errors(i - 1) + c * errors(i - 2);
        lastOutput = output;

		//errorSum += error;
		//var dError = error - errorSum;

		// Compute PID output
		//var output = kP * error + kI * errorSum + kD * dError;

		//lastError = error;
		return output;
	}

}