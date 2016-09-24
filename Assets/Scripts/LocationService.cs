﻿using UnityEngine;
using System.Collections;

public class LocationService: MonoBehaviour {

	IEnumerator Start() {
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			print("Timed out");
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			yield break;
		} else {
			// Access granted and location value could be retrieved
			print("Location: " + Input.location.lastData.latitude + 
					" " + Input.location.lastData.longitude + 
					" " + Input.location.lastData.altitude + 
					" " + Input.location.lastData.horizontalAccuracy + 
					" " + Input.location.lastData.timestamp);
		}

		// Code to stop using location services if needed
		//Input.location.Stop();
	}

	void Update() {
		print ("Latitude: " + Input.location.lastData.latitude + " | Longitude: " + Input.location.lastData.longitude);
	}

}// end of LocationService class
