using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class ScoreTesr: MonoBehaviour
{
    private int Power = 100;
    public Text PowerUI;
    private bool isDoorOpen = true;
    private bool isPowerReducing = false;
    public Button doorButton;
    void Start(){
        doorButton.onClick.AddListener(ToggleDoor);
        PowerUI.text = "Power: " + Power.ToString();
    }
    void Update(){
       if (!isDoorOpen && !isPowerReducing){
            StartCoroutine(ReducePowerOverTime());
        }
    }
     IEnumerator ReducePowerOverTime(){
        isPowerReducing = true;
        while (Power > 0 && !isDoorOpen)
        {
            Power--;
            PowerUI.text = "Power: " + Power.ToString();
            yield return new WaitForSeconds(3f); 
        }
        isPowerReducing = false; 
    }
    void ToggleDoor(){
        isDoorOpen = !isDoorOpen;
        Debug.Log(isDoorOpen ? "Door is now open!" : "Door is now closed!");
    }

}
