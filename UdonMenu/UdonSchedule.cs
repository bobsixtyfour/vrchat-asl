
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;

public class UdonSchedule : UdonSharpBehaviour
{
    int lastdayofweekdisplayed=-1;
    TextMeshProUGUI scheduletextboard;
    void Start()
    {
        string[][] keys = new string[][]{
            new string[]{"08/09/2021 07:00PM","LSF","MRD","Roineru_FR, MrRikuG935, MaxDeaf_FR"},
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
            new string[]{"08/15/2021 08:00PM","LSF","MRD","hppedeaf"},
        };




        scheduletextboard = GameObject.Find("/Schedule/Panel/Text (TMP)").GetComponent<TextMeshProUGUI>();
        DateTime currentdate, utcdate;
        TimeSpan difference;
        currentdate = DateTime.Now;
        utcdate = DateTime.UtcNow;
       
        
        difference = currentdate - utcdate;
        //Debug.Log("currentdate: "+currentdate + ", utcdate: "+ utcdate + ", diff: "+difference);
        //Debug.Log("utcdate+difference:" + utcdate.Add(difference));
        //Debug.Log(DateTime.UtcNow);


        DateTime date3 = new DateTime(2010, 7, 12, 07, 0, 0);
        //Debug.Log(date3.ToString("f"));
        //Debug.Log("Timezone: " + TimeZoneInfo.Local.Id);
        //Debug.Log("GMT Offset: " + (DateTime.UtcNow - DateTime.Now));


        Displaydate(new DateTime(2021, 7, 25, 0, 0, 0).Add(difference), "ASL", "HHHQ", "Jenny0629");
        Displaydate(new DateTime(2021, 7, 25, 19, 0, 0).Add(difference), "ASL", "SHH", "Crow_Se7en");
        Displaydate(new DateTime(2021, 7, 25, 20, 0, 0).Add(difference), "LSF", "MRD", "hppedeaf");
        //Displaydate(new DateTime(2021, 7, 25, 21, 0, 0).Add(difference), "KSL", "SHH", "Korea_Yujin");
        Displaydate(new DateTime(2021, 7, 19, 19, 0, 0).Add(difference), "LSF", "SHH", "Roineru_FR, MrRikuG935, MaxDeaf_FR");
        Displaydate(new DateTime(2021, 7, 20, 18, 0, 0).Add(difference), "ASL", "MRD", "Ray_is_Deaf");
        Displaydate(new DateTime(2021, 7, 20, 19, 0, 0).Add(difference), "DGS", "MRD", "deaf_danielo_89");
        Displaydate(new DateTime(2021, 8, 11, 22, 0, 0).Add(difference), "ASL", "MRDCS", "DmTheMechanic");
        Displaydate(new DateTime(2021, 7, 22, 19, 0, 0).Add(difference), "BSL", "GHH", "CathDeafGamer");
        Displaydate(new DateTime(2021, 7, 23, 01, 0, 0).Add(difference), "ASL-C", "HHHQ", "Fearlesskoolaid");
        Displaydate(new DateTime(2021, 7, 23, 20, 0, 0).Add(difference), "ASL", "MRD", "Wardragon");
        Displaydate(new DateTime(2021, 7, 24, 19, 0, 0).Add(difference), "BSL", "GHH", "CathDeafGamer");
        Displaydate(new DateTime(2021, 7, 24, 20, 0, 0).Add(difference), "LSF-C", "HHHQ", "Roineru_FR");
        Displaydate(new DateTime(2021, 7, 24, 21, 0, 0).Add(difference), "BSL-C", "HHHQ", "CathDeafGamer");




        // The example displays the following output, in this case for en-us culture:
        //      8/18/2010 4:32:00 PM

         
        //find utc time of all events, minus current time % 7 to get offset? add offset to all events to get day/time in current week?
    }


    void SortArray(string[][] tempkeys)
    {
        string[][] temp = new string[1][];
        for (int i = 0; i < tempkeys[0].Length - 1; i++)

            // traverse i+1 to array length
            for (int j = i + 1; j < tempkeys[0].Length; j++)

                // compare array element with 
                // all next element
                if (DateTime.Parse(tempkeys[i][0]) < DateTime.Parse(tempkeys[j][0]))
                {

                    temp[0] = tempkeys[i];
                    tempkeys[i] = tempkeys[j];
                    tempkeys[j] = temp[0];
                }

        // print all element of array
        foreach (string[] value in tempkeys)
        {
            Debug.Log(value[0] + "," + value[1] + "," + value[2] + "," + value[3]);
        }
    }


    //have dayofweek in main program, just display selected events here?
    void Displaydate(DateTime tempdate, String shortlang, String shortworld, String teachers)
    {
        TimeSpan span = DateTime.Now - tempdate;
        //Debug.Log("span: " + span + " span.Days:" + span.Days + " span/7*7:" + span.Days / 7*7);
        if (DateTime.Now > tempdate)//if the time is in the future already, skip?
        {
            //Debug.Log("Time: " + temputcdate.ToString("f"));
            //Debug.Log("days added: " + (span.Days / 7 + 1) * 7);
            tempdate=tempdate.AddDays((span.Days / 7 + 1) * 7);
        //Debug.Log("Time: " + temputcdate.ToString("f"));
        }
        //DateTime.UtcNow
        TimeSpan span2 = DateTime.UtcNow - tempdate;
        //Debug.Log("span2: " + span2);
        if (DateTime.Now < tempdate && span2.Days>-6) { //display if event hasn't happened yet
            String lang;
            String world;
            //convert shortlang/world to long
            switch (shortlang)
            {
                case "ASL":
                    lang = "Language: ASL (American Sign Language)";
                    break;
                case "ASL-C":
                    lang = "Event: ASL Intermediate Club";
                    break;
                case "BSL":
                    lang = "Language: BSL (British Sign Language)";
                    break;
                case "BSL-C":
                    lang = "BSL Intermediate Club";
                    break;
                case "DGS":
                    lang = "DGS (German Sign Language)";
                    break;
                case "DGS-C":
                    lang = "DGS Intermediate Club";
                    break;
                case "KSL":
                    lang = "KSL (Korean Sign Language)";
                    break;
                case "LSF":
                    lang = "LSF (French Sign Language)";
                    break;
                case "LSF-C":
                    lang = "LSF Intermediate Club";
                    break;
                default:
                    lang = "Invalid shortlang";
                    break;
            }

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
            }

            if ((int)tempdate.DayOfWeek != lastdayofweekdisplayed)
            {
                //Debug.Log("0==lastdayofweekdisplayed" + lastdayofweekdisplayed);
                scheduletextboard.text = scheduletextboard.text + "\n\n--------------------------------\n" + tempdate.ToString("dddd") + "'s Events:";

                //Debug.Log(tempdate.ToString("dddd") + "'s Events:");
            }
            else
            {
                scheduletextboard.text = scheduletextboard.text + "\n";
                //Debug.Log("\n");
            }

            //tempdate.ToString("dddd, dd MMMM yyyy");
            scheduletextboard.text = scheduletextboard.text + "\n" + lang;
            scheduletextboard.text = scheduletextboard.text + "\nHosted By: " + teachers;
            scheduletextboard.text = scheduletextboard.text + "\nLocation: " + world;
            scheduletextboard.text = scheduletextboard.text + "\nTime: " + (tempdate).ToString("f");
            //scheduletextboard.text = scheduletextboard.text + "\n";

            lastdayofweekdisplayed = (int)tempdate.DayOfWeek;
        }
    }
}
