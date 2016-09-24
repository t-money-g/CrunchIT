using UnityEngine;
using System.Collections;

public class MainMenuNavigationHandler : MonoBehaviour {

	public void goToPlayScreen() {
		Application.LoadLevel(1);
	}

	public void goToRewardsScreen() {
		Application.LoadLevel(2);
	}

	public void openAppleMaps() {
		// sample Apple Maps URL: http://maps.apple.com/?ll=50.894967,4.341626
		// Nearest Food Distribution Point: 41.8952177,-87.6344652
		Application.OpenURL("http://maps.apple.com/?q=Catholic+Charities&ll=41.8952177,-87.6344652");
		//Application.OpenURL("http://maps.apple.com/?daddr=721 N. Lasalle St.");
	}

}
