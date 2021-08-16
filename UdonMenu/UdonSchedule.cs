
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;

public class UdonSchedule : UdonSharpBehaviour
{
    public float Timer = 1.0f;
    private float CurrentTimer = 0;
    string[][] keys;
    TextMeshProUGUI currenttimetext;
    void Start()
    {
        currenttimetext = GameObject.Find("/Schedule/UpcomingPanel/Content/Current Time").GetComponent<TextMeshProUGUI>();
        keys = new string[][]{//all times must be in UTC. Will auto-adjust to end-user system settings.
            new string[]{"08/09/2021 07:00PM","LSF","MRD","Roineru_FR, MrRikuG935,\nMaxDeaf_FR"},
            new string[]{"08/10/2021 06:00PM","ASL","MRD","Ray_is_Deaf"},
            new string[]{"08/11/2021 06:00PM","DGS","MRD","deaf_danielo_89"},
            new string[]{"08/11/2021 07:00PM","DGS-C","HHHQ","deaf_danielo_89"},
            new string[]{"08/11/2021 10:00PM","ASL","MRDCS","DmTheMechanic"},
            new string[]{"08/12/2021 07:00PM","BSL","GHH","CathDeafGamer"},
            new string[]{"08/13/2021 08:00PM","ASL","MRD","Wardragon"},
            new string[]{"08/14/2021 12:00AM","BSL","GHH","CathDeafGamer"},
            new string[]{"08/14/2021 07:00PM","BSL","GHH","CathDeafGamer"},
            new string[]{"08/14/2021 08:00PM","LSF-C","HHHQ","Roineru_FR"},
            new string[]{"08/14/2021 09:00PM","BSL-C","HHHQ","CathDeafGamer"},
            new string[]{"08/15/2021 12:00AM","ASL","HHHQ","Jenny0629"},
            new string[]{"08/15/2021 07:00PM","ASL","SHH","Crow_Se7en"},
            new string[]{"08/15/2021 08:00PM","LSF","MRD","hppedeaf"},
        };


        keys = FuturiseArray(keys);
        keys = SortArray(keys);
for(int x=keys.Length;x<20; x++)//disable unneeded events
        {
            GameObject.Find("/Schedule/UpcomingPanel/Content/Event" + x).SetActive(false);
        }
        
        //scheduletextboard.text = "test";

    }

    void FixedUpdate()
    {
        if (CurrentTimer == 0)
        {
            currenttimetext.text="Current Time: "+ DateTime.Now.ToString("t");
            TimeSpan span = DateTime.Now - DateTime.Parse(keys[0][0]);
            if (span.TotalMinutes > -30 & span.TotalMinutes < 0)
            {
                keys = FuturiseArray(keys);
                keys = SortArray(keys);
            }

            CurrentTimer = Timer; // Resets the timer
        }
        else
        {
            CurrentTimer = Mathf.MoveTowards(CurrentTimer, 0, Timer * Time.deltaTime);
        }
    }

    //pad any old dates with future dates.
    string[][] FuturiseArray(string[][] tempkeys)
    {
        foreach (string[] value in tempkeys)
        {
            DateTime temp = DateTime.Parse(value[0]);
            if (DateTime.Now > temp)//if the time is in the future already, skip?
            {
                //Debug.Log("Time: " + temputcdate.ToString("f"));
                //Debug.Log("days added: " + (span.Days / 7 + 1) * 7);
                
                TimeSpan span = DateTime.Now - temp;
                value[0] = temp.AddDays((span.Days / 7 + 1) * 7).ToString();
                //Debug.Log("FuturizeArray - Before: "+temp+" Futurized time: " + value[0].ToString());
            }
        }
            return tempkeys;
    }

        //take in array and sort it.
        string[][] SortArray(string[][] tempkeys)
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
        DateTime currentdate, utcdate;
        TimeSpan difference;
        currentdate = DateTime.Now;
        utcdate = DateTime.UtcNow;
        difference = currentdate - utcdate;
        // print all element of array
        int counter = 0;
        foreach (string[] value in tempkeys)
        {
            Displaydate(DateTime.Parse(value[0]).Add(difference), value[1], value[2], value[3], counter);
            //Debug.Log("After sort: "+ value[0] + "," + value[1] + "," + value[2] + "," + value[3]);
            counter++;
        }
        return tempkeys;
    }


    //have dayofweek in main program, just display selected events here?
    void Displaydate(DateTime tempdate, String shortlang, String shortworld, String teachers, int counter)
    {
        TextMeshProUGUI daytext = GameObject.Find("/Schedule/UpcomingPanel/Content/Event"+counter+"/Day").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI eventtext = GameObject.Find("/Schedule/UpcomingPanel/Content/Event" + counter + "/EventName").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI desctext = GameObject.Find("/Schedule/UpcomingPanel/Content/Event" + counter + "/EventDetails").GetComponent<TextMeshProUGUI>();
        //scheduletextboard = GameObject.Find("/Schedule/Panel/Text (TMP)").GetComponent<TextMeshProUGUI>();
        /*
        TimeSpan span = DateTime.Now - tempdate;
        //Debug.Log("span: " + span + " span.Days:" + span.Days + " span/7*7:" + span.Days / 7*7);
        if (DateTime.Now > tempdate)//if the time is in the future already, skip?
        {
            //Debug.Log("Time: " + temputcdate.ToString("f"));
            //Debug.Log("days added: " + (span.Days / 7 + 1) * 7);
            tempdate=tempdate.AddDays((span.Days / 7 + 1) * 7);
        //Debug.Log("Time: " + temputcdate.ToString("f"));
        }*/
        //DateTime.UtcNow
        //TimeSpan span2 = DateTime.UtcNow - tempdate;
        //Debug.Log("span2: " + span2);
        //if (DateTime.Now < tempdate && span2.Days>-6) { //display if event hasn't happened yet
        
        String eventlongname;
        String eventshortname;
        String world;
        //convert shortlang/world to long
        switch (shortlang)
        {
            case "ASL":
                eventlongname = "Language Class:\nASL (American Sign Language)";
                eventshortname = "ASL Class";
                break;
            case "ASL-C":
                eventlongname = "Event:\nASL No Voice Zone";
                eventshortname = "ASL No Voice Zone";
                break;
            case "BSL":
                eventlongname = "Language Class:\nBSL (British Sign Language)";
                eventshortname = "BSL Class";
                break;
            case "BSL-C":
                eventlongname = "Event:\nBSL No Voice Zone";
                eventshortname = "BSL No Voice Zone";
                break;
            case "DGS":
                eventlongname = "Language Class:\nDGS (German Sign Language)";
                eventshortname = "DGS Class";
                break;
            case "DGS-C":
                eventlongname = "Event:\nDGS No Voice Zone";
                eventshortname = "DGS No Voice Zone";
                break;
            case "KSL":
                eventlongname = "Language Class:\nKSL (Korean Sign Language)";
                eventshortname = "KSL Class";
                break;
            case "KSL-C":
                eventlongname = "Event:\nKSL No Voice Zone";
                eventshortname = "KSL Social";
                break;
            case "LSF":
                eventlongname = "Language Class:\nLSF (French Sign Language)";
                eventshortname = "LSF Class";
                break;
            case "LSF-C":
                eventlongname = "Event:\nLSF No Voice Zone";
                eventshortname = "LSF No Voice Zone";
                break;
            default:
                eventlongname = "Error:\n" + shortlang + " is undefined. Contact Bob64";
                eventshortname = "Error:\n" + shortlang + " is undefined. Contact Bob64";
                break;
        }

        /*
        switch (shortworld)
            {
                case "EAW":
                    world = "Experimental ASL World";
                    break;
                case "MRD":
                    world = "MrDummy_NL's Sign&Fun";
                    break;
                case "MRDCS":
                    world = "MrDummy's Club School";
                    break;
                case "HHHQ":
                    world = "Helping Hands HQ";
                    break;
                case "SHH":
                    world = "School Helping Hands";
                    break;
                case "GHH":
                    world = "Global Helping Hands";
                    break;
                default:
                    world = "Invalid shortworld";
                    break;
            }*/
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
            default:
                world = "Undefined";
                break;
        }
        daytext.text = tempdate.ToString("dddd") + "\n" + tempdate.Hour % 12 + tempdate.ToString("tt");
        eventtext.text = eventshortname;
        desctext.text = tempdate.ToString("d")+"\nHosted by: "+teachers;

        if (counter == 0)
        {
            TimeSpan interval = tempdate- DateTime.Now;
            TextMeshProUGUI upcomingtext = GameObject.Find("/Schedule/InfoPanel/NoworUpcoming").GetComponent<TextMeshProUGUI>();
            //Debug.Log("tempdate:"+tempdate.ToString());
            //Debug.Log("current time:" + DateTime.Now.ToString());
            //Debug.Log("interval day: " + interval.Days+ ", hours: "+interval.Hours+", minutes: "+interval.Minutes+ ", seconds: " + interval.Seconds);
            upcomingtext.text = interval.Days + "d, " + interval.Hours + "h, " + interval.Minutes + "m, " + interval.Seconds + "s";
            if(interval.Days > 1)
            {
                if (interval.Hours > 1)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Days & " + interval.Hours + " Hours";
                }
                else if (interval.Hours == 1)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Days & " + interval.Hours + " Hour";
                }
                else if (interval.Hours == 0)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Days";
                }
            }
            else if(interval.Days == 1)
            {
                if (interval.Hours > 1)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Day & " + interval.Hours + " Hours";
                }
                else if (interval.Hours == 1 | interval.Hours == 0)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Day & " + interval.Hours + " Hour";
                }
                else if (interval.Hours == 0)
                {
                    upcomingtext.text = "Next Event:\n" + interval.Days + " Day";
                }
            }
            else if (interval.Days == 0)
            {
                if (interval.Hours > 1)
                {
                    if (interval.Minutes > 1)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hours & " + interval.Minutes + " Minutes";
                    }
                    else if (interval.Minutes == 1)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hours & " + interval.Minutes + " Minute";
                    }
                    else if (interval.Minutes == 0)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hours";
                    }
                }
                else if (interval.Hours == 1 )
                {
                    if (interval.Minutes > 1)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hour & " + interval.Minutes + " Minutes";
                    }
                    else if (interval.Minutes == 1)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hour & " + interval.Minutes + " Minute";
                    }
                    else if (interval.Minutes == 0)
                    {
                        upcomingtext.text = "Next Event:\n" + interval.Hours + " Hour";
                    }
                }
                else if( interval.Hours == 0)
                {
                    if(interval.Minutes > 1)
                    {
                        if (interval.Seconds > 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minutes & " + interval.Seconds + " Seconds";
                        }
                        else if (interval.Seconds == 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minutes & " + interval.Seconds + " Second";
                        }
                        else if (interval.Seconds == 0)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minutes";
                        }
                    }
                    else if (interval.Minutes == 1)
                    {
                        if (interval.Seconds > 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minute & " + interval.Seconds + " Seconds";
                        }
                        else if (interval.Seconds == 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minute & " + interval.Seconds + " Second";
                        }
                        else if (interval.Seconds == 0)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Minutes + " Minute";
                        }
                    }
                    else if (interval.Minutes == 0)
                    {
                        if (interval.Seconds > 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Seconds + " Seconds";
                        }
                        else if (interval.Seconds == 1)
                        {
                            upcomingtext.text = "Next Event:\n" + interval.Seconds + " Second";
                        }
                        else if (interval.Seconds == 0)
                        {
                            upcomingtext.text = "Next Event:\n Starting Now";
                        }
                    }
                    else if (interval.Minutes<0 & interval.Minutes > -30)
                    {
                        upcomingtext.text = "Just Started:\n" + interval.Minutes * -1 + " Minutes Ago";
                    }
                }
            }


            GameObject.Find("/Schedule/InfoPanel/EventName").GetComponent<TextMeshProUGUI>().text = eventlongname;
            GameObject.Find("/Schedule/InfoPanel/LocationText").GetComponent<TextMeshProUGUI>().text = "Location:\n"+world;
            GameObject.Find("/Schedule/InfoPanel/HostText").GetComponent<TextMeshProUGUI>().text ="Hosted by:\n"+teachers;

        }

        //Debug.Log("scheduletextboard.text: " + scheduletextboard.text);

        //}
    }
}
