using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class CallNightAndDay : MonoBehaviour
{
    // Start is called before the first frame update

    /*bool isMorning;
    bool isNoon;
    bool isAfternoon;
    bool isNight;*/

    bool NoonCalled;
    bool AfternoonCalled;
    bool NightCalled;
    bool AfterGameTimeCalled;

    public int NoonTime;
    public int AfternoonTime;
    public int NightTime;
    public int AfterGameTime;

    public AzureTimeController azt;
    public GameObject constellations;

    public MyQuestGiver questGiver;

    public Light dirLight;
    public Light skyLight;

    // Update is called once per frame
    void Update()
    {
        dirLight.transform.rotation = skyLight.transform.rotation;
        dirLight.color = skyLight.color;

        if (!NoonCalled && GetComponent<FlowersQuest>().enabled)
        {
            azt.enabled = true;
            azt.StartTimelineTransition(NoonTime + 1, 00, 100, AzureTimeDirection.Forward);

            NoonCalled = true;
        }
        if(NoonCalled && azt.GetTimeline() > NoonTime)
        {
            NoonCalled = false;
            azt.enabled = false;
        }


        if (!AfternoonCalled && GetComponent<FireQuest>().enabled)
        {
            azt.enabled = true;
            azt.StartTimelineTransition(AfternoonTime + 1, 00, 100, AzureTimeDirection.Forward);

            AfternoonCalled = true;
        }
        if (AfternoonCalled && azt.GetTimeline() > AfternoonTime)
        {
            AfternoonCalled = false;
            azt.enabled = false;
        }


        if (!NightCalled && GetComponent<StarsQuest>().enabled)
        {
            azt.enabled = true;
            azt.StartTimelineTransition(NightTime + 1, 00, 100, AzureTimeDirection.Forward);

            NightCalled = true;
        }
        if (NightCalled && azt.GetTimeline() > NightTime)
        {
            NightCalled = false;
            azt.enabled = false;
            constellations.SetActive(true);
        }


        if(!AfterGameTimeCalled && questGiver.AllQuestsCompleted)
        {
            azt.enabled = true;
            constellations.SetActive(false);
            azt.StartTimelineTransition(AfterGameTime - 1, 00, 100, AzureTimeDirection.Backward);

            AfterGameTimeCalled = true;
        }
        if(AfterGameTimeCalled && azt.GetTimeline() < AfterGameTime)
        {
            AfterGameTimeCalled = false;
            azt.enabled = false;
        }

    }
}
