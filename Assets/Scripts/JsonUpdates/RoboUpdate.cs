﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

/// <summary>
/// This class represents updates to Kirby's odometry
/// </summary>

public class RoboUpdate
{
    [JsonProperty("odom_id")]
    public int odomId { get; set; }

    [JsonProperty("time")]
    public int time { get; set; }

    [JsonProperty("location")]
    public List<float> location { get; set; }

    [JsonProperty("orientation")]
    public List<float> orientation { get; set; }

    [JsonProperty("linearvelocity")]
    public float linearVelocity { get; set; }

    [JsonProperty("angularvelocity")]
    public float angularVelocity { get; set; }

    public RoboUpdate()
    {
        odomId = -1;
        time = 0;
        location = new List<float>();
        orientation = new List<float>();
        linearVelocity = 0.0f;
        angularVelocity = 0.0f;
    }

    public void Log()
    {
        // print the contents of the map update to the console
        Debug.Log(string.Format("Value of \"odom_id\" in jsonObj = {0}", this.odomId));
        Debug.Log(string.Format("Value of \"time\" in jsonObj = {0}", this.time));
        Debug.Log(string.Format("Value of \"location\" in jsonObj = {0}", string.Format("[{0}]", string.Join(",",
            this.location.Select(l => l.ToString())))));
        Debug.Log(string.Format("Value of \"orientation\" in jsonObj = {0}", string.Format("[{0}]", string.Join(",",
            this.orientation.Select(l => l.ToString())))));
        Debug.Log(string.Format("Value of \"linearvelocity\" in jsonObj = {0}", this.linearVelocity));
        Debug.Log(string.Format("Value of \"angularvelocity\" in jsonObj = {0}", this.angularVelocity));
    }

    public static bool Validate(RoboUpdate odom)
    {
        return (odom.odomId != -1) && (odom.time != 0) &&
            (odom.location.Count != 0) && (odom.orientation.Count != 0) &&
            (odom.linearVelocity != 0.0f) && (odom.angularVelocity != 0.0f);
    }
}

