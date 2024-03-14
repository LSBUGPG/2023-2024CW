# Day Night Cycle Unity Tutorial

This tutorial shows how to create an easily expandable day night cycle system in Unity.

## 1. Setup

First create an empty gameobject and call it `TimeController`, create a script on this object and call it the same.

Next create 2 directional lights, 1 to act as sunlight and the other moonlight.

Now open the lighting tab and set the active sun an your sunlight directional light.

Then create a TMPro object to act as the display for the clock and position to your liking.

## 2. Day Night Cycle Script

Open your `TimeController` script.

### Refrences

#### Public Variables

```.cs
    public float timeMultiplier;
    public float startHour;
    public TextMeshProUGUI timeText;
    public Light sunLight;
    public float sunriseHour;
    public float sunsetHour;
    public Color dayAmbientLight;
    public Color nightAmbientLight;
    public AnimationCurve lightChangeCurve;
    public float maxSunLightIntensity;
    public Light moonLight;
    public float maxMoonLightIntensity;
```

These variables control the basic functionality of the script

#### Private Variables

```.cs
    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;
```

These variables keep track of data we need in the backend

### Start Function

```.cs
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }
```

We just start at the time that we specify, taking out the `+ TimeSpan.FromHours(startHour)` will start the game under the current time.

### Update Function

```.cs
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }
```

Here we just call the functions `UpdateTimeOfDay()`, `RotateSun()` and `UpdateLightSettings()`.

### UpdateTimeOfDay Function

```.cs
    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }
```

Here we just add to out current time by `Time.deltaTime`, this increments by realtime.

By adding the `* timeMultiplier`, this lets us speed up time to our liking.

### RotateSun Function

```.cs
    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }
```

Here we calculate the required rotaion of the sun dependent on the time.

We call the function `CalculateTimeDifference()` to get a max and min value for time and then apply this to the rotaion.

### UpdateLightSettings Function

```.cs
    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
```

Here we apply the correct values for light intensity dependent on time and a user specified light curve.

### CalculateTimeDifference Function

```.cs
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
```

Here we just calculate the time difference from `fromTime` and `toTime` which are given by the sunrise and sunset times.

We then just return the difference between the 2 times.

## 3. Finish Setup In Unity

Change the values of the script to your liking and make sure you assign the correct objects to the correct variables.

Now hit play and make sure you have no errors.