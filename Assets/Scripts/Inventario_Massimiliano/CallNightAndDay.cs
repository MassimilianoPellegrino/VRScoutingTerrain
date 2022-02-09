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

    bool MorningCalled;
    bool NoonCalled;
    bool AfternoonCalled;
    bool NightCalled;

    public int MorningTime;
    public int NoonTime;
    public int AfternoonTime;
    public int NightTime;

    public AzureTimeController azt;
    public GameObject constellations;

    public MyQuestGiver questGiver;


    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isNight && azt.enabled == false)
            {
                azt.enabled = true;
                azt.StartTimelineTransition(24, 00, 100, AzureTimeDirection.Forward);               
            }
            else if(isNight && azt.enabled == false)
            {
                azt.enabled = true;
                azt.StartTimelineTransition(12, 00, 100, AzureTimeDirection.Backward);
            }
        }

        if(!isNight && azt.GetTimeline() > 23 && azt.GetTimeline()<24)
        {
            constellations.SetActive(true);
            azt.enabled = false;            
            isNight = true;
        }


        if(isNight && azt.GetTimeline() > 12 && azt.GetTimeline() <13)
        {
            constellations.SetActive(false);
            azt.enabled = false;            
            isNight = false;
        }*/

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


        if(!MorningCalled && questGiver.AllQuestsCompleted)
        {
            azt.enabled = true;
            constellations.SetActive(false);
            azt.StartTimelineTransition(MorningTime - 1, 00, 100, AzureTimeDirection.Backward);

            MorningCalled = true;
        }
        if(MorningCalled && azt.GetTimeline() < MorningTime)
        {
            MorningCalled = false;
            azt.enabled = false;
        }

    }
}
