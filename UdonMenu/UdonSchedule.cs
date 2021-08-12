
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;

public class UdonSchedule : UdonSharpBehaviour
{
    int lastdayofweekdisplayed=-1;
    
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


        keys = FuturiseArray(keys);
        keys = SortArray(keys);

        
        //scheduletextboard.text = "test";

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
        foreach (string[] value in tempkeys)
        {
            Displaydate(DateTime.Parse(value[0]).Add(difference), value[1], value[2], value[3]);
            //Debug.Log("After sort: "+ value[0] + "," + value[1] + "," + value[2] + "," + value[3]);
        }
        return tempkeys;
    }


    //have dayofweek in main program, just display selected events here?
    void Displaydate(DateTime tempdate, String shortlang, String shortworld, String teachers)
    {
        TextMeshProUGUI scheduletextboard = GameObject.Find("/Schedule/Panel/Text (TMP)").GetComponent<TextMeshProUGUI>();
        //scheduletextboard = GameObject.Find("/Schedule/Panel/Text (TMP)").GetComponent<TextMeshProUGUI>();
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

            //Debug.Log("scheduletextboard.text: " + scheduletextboard.text);
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
