using UnityEngine;
public class PidController3Axis {

    public float timeInterval;

    public Vector3 kP, kI, kD;
    public Vector3 target;
    public Vector3 lastError, errorSum;
    public bool enabled;

    public PidController3Axis(float kP, float kI, float kD) {
        this.kP = new Vector3(kP, kP, kP);
        this.kI = new Vector3(kI, kI, kI);
        this.kD = new Vector3(kD, kD, kD);

        timeInterval = Time.fixedDeltaTime;
        enabled = true;
    }

    public void SetGains(float kP, float kI, float kD) {
        this.kP = new Vector3(kP, kP, kP);
        this.kI = new Vector3(kI, kI, kI);
        this.kD = new Vector3(kD, kD, kD);
    }

    public void SetTarget(Vector3 target) {
        this.target = target;
    }

    public Vector3 Update(Vector3 input) {
     
        if (!enabled)
            return target;
        
        // Generate error signals for all operations
		var error = target - input;
		errorSum += error;
		var dError = error - errorSum;

		// Compute PID output
		var output = Vector3.Scale(kP, error) + Vector3.Scale(kI, errorSum) + Vector3.Scale(kD, dError);

		lastError = error;
		return output;
    }

}