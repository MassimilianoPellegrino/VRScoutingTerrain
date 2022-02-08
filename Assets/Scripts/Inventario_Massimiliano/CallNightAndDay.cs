using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class CallNightAndDay : MonoBehaviour
{
    // Start is called before the first frame update

    bool isNight = false;
    public AzureTimeController azt;
    public GameObject constellations;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isNight && azt.enabled == false)
            {
                azt.enabled = true;
                //azt.CancelTimelineTransition();
                azt.StartTimelineTransition(24, 00, 100, AzureTimeDirection.Forward);               
            }
            else if(isNight && azt.enabled == false)
            {
                azt.enabled = true;
                //azt.CancelTimelineTransition();
                azt.StartTimelineTransition(12, 00, 100, AzureTimeDirection.Backward);
            }
        }

        if(!isNight && azt.GetTimeline() > 23 && azt.GetTimeline()<24)
        {
            //azt.CancelTimelineTransition();
            constellations.SetActive(true);
            azt.enabled = false;            
            isNight = true;
        }


        if(isNight && azt.GetTimeline() > 12 && azt.GetTimeline() <13)
        {
            //azt.CancelTimelineTransition();
            constellations.SetActive(false);
            azt.enabled = false;            
            isNight = false;
        }
        
    }
}
