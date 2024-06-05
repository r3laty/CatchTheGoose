using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public List<MonoBehaviour> AllMissions;

    [HideInInspector] public bool StartMissionOne;
    public void StartMission(int missionID)
    {
        switch (missionID)
        {
            case 1: 
                StartMissionOne = true;
                break;
        }
    }
    private void Update()
    {
        if (StartMissionOne)
        {
            foreach (MonoBehaviour mission in AllMissions)
            {
                if (mission is IMissionable missionable)
                {
                    missionable.Execute();
                }
            }
        }
    }
}
