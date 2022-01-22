using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_progressTracker : MonoBehaviour
{    
    

    float initialDistance;
    float currentDistance = 200000000;
    float previousDistance = 2000000000;
    float progress = 1;

    float initialTrackerDistance;
    float initialTrackerPosition;
    
    public GameObject go_tracker;
    public GameObject go_trackerEnd;
    public GameObject go_player;
    public GameObject go_stageEnd;

    void Start()
    {
        initialTrackerPosition = go_tracker.transform.position.x;
        
        initialTrackerDistance = Vector3.Distance(go_tracker.transform.position, go_trackerEnd.transform.position);
        initialDistance = Vector3.Distance(go_player.transform.position, go_stageEnd.transform.position);
    }

    void Update()
    {
        previousDistance = currentDistance;
        currentDistance = Vector3.Distance(go_player.transform.position, go_stageEnd.transform.position);
        
        if (progress > 0 && currentDistance <= previousDistance)
            progress = (currentDistance / initialDistance);

        else
            progress = 0;
        Debug.Log(progress);

        go_tracker.transform.position = new Vector3(initialTrackerPosition + (progress * initialTrackerDistance), go_tracker.transform.position.y, 0);


    }
}
