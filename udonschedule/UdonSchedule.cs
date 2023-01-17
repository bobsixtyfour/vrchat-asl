
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;

namespace Bob64
{


public class UdonSchedule : UdonSharpBehaviour
{
    public float Timer = 1.0f;
    private float CurrentTimer = 0;
    string[][] events;
    TextMeshProUGUI currenttimetext;
    void Start()
    {
        currenttimetext = GameObject.Find("/Schedule/TopRightPanel/Current Time").GetComponent<TextMeshProUGUI>();
        events =
            new string[][]{//all times must be in UTC. Will auto-adjust to end-user system settings.
                           //date in utc, repeating (Y/N), lang short, classname, Location, teacher 
                //Monday
                new string[]{"01/09/2023 08:00PM","Y", "ASL No Voice Zone", "Event:\nASL No Voice Zone", "Quest Compatible","kw856"},
                //new string[]{"01/05/2023 07:00PM", "Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "MrRikuG935"},

                //Tuesday
                new string[]{"01/10/2023 07:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Ray_is_Deaf"},
                new string[]{"01/10/2023 08:00PM","Y", "KSL Class", "Language Class:\nKSL (Korean Sign Language)", "Quest Compatible", "Korea_Yujin"},
                /*
                new string[]{"01/10/2023 09:00PM","Y", "BSL Class", "Language Class:\nBSL (British Sign Language)", "Quest Compatible", "AvinouSCAC"},
                new string[]{"01/10/2023 11:00PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},*/

                //Wednesday
                //new string[]{"01/11/2023 07:00PM","Y", "BSL Class", "Language Class:\nBSL (British Sign Language)", "Quest Compatible", "TachDeafGamer"},
                new string[]{"01/11/2023 09:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "jenny0629 "},
                new string[]{"01/11/2023 10:00PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                new string[]{"01/11/2023 11:30PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "PC Only","DmTheMechanic"},

                //Thursday
                new string[]{"01/12/2023 12:00PM","Y", "JSL Class", "Language Class:\nJSL (Japanese Sign Language)", "Quest Compatible", "RafaelDeaf"},
                new string[]{"01/12/2023 09:00PM","Y", "BSL Class", "Language Class:\nBSL (British Sign Language)", "Quest Compatible", "Sheezy93 & AvinouSCAC"},
                //new string[]{"01/12/2023 10:00PM","Y", "KSL Class", "Language Class:\nKSL (Korean Sign Language)", "Quest Compatible", "Korea_Yujin"},
                

                //Friday
                new string[]{"01/13/2023 02:00AM","Y", "ASL No Voice Zone", "Event:\nASL No Voice Zone", "Quest Compatible", "ShadeAxas"},
                new string[]{"01/13/2023 08:00PM","Y", "DGS Class", "Language Class:\nDGS (German Sign Language)", "Quest Compatible", "deaf_danielo_89"},
                new string[]{"01/13/2023 08:00PM","Y", "KSL No Voice Zone", "Event:\nKSL No Voice Zone", "Quest Compatible", "Korea_Yujin"},
                new string[]{"01/13/2023 09:30PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                
                
                //Saturday
                //new string[]{"01/14/2023 01:00AM","Y", "BSL Class", "Language Class:\nBSL (British Sign Language)", "Quest Compatible", "Sheezy93 & AvinouSCAC"},
                //new string[]{"01/14/2023 05:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Jenny0629"},
                
                //new string[]{"01/14/2023 07:00PM","Y", "BSL Class", "Language Class:\nBSL (British Sign Language)", "Quest Compatible", "TachDeafGamer"},
                //new string[]{"01/14/2023 08:00PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "xKaijo"},
                //new string[]{"01/14/2023 09:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Deaf_Otaku"},
                new string[]{"01/14/2023 09:00PM","Y", "LSF No Voice Zone", "Event:\nLSF No Voice Zone", "Quest Compatible", "xKaijo"},
                new string[]{"01/14/2023 10:00PM","Y", "BSL No Voice Zone", "Event:\nBSL No Voice Zone", "Quest Compatible", "AvinouSCAC"},
                

                
                //Sunday
                new string[]{"01/15/2023 01:00AM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Jenny0629"},
                new string[]{"01/15/2023 08:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Crow_Se7en"},
                new string[]{"01/15/2023 09:00PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                //new string[]{"01/15/2023 01:00AM","Y", "JSL Class", "Language Class:\nJSL (Japanese Sign Language)", "Quest Compatible", "RafaelDeaf"},
                new string[]{"01/15/2023 10:00PM","Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Starbun"},
//                new string[]{"01/15/2023 10:00PM","Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                //new string[]{"01/15/2023 04:00AM","N", "HH Festival", "Special Event:\nHelping Hands Festival - Trance, Dance, and EDM", "PC Only", "DecentM, ShadeAxas, FearlessKoolaid, CODApop" }
                
        };


        events = _FuturiseArray(events);
        events = _SortArray(events);
        _DisplaySchedule(events);
        //disable unneeded events
        /*
        for (int x = events.Length; x < 20; x++)
        {
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event" + x).SetActive(false);
        }
        */
    }

        /***************************************************************************************************************************
        Displays the right hand schedule, line by line. Incomplete
        ***************************************************************************************************************************/
        private string[][] _RemoveArrayIndex(string[][] eventsstring, int indextoremove)
        {
            return eventsstring;
        }

        /***************************************************************************************************************************
        Update loop
        ***************************************************************************************************************************/
        void FixedUpdate()
    {
        if (CurrentTimer == 0)
        {
            //currenttimetext.text="Current Time: "+ DateTime.Now.ToString("t");
            //currenttimetext.text = "Current Time: " + DateTime.Now.Hour%12+":"+DateTime.Now.Minute+" "+ DateTime.Now.ToString("tt");
            currenttimetext.text = "Current Time: " + DateTime.Now.ToString("h:mm tt");
            TimeSpan span = DateTime.Parse(events[0][0]) - DateTime.UtcNow;

            if (span.TotalMinutes < -30) //if 30 minutes have passed from the top event
            {
                //Debug.Log(span.TotalMinutes+" minutes have passed in update");
                events = _FuturiseArray(events);
                events = _SortArray(events);
                _DisplaySchedule(events);

            }
#if UNITY_ANDROID//fix for quest headsets being off by 1 hour?
            _DisplayUpcomingEvent(DateTime.Parse(events[0][0]).Add(DateTime.Now - DateTime.UtcNow).AddHours(1), events[0][3], events[0][4], events[0][5]);
#else
                _DisplayUpcomingEvent(DateTime.Parse(events[0][0]).Add(DateTime.Now - DateTime.UtcNow), events[0][3], events[0][4], events[0][5]);
#endif
            CurrentTimer = Timer; // Resets the timer
        }
        else
        {
            CurrentTimer = Mathf.MoveTowards(CurrentTimer, 0, Timer * Time.deltaTime);
        }
    }

        /***************************************************************************************************************************
        pad any old dates with future dates.
        ***************************************************************************************************************************/

        string[][] _FuturiseArray(string[][] tempkeys)
        {
            //debug:
            /*
            foreach (string[] value in tempkeys)
            {
                Debug.Log(value[0]);
            }*/

            foreach (string[] value in tempkeys)
            {
                if (value[1] == "Y")//If repeating is Y, futurize, otherwise do nothing.
                {
                    DateTime temp = DateTime.Parse(value[0]);
                    TimeSpan span;
                    if (DateTime.Compare(DateTime.UtcNow, temp) > 0)//if the time is in the future already, skip?
                    {

                        span = DateTime.UtcNow - temp;
                        //Debug.Log("days added: " + (span.Days / 7 + 1) * 7);
                        value[0] = temp.AddDays((span.Days / 7 + 1) * 7).ToString();
                        //Debug.Log("FuturizeArray - Before: " + temp + " Futurized time: " + value[0].ToString());
                    }
                }
            }
            return tempkeys;
        }

        /***************************************************************************************************************************
        take in array and sort it.
        ***************************************************************************************************************************/

        private string[][] _SortArray(string[][] tempkeys)
    {
        string[][] temp = new string[1][];
        for (int i = 0; i < tempkeys.Length - 1; i++)
        {
            // traverse i+1 to array length
            for (int j = i + 1; j < tempkeys.Length; j++)
            {
                // compare array element with 
                // all next element
                //Debug.Log("Comparing: " +tempkeys[i][0] + " (index #" + i + ") and " + tempkeys[j][0] + " (index #"+j+") compare result: " + DateTime.Compare(DateTime.Parse(tempkeys[i][0]), DateTime.Parse(tempkeys[j][0])));
                if (DateTime.Compare(DateTime.Parse(tempkeys[i][0]), DateTime.Parse(tempkeys[j][0])) > 0)
                {
                    //Debug.Log(tempkeys[i][0] + " is greater than " + tempkeys[j][0]); 
                    temp[0] = tempkeys[i];
                    tempkeys[i] = tempkeys[j];
                    tempkeys[j] = temp[0];
                }
            }
        }

        return tempkeys;
    }

        private void _DisplaySchedule(string[][] tempkeys)
        {

            // print all element of array
            int counter = 0;
            foreach (string[] value in tempkeys)
            {
                //Debug.Log("comparing value:"+value[0]+"compare result:"+DateTime.Compare(DateTime.UtcNow, DateTime.Parse(value[0])));
                if (DateTime.Compare(DateTime.UtcNow, DateTime.Parse(value[0])) < 0)//utcnow is earlier than the date, don't display if the event is in the past.
                {
                    GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter +")").SetActive(true);
#if UNITY_ANDROID//fix for quest headsets being off by 1 hour?
                        _DisplayScheduleLine(DateTime.Parse(value[0]).Add(DateTime.Now - DateTime.UtcNow).AddHours(1), value[2], value[4], value[5], counter);
#else
                    _DisplayScheduleLine(DateTime.Parse(value[0]).Add(DateTime.Now - DateTime.UtcNow), value[2], value[4], value[5], counter);
                    #endif

                    counter++;
                }
            }

            //disable unneeded events
            for (counter = events.Length; counter < 20; counter++)
            {
                GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter + ")").SetActive(false);
            }
        }

        private void _DisplayUpcomingEvent(DateTime tempdate, String eventlongname, String world, String teachers)
    {
        TimeSpan interval = tempdate - DateTime.Now;
        TextMeshProUGUI upcomingtext = GameObject.Find("/Schedule/InfoPanel/NoworUpcoming").GetComponent<TextMeshProUGUI>();
        //Debug.Log("tempdate:"+tempdate.ToString());
        //Debug.Log("current time:" + DateTime.Now.ToString());
        //Debug.Log("interval: " + interval.Days + " days, " + interval.Hours + " hours, " + interval.Minutes + " minutes, " + interval.Seconds + " seconds");
        upcomingtext.text = interval.Days + "d, " + interval.Hours + "h, " + interval.Minutes + "m, " + interval.Seconds + "s";
        string days = "";
        string hours = "";
        string minutes = "";
        string seconds = "";
        if (interval.Days > 1)
        {
            days = interval.Days + " Days";
        }
        else if (interval.Days == 1)
        {
            days = interval.Days + " Day";
        }

        if (interval.Hours > 1)
        {
            hours = interval.Hours + " Hours";
        }
        else if (interval.Hours == 1)
        {
            hours = interval.Hours + " Hour";
        }


        if (interval.Minutes > 1)
        {
            minutes = interval.Minutes + " Minutes";
        }
        else if (interval.Minutes == 1)
        {
            minutes = interval.Minutes + " Minute";
        }

        if (interval.Seconds > 1)
        {
            seconds = interval.Seconds + " Seconds";
        }
        else if (interval.Seconds == 1)
        {
            seconds = interval.Seconds + " Second";
        }
        else if (interval.Seconds == 0)
        {
            seconds = interval.Seconds + " Second";
        }
        else if (interval.Seconds == -1)
        {
            seconds = interval.Seconds + " Second Ago";
        }
        else if (interval.Seconds < -1)
        {
            seconds = interval.Seconds * -1 + " Seconds Ago";
        }

        if (interval.TotalDays >= 1)
        {
            upcomingtext.text = "Next Event:\n" + days;
            if (hours != "")
            {
                upcomingtext.text = upcomingtext.text + " & ";
            }
            upcomingtext.text = upcomingtext.text + hours;
        }

        if (interval.TotalHours >= 1 & interval.TotalHours < 24)
        {
            upcomingtext.text = "Next Event:\n" + hours;
            if (minutes != "")
            {
                upcomingtext.text = upcomingtext.text + " & ";
            }
            upcomingtext.text = upcomingtext.text + minutes;
        }

        if (interval.TotalMinutes >= 1 & interval.TotalMinutes < 60)
        {
            upcomingtext.text = "Starting Soon:\n" + minutes;
            if (seconds != "")
            {
                upcomingtext.text = upcomingtext.text + " & ";
            }
            upcomingtext.text = upcomingtext.text + seconds;
        }
        if (interval.TotalSeconds >= 1 & interval.TotalSeconds < 60)
        {
            upcomingtext.text = "Starting Now:\n" + seconds;
        }
        if (interval.TotalSeconds < 0 & interval.TotalSeconds >= -60)
        {
            upcomingtext.text = "Just Started:\n" + seconds;
        }
        if (interval.TotalSeconds < -60 & interval.TotalSeconds >= -1800)
        {
            upcomingtext.text = "Just Started:\n" + Convert.ToInt16(interval.TotalMinutes * -1) + " Minutes Ago";
        }


        GameObject.Find("/Schedule/InfoPanel/EventName").GetComponent<TextMeshProUGUI>().text = eventlongname;
        GameObject.Find("/Schedule/InfoPanel/LocationText").GetComponent<TextMeshProUGUI>().text = "Location:\n" + world;
        GameObject.Find("/Schedule/InfoPanel/HostText").GetComponent<TextMeshProUGUI>().text = "Hosted by:\n" + teachers;

    }

        /*private string _ExpandShortLang2Short(String shortlang)
        {
            String eventshortname;
            //convert shortlang/world to long
            switch (shortlang)
            {
                case "ASL":
                    eventshortname = "ASL Class";
                    break;
                case "ASL-NVZ":
                    eventshortname = "ASL No Voice Zone";
                    break;
                case "BSL":
                    eventshortname = "BSL Class";
                    break;
                case "BSL-NVZ":
                    eventshortname = "BSL No Voice Zone";
                    break;
                case "DGS":
                    eventshortname = "DGS Class";
                    break;
                case "DGS-NVZ":
                    eventshortname = "DGS No Voice Zone";
                    break;
                case "KSL":
                    eventshortname = "KSL Class";
                    break;
                case "KSL-NVZ":
                    eventshortname = "KSL Social";
                    break;
                case "LSF":
                    eventshortname = "LSF Class";
                    break;
                case "LSF-NVZ":
                    eventshortname = "LSF No Voice Zone";
                    break;
                case "VRCON-DCP":
                    eventshortname = "VRCON Panel";
                    break;
                case "VRCON-INTRO":
                    eventshortname = "VRCON Panel";
                    break;

                default:
                    eventshortname = "Error:\n" + shortlang + " is undefined. Contact Bob64";
                    break;
            }
            return eventshortname;
        }

        private string _ExpandShortLang2Long(String shortlang)
        {
            String eventlongname;
            //convert shortlang/world to long
            switch (shortlang)
            {
                case "ASL":
                    eventlongname = "Language Class:\nASL (American Sign Language)";
                    break;
                case "ASL-NVZ":
                    eventlongname = "Event:\nASL No Voice Zone";
                    break;
                case "BSL":
                    eventlongname = "Language Class:\nBSL (British Sign Language)";
                    break;
                case "BSL-NVZ":
                    eventlongname = "Event:\nBSL No Voice Zone";
                    break;
                case "DGS":
                    eventlongname = "Language Class:\nDGS (German Sign Language)";
                    break;
                case "DGS-NVZ":
                    eventlongname = "Event:\nDGS No Voice Zone";
                    break;
                case "KSL":
                    eventlongname = "Language Class:\nKSL (Korean Sign Language)";
                    break;
                case "KSL-NVZ":
                    eventlongname = "Event:\nKSL No Voice Zone";
                    break;
                case "LSF":
                    eventlongname = "Language Class:\nLSF (French Sign Language)";
                    break;
                case "LSF-NVZ":
                    eventlongname = "Event:\nLSF No Voice Zone";
                    break;
                case "VRCON-DCP":
                    eventlongname = "VRCON Panel: \nLearn the Dos and Don'ts of \nDeaf culture!";
                    break;
                case "VRCON-INTRO":
                    eventlongname = "VRCON Panel: \nWe will hold a class with different \nteachers to show bits and pieces of their language.";
                    break;
                default:
                    eventlongname = "Error:\n" + shortlang + " is undefined. Contact Bob64";
                    break;
            }
            return eventlongname;
        }
           
        private string _ExpandShortWorld2Long(String shortworld)
    {
        string world;
        switch (shortworld)
        {
            case "EAW":
                world = "Quest Compatible";
                break;
            case "MRD":
                world = "Quest Compatible";
                break;
            case "MRDCS":
                world = "Quest Compatible";
                break;
            case "HHHQ":
                world = "Quest Compatible";
                break;
            case "SHH":
                world = "PC Only";
                break;
            case "GHH":
                world = "Quest Compatible";
                break;
            case "VRCON":
                world = "Quest Compatible";
                break;
            default:
                world = "Error:\n" + shortworld + " is undefined. Contact Bob64";
                break;
        }
        return world;
    }
    */
        /***************************************************************************************************************************
        Displays the right hand schedule, line by line.
        ***************************************************************************************************************************/
        private void _DisplayScheduleLine(DateTime tempdate, String eventshortname, String world, String teachers, int counter)
        {
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter + ")/Box1").GetComponent<TextMeshProUGUI>().text = tempdate.ToString("dddd") + "\n" + tempdate.ToString("h tt");
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter + ")/Box2").GetComponent<TextMeshProUGUI>().text = tempdate.ToString("d");
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter + ")/Box3").GetComponent<TextMeshProUGUI>().text = eventshortname;
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event (" + counter + ")/Box4").GetComponent<TextMeshProUGUI>().text = "Hosted by: " + teachers;
        }
    }
}
