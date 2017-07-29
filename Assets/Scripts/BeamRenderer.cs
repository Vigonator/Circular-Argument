using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRenderer : MonoBehaviour {

    Vector3 _start;
    public Vector3 start
    {
        get
        {
            return _start;
        }

        set
        {
            _start = value;

            Debug.Log("start has been set");
            line.SetPosition(0, _start);
        }
    }

    Vector3 _end;
    public Vector3 end
    {
        get
        {
            return _end;
        }

        set
        {
            _end = value;

            line.SetPosition(1, _end);
        }
    }

    public float duration;
    float startTime;
    Color color, endColor;
    LineRenderer line;

	// Use this for initialization
	void Awake () {
        Debug.Log("Start has been called");

        line = this.GetComponent<LineRenderer>();
        startTime = Time.time;
        Debug.Log("startime is " + startTime);

        color = new Color(200, 10, 180);
        endColor = new Color(200, 10, 180, 0);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("duration is " + duration);

        Color interpColor = Color.Lerp(color, endColor, (Time.time - startTime) / duration);

        line.startColor = interpColor;
        line.endColor = interpColor;

		if(Time.time - startTime > duration)
        {

            Debug.Log("object should be destroyed now");
            Destroy(this.gameObject);
        }
	}
}
