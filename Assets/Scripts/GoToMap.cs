using UnityEngine;
using System.Collections;

public class GoToMap : MonoBehaviour {

	public void openAppleMaps() {
		print ("*** onClick openAppleMaps executing ***");

		// sample Apple Maps URL: http://maps.apple.com/?ll=50.894967,4.341626
		Application.OpenURL("http://maps.apple.com/?ll=50.894967,4.341626");
	}

}// end of class GoToMap
