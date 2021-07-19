using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public GameObject LapTimeBox;

	public GameObject LapCount;
	public int LapsDone;

	public float RawTime;

	public GameObject RaceFinish;

	void Update()
	{
		if (LapsDone == 2){
			RaceFinish.SetActive(true);
		}
	}

	void OnTriggerEnter () {

		LapsDone++;
		RawTime = PlayerPrefs.GetFloat("RawTime");

		if(LapTimerManager.RawTime <= RawTime){
			if (LapTimerManager.SecondCount <= 9) {
				SecondDisplay.GetComponent<Text> ().text = "0" + LapTimerManager.SecondCount + ".";
			} else {
				SecondDisplay.GetComponent<Text> ().text = "" + LapTimerManager.SecondCount + ".";
			}

			if (LapTimerManager.MinuteCount <= 9) {
				MinuteDisplay.GetComponent<Text> ().text = "0" + LapTimerManager.MinuteCount + ".";
			} else {
				MinuteDisplay.GetComponent<Text> ().text = "" + LapTimerManager.MinuteCount + ".";
			}
		
			MilliDisplay.GetComponent<Text> ().text = "" + LapTimerManager.MilliCount;
		}
		PlayerPrefs.SetInt("MinSave", LapTimerManager.MinuteCount);
		PlayerPrefs.SetInt("SecSave", LapTimerManager.SecondCount);
		PlayerPrefs.SetFloat("MilliSave", LapTimerManager.MilliCount);
		PlayerPrefs.SetFloat("RawTime", LapTimerManager.RawTime);

		
		LapTimerManager.MinuteCount = 0;
		LapTimerManager.SecondCount = 0;
		LapTimerManager.MilliCount = 0;
		LapTimerManager.RawTime = 0;
		LapCount.GetComponent<Text>().text = "" + LapsDone;

		HalfLapTrig.SetActive (true);
		LapCompleteTrig.SetActive (false);
	}
}
