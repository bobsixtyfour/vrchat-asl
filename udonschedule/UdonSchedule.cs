
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.SDK3.StringLoading;
using System;
using TMPro;
using VRC.SDK3.Data;
using VRC.Udon.Common.Interfaces;

namespace Bob64.UdonSchedule
{


    public class UdonSchedule : UdonSharpBehaviour
    {
        public float Timer = 1.0f;
        private float CurrentTimer = 0;
        string[][] fallbackevents;
        string[][] jsonevents;
        string[][] events;
        TextMeshProUGUI currenttimetext;

        string eventsjsonStr = "";
        DataToken datatokenevents;
        VRCUrl jsoneventsurl = new VRCUrl("https://vrsl.withdevon.xyz/api/v2/week_events");


        void Start()
        {
            VRCStringDownloader.LoadUrl(jsoneventsurl, (IUdonEventReceiver)this);
            //VRCStringDownloader.LoadUrl(jsoneventsurl);
            currenttimetext = gameObject.transform.Find("TopRightPanel/Current Time").GetComponent<TextMeshProUGUI>();

            events =
                new string[][]{//all datetimes must be in unixtimestamp. Will auto-adjust to end-user system settings.
                           //date in utc, repeating (Y/N), lang short, classname, Location, teacher 
                //Monday
                new string[]{ "1683576000", "Y", "ASL No Voice Zone", "Event:\nASL No Voice Zone", "Quest Compatible","kw856"},

                //Tuesday
                new string[]{ "1683655200", "Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Ray_is_Deaf"},
                new string[]{ "1683662400", "Y", "KSL Class", "Language Class:\nKSL (Korean Sign Language)", "Quest Compatible", "Simulacre & Korea_Yujin"},
                
                //Wednesday
                new string[]{ "1683723600", "Y", "KSL Class", "Language Class:\nKSL (Korean Sign Language)", "Quest Compatible", "Simulacre"},
                new string[]{ "1683747000", "Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                new string[]{ "1683806400", "Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "PC Only","DmTheMechanic"},
           
                //Thursday
                new string[]{ "1683853200", "Y", "JSL Class", "Language Class:\nJSL (Japanese Sign Language)", "Quest Compatible", "RafaelDeaf"},

                //Friday
                new string[]{ "1683923400", "Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},
                new string[]{ "1683926100", "Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "PC Only","Wardragon"},
                
                //Saturday
                new string[]{ "1684008000", "Y", "DGS Class", "Language Class:\nDGS (German Sign Language)", "Quest Compatible", "deaf_danielo_89"},
                new string[]{ "1684008000", "Y", "LSF No Voice Zone", "Event:\nLSF No Voice Zone", "Quest Compatible", "xKaijo"},

                //Sunday
                new string[]{ "1684090800", "Y", "ASL Class", "Language Class:\nASL (American Sign Language)", "Quest Compatible", "Crow_Se7en"},
                new string[]{ "1684094400", "Y", "KSL Class", "Language Class:\nKSL (Korean Sign Language)", "Quest Compatible", "Simulacre"},
                new string[]{ "1684096200", "Y", "LSF Class", "Language Class:\nLSF (French Sign Language)", "Quest Compatible", "Getomeulou"},

                };


            events = _FuturiseArray(events);
            events = _SortArray(events);
            _DisplaySchedule(events);
            //disable unneeded events
            /*
            for (int x = events.Length; x < 20; x++)
            {
                scheduleroot.transform.Find("UpcomingPanel/Content/Event" + x).SetActive(false);
            }
            */
        }

        //called when string loading is successful.
        public override void OnStringLoadSuccess(IVRCStringDownload result)
        {
            Debug.Log("String Loaded");

            eventsjsonStr = result.Result;
            if (VRCJson.TryDeserializeFromJson(eventsjsonStr, out datatokenevents))
            {
                //Debug.Log("Json deserialized");

                //Deserialization succeeded! Let's figure out what we got.
                if (datatokenevents.TokenType == TokenType.DataDictionary)
                {
                    //Debug.Log(message: $"Successfully deserialized as a dictionary with {datatokenevents.DataDictionary.Count} count");
                }

                else if (datatokenevents.TokenType == TokenType.DataList)
                {
                    //Debug.Log(message: $"Successfully deserialized as a list with {datatokenevents.DataList.Count} count");
                    jsonevents = new string[datatokenevents.DataList.Count][]; //Declare jagged array

                    for (int i = 0; i < datatokenevents.DataList.Count; i++)
                    {
                        DataToken temptoken;
                        if (datatokenevents.DataList.TryGetValue(i, out temptoken))
                        {
                            string timestamp = temptoken.DataDictionary[(DataToken)"timestamp"].String;
                            string language = temptoken.DataDictionary[(DataToken)"language"].String;
                            string presenter = temptoken.DataDictionary[(DataToken)"presenter"].String;
                            
                            string location = temptoken.DataDictionary[(DataToken)"location"].String;
                            

                            //Debug.Log(message: $"From element {i}, got values for: language: {language}, presenter: {presenter}, timestamp: {UnixTimeToUtc(long.Parse(timestamp)/1000).ToString("g")}");
                            jsonevents[i]=new string[] { (long.Parse(timestamp)/1000).ToString(),"Y", _ConvertJsonLang2Short(language), _ConvertJsonLang2Long(language), location, presenter };

                                /*
                                Debug.Log(message: $"Successfully got value from element {i}: {temptoken}");
                                //Debug.Log(temptoken["language"].String);
                                temptoken.DataDictionary.TryGetValue((DataToken)"language", out DataToken value);
                                Debug.Log(message: $"Successfully got language value: {value.String}");*/
                        }
                        else
                        {
                            Debug.Log(message: $"Failed to get value from element {i}.");
                        }
                    }
                    events = jsonevents;
                    events = _FuturiseArray(events); //in the off-chance that the json has dates that have already passed.
                    events = _SortArray(events); //in the off-chance that the json has dates out-of-order.
                    _DisplaySchedule(events);


                }
                else
                {
                    //This should not be possible. If DeserializeFromJson returns true, then it *must* be either a dictionary or a list
                }



            }
            else //failed to deserialize, fallback to hardcoded events
            {
                Debug.Log(message: $"Failed to Deserialize json {eventsjsonStr} - {datatokenevents.ToString()}");
                Debug.Log("Json failed to deserialized");
                events = fallbackevents;
            }
        }

        public override void OnStringLoadError(IVRCStringDownload result)
        {
            Debug.Log("String Failed to load");

            events = fallbackevents;
            //Label.text = result.Result;
            //Label.text = result.Error;
        }

        public static DateTime UnixTimeToUtc(long unixTime)
        {

            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);

            ///DateTime utcDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
        }

        public static long ToUnixDateTime(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
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
                DateTime temp = UnixTimeToUtc(long.Parse(events[0][0]));
                TimeSpan span = temp - DateTime.UtcNow;

                if (span.TotalMinutes < -30) //if 30 minutes have passed from the top event
                {
                    //Debug.Log(span.TotalMinutes+" minutes have passed in update");
                    events = _FuturiseArray(events);
                    events = _SortArray(events);
                    _DisplaySchedule(events);

                }
            #if UNITY_ANDROID//fix for quest headsets being off by 1 hour
                        _DisplayUpcomingEvent(temp.Add(DateTime.Now - DateTime.UtcNow).AddHours(1), events[0][3], events[0][4], events[0][5]);
#else
                            _DisplayUpcomingEvent(temp.Add(DateTime.Now - DateTime.UtcNow), events[0][3], events[0][4], events[0][5]);
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
                    DateTime temp = UnixTimeToUtc(long.Parse(value[0]));
                    TimeSpan span;
                    //Debug.Log("Current UTC Time:" + DateTime.UtcNow + " event time: " + temp.ToString());
                    if (DateTime.Compare(DateTime.UtcNow, temp) > 0)//if the time is in the future already, skip?
                    {
                        span = DateTime.UtcNow - temp;
                        //Debug.Log("Span: "+ span.Days.ToString() + " days added: " + (span.Days / 7 + 1) * 7);
                        //Debug.Log("Date after adding days" + temp.AddDays((span.Days / 7 + 1) * 7).ToString());
                        value[0] = ToUnixDateTime(temp.AddDays((span.Days / 7 + 1) * 7)).ToString();
                        //Debug.Log("FuturizeArray - Before: " + temp + " Futurized time: " + UnixTimeToUtc(long.Parse(value[0])).ToString());
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
                    if(long.Parse(tempkeys[i][0]) > long.Parse(tempkeys[j][0]) )
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
                DateTime temp = UnixTimeToUtc(long.Parse(value[0]));
                if (DateTime.Compare(DateTime.UtcNow, temp) < 0)//utcnow is earlier than the date, don't display if the event is in the past.
                {
                    gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")").gameObject.SetActive(true);
#if UNITY_ANDROID//fix for quest headsets being off by 1 hour?
                        _DisplayScheduleLine(temp.Add(DateTime.Now - DateTime.UtcNow).AddHours(1), value[2], value[4], value[5], counter);
#else
                    _DisplayScheduleLine(temp.Add(DateTime.Now - DateTime.UtcNow), value[2], value[4], value[5], counter);
#endif

                    counter++;
                }
            }
            //Debug.Log("Events.Length: "+events.Length);
            //disable unneeded events
            for (counter = events.Length; counter < 25; counter++)
            {
                gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")").gameObject.SetActive(false);
            }
        }

        private void _DisplayUpcomingEvent(DateTime tempdate, String eventlongname, String world, String teachers)
        {
            TimeSpan interval = tempdate - DateTime.Now;
            TextMeshProUGUI upcomingtext = gameObject.transform.Find("InfoPanel/NoworUpcoming").GetComponent<TextMeshProUGUI>();
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


            gameObject.transform.Find("InfoPanel/EventName").GetComponent<TextMeshProUGUI>().text = eventlongname;
            gameObject.transform.Find("InfoPanel/LocationText").GetComponent<TextMeshProUGUI>().text = "Location:\n" + world;
            gameObject.transform.Find("InfoPanel/HostText").GetComponent<TextMeshProUGUI>().text = "Hosted by:\n" + teachers;

        }

        private string _ConvertJsonLang2Short(String shortlang)
        {
            String eventshortname;
            //convert shortlang/world to long
            switch (shortlang)
            {
                case "ASL":
                    eventshortname = "ASL Class";
                    break;
                case "BSL":
                    eventshortname = "BSL Class";
                    break;
                case "DGS":
                    eventshortname = "DGS Class";
                    break;
                case "KSL":
                    eventshortname = "KSL Class";
                    break;
                case "LSF":
                    eventshortname = "LSF Class";
                    break;
                case "JSL":
                    eventshortname = "JSL Class";
                    break;
                default:
                    eventshortname = shortlang;
                    break;
            }
            return eventshortname;
        }

        private string _ConvertJsonLang2Long(String shortlang)
        {
            String eventlongname;
            //converts the json language to a more descriptive form
            switch (shortlang)
            {
                case "ASL":
                    eventlongname = "Language Class:\nASL (American Sign Language)";
                    break;
                case "ASL No Voice Zone":
                    eventlongname = "Event:\nASL No Voice Zone";
                    break;
                case "BSL":
                    eventlongname = "Language Class:\nBSL (British Sign Language)";
                    break;
                case "BSL No Voice Zone":
                    eventlongname = "Event:\nBSL No Voice Zone";
                    break;
                case "DGS":
                    eventlongname = "Language Class:\nDGS (German Sign Language)";
                    break;
                case "DGS No Voice Zone":
                    eventlongname = "Event:\nDGS No Voice Zone";
                    break;
                case "KSL":
                    eventlongname = "Language Class:\nKSL (Korean Sign Language)";
                    break;
                case "KSL No Voice Zone":
                    eventlongname = "Event:\nKSL No Voice Zone";
                    break;
                case "LSF":
                    eventlongname = "Language Class:\nLSF (French Sign Language)";
                    break;
                case "LSF No Voice Zone":
                    eventlongname = "Event:\nLSF No Voice Zone";
                    break;
                case "JSL":
                    eventlongname = "Language Class:\nJSL (Japanese Sign Language)";
                    break;
                case "JSL No Voice Zone":
                    eventlongname = "Event:\nJSL No Voice Zone";
                    break;

                default://fallback to whatever the input string is
                    eventlongname = shortlang;
                    break;
            }
            return eventlongname;
        }
           
        //not used anywhere at the moment. Was used to potentially determine quest compatibility.
        private string _ExpandShortWorld2Long(String shortworld)
    {
        string world;
        switch (shortworld)
        {
            case "Experimental Sign Language World":
                world = "Quest Compatible";
                break;
            case "MrDummy's Sign and Fun":
                world = "Quest Compatible";
                break;
            case "MrDummy's Club School":
                world = "Quest Compatible";
                break;
            case "Helping Hands HQ":
                world = "Quest Compatible";
                break;
            case "School Helping Hands":
                world = "Quest Compatible";
                break;
            case "Global Helping Hands":
                world = "Quest Compatible";
                break;
            case "Zade's ASL & JSL World":
                world = "Quest Compatible";
                break;
            default: //fallback to whatever the input string is
                world = shortworld;
                break;
        }
        return world;
    }

        /***************************************************************************************************************************
        Displays the right hand schedule, line by line.
        ***************************************************************************************************************************/
        private void _DisplayScheduleLine(DateTime tempdate, String eventshortname, String world, String teachers, int counter)
        {
            gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")/Box1").GetComponent<TextMeshProUGUI>().text = tempdate.ToString("dddd") + "\n" + tempdate.ToString("h tt");
            gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")/Box2").GetComponent<TextMeshProUGUI>().text = tempdate.ToString("d");
            gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")/Box3").GetComponent<TextMeshProUGUI>().text = eventshortname;
            gameObject.transform.Find("UpcomingPanel/Content/Event (" + counter + ")/Box4").GetComponent<TextMeshProUGUI>().text = "Hosted by: " + teachers;
        }
    }


}