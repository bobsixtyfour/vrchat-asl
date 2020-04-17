using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Udonmenusystem : UdonSharpBehaviour
{

    public signlanguagearrayclass sla = GameObject.Find("/sla").GetComponent<signlanguagearrayclass>();

                    //public string[][][] AllLessons = new string[1][][]; 
                    


    GameObject[] buttons = new GameObject[56];
    GameObject[] indexicons = new GameObject[56];
    GameObject[] regvricons = new GameObject[56];
    GameObject[] bothvricons = new GameObject[56];
    Text[] buttontext = new Text[56];
    


/*
        char seperator = '|';
        string[] split1 = ASLL1.Split(seperator);
        string[] signwordarray = new string[split1.Length];
        for (int wordnum = 0; wordnum < split1.Length; wordnum++){
            char seperator2 = ',';
            string[] split2 = split1[wordnum].Split(seperator2);
            //Debug.Log("wtf"+split2[0]);
            buttontext.text=
        }
*/
Text menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Menu Header").GetComponent<Text>();

//public GameObject videotest;
    void Start()
    {

        DisplayLanguageSelectMenu();
    }
    void resetword(){
        sla.nana.SetInteger("sign",0); //reset animator to animationint 0, which should be idle 
sla.speechbubbletext.text="";
sla.currentsigntext.text="";
sla.signcredittext.text="";
sla.descriptiontext.text="";
    }
    void BackButtonClicked(){//figure out previous sign and set word/lesson to 00's and then update the menu/reset animationint/text
        int board = figureoutpreviousboard();
        
            switch (board)
        {
            case 0:
            Debug.Log("There shouldn't be any back button enabled on the main language menu. Wtf");
            sla.prevsign="00000";
            break;
            case 1: //we're currently on the lang select menu. switch to lang select menu.
            sla.prevsign="00000";
            DisplayLanguageSelectMenu();
            //resetword();
            break; //set new sign =
            case 2: //we're on the word select, go back to lesson select
            if(sla.prevsign.Substring(3, 2) != "00"){
                TurnOffVideo();
            } 
            resetword();
            sla.prevsign=sla.prevsign.Substring(0,2)+"0000";
            DisplayLessonSelectMenu(int.Parse(sla.prevsign.Substring(0,1)));
            break;
            default:
            Debug.Log("How is boardnum this value"+board);
            break;
        }
    }
    string figureoutcurrentsignnumber(int board, int buttonnumber){ //returns 00000 
        switch (board)
        {
            case 0:
            return (buttonnumber-1)+"0000"; 
            case 1:
            return sla.prevsign.Substring(0,1)+(buttonnumber-1)+"00";
            case 2:
            return sla.prevsign.Substring(0,3)+(buttonnumber-1);
            default:
            Debug.Log("How is boardnum this value"+board);
            return "0";
        }

    }
    int figureoutpreviousboard(){ //assuming prevsign is accessible, return which board we were on
        
        if(sla.prevsign.Substring(0,1)=="0"){
            //we're on a lesson select board if we don't have a current lang selected
            //DisplayLanguageSelectMenu();?
            return 0;
        }else 
        if(sla.prevsign.Substring(1,2)=="00"){
            //we're on a lesson select board if we have a lang selected (not 0) and lesson select is unknown (00's)
            return 1;
        }else//if(prevsign.Substring(3,2)=="00"){//is wordnum00?
        {
        //we're on a word select board since it can't be the other two.
        return 2;
        }
        //Debug.Log("Function 'figureoutpreviousboard' isn't sure what board we're on for some reason"+prevsign);
        //return 0;
    }
    void buttonpushed(int x) {
	//figure out what the current signnumber is based on x and prevsign (figure out previous screen first)
	sla.signnumber = figureoutcurrentsignnumber(figureoutpreviousboard(), x);

	if (sla.signnumber == sla.prevsign) {
		Debug.Log("The sign didn't change" + sla.prevsign);
		return;
	}
	else {
/*
		int langnum;
		int lessonnum;
		int wordnum;
		int prevlangnum;
		int prevlessonnum;
		int prevwordnum;
		//do nothing if the sign is the same as the previous one
		if (int.TryParse(signnumber.Substring(0, 1), out langnum)) {} else {
			Debug.Log("signnumber invalid wordnumber int inputted into buttonpushed" + signnumber.Substring(3, 2));
		}
		if (int.TryParse(signnumber.Substring(1, 2), out lessonnum)) {} else {
			Debug.Log("signnumber invalid lessonnumber int inputted into buttonpushed" + signnumber.Substring(1, 2));
		}
		if (int.TryParse(signnumber.Substring(3, 2), out wordnum)) {} else {
			Debug.Log("signnumber invalid langnumber int inputted into buttonpushed" + signnumber.Substring(0, 1));
		}
		if (int.TryParse(prevsign.Substring(0, 1), out prevlangnum)) {} else {
			Debug.Log("prevsign invalid wordnumber int inputted into buttonpushed" + prevsign.Substring(3, 2));
		}
		if (int.TryParse(prevsign.Substring(1, 2), out prevlessonnum)) {} else {
			Debug.Log("prevsign invalid lessonnumber int inputted into buttonpushed" + prevsign.Substring(1, 2));
		}
		if (int.TryParse(prevsign.Substring(3, 2), out prevwordnum)) {} else {
			Debug.Log("prevsign invalid langnumber int inputted into buttonpushed" + prevsign.Substring(0, 1));
		}*/


		if (sla.signnumber.Substring(0, 1) != sla.prevsign.Substring(0, 1)) {
			Debug.Log("holyshit the language changed. gotta be to the main menu");
			if (sla.signnumber.Substring(0, 1) == "0") {
				DisplayLanguageSelectMenu();
				sla.prevsign = sla.signnumber;
			}
		} else if (sla.signnumber.Substring(1, 2) != sla.prevsign.Substring(1, 2)) { //did the lesson change?
			//the lesson changed, disable video and parse + load the buttons for the next thing based on what the button was set to.
			if (sla.signnumber.Substring(1, 2) == "00") { //change to lesson select. the word should always be reset to 00 if changing lessons.
				if (sla.signnumber.Substring(3, 2) != "00") {
					Debug.Log("why the fuck is the word not 00 when the lesson is 00");
				} else { //wordnumb is zero
					DisplayLessonSelectMenu(int.Parse(sla.signnumber.Substring(1, 2)));
					sla.prevsign = sla.signnumber;
				}
			}
            //the lesson is not 00, so a word should be something
		} else if (sla.signnumber.Substring(3, 2) != sla.prevsign.Substring(3, 2)) //did the word change?
        { 
            if (sla.prevsign.Substring(3, 2) != "00") { //if word changed and PREVIOUS word might have had a video turn it off.
TurnOffVideo();
            changeword(x); //this should also handle it if the url was blank.
            }

            if (sla.signnumber.Substring(3, 2) != "00") { //if the new sign is a word selection 

            }else{//the sign number is also 00's
					DisplayLessonSelectMenu(int.Parse(sla.signnumber.Substring(1, 2)));
					sla.prevsign = sla.signnumber;
                //display lesson select.


            }


		}
	}
}

    void changeword(int buttonnumber){//wordnum must not be 00.

    //        string[][][] AllLessons = new string[1][][];
      //  AllLessons[0]=ASLlessons;
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(sla.signnumber.Substring(0,1), out langnum)){
            if (int.TryParse(sla.signnumber.Substring(1,2), out lessonnum)){
                if (int.TryParse(sla.signnumber.Substring(3,2), out wordnum)){
                    //string[][][] AllLessons = new string[1][][];
                    //AllLessons[0]=ASLlessons;
                    //string [][][] AllLessons = { ASLlessons}; 
                    char seperator = ',';
                    string[] split1 = sla.Alllessons[langnum][lessonnum][wordnum].Split(seperator);
                    string[] wordparameters = new string[split1.Length];
                    //AllLessons[langnum][lessonnum][wordnum]
                    if(wordparameters[4]==""){
//do nothing because there was no video 
                    }else
                    {
                        GameObject.Find("/Udon Menu System/Video Container/"+sla.langshort[langnum]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(false);
                        sla.nana.SetInteger("sign",langnum+lessonnum+wordnum); 
                        sla.speechbubbletext.text=wordparameters[0];
                        sla.currentsigntext.text=wordparameters[0];
                        sla.signcredittext.text=wordparameters[3];
                        sla.descriptiontext.text=wordparameters[6];
                    }
                }
                else
                {
                    Debug.Log ("Not a valid wordnumber int inputted into turnoffvideo"+sla.prevsign.Substring(3,2));
                }
            }
            else
            {
                Debug.Log ("Not a valid lessonnumber int inputted into turnoffvideo"+sla.prevsign.Substring(1,2));
            }
        }
        else
        {
            Debug.Log ("Not a valid langnumber int inputted into turnoffvideo"+sla.prevsign.Substring(0,1));
        }
    
    }

    void TurnOffVideo(){
        if(sla.prevsign.Substring(3,2)=="00"){
            Debug.Log("Why am I turning off a video when it shouldn't be on?");
        }else{
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(sla.prevsign.Substring(0,1), out langnum)){
            if (int.TryParse(sla.prevsign.Substring(1,2), out lessonnum)){
                if (int.TryParse(sla.prevsign.Substring(3,2), out wordnum)){
      //  string[][][] AllLessons = new string[1][][];
     //   AllLessons[0]=ASLlessons;
                    char seperator = ',';
                    string[] wordparameters = sla.Alllessons[langnum][lessonnum][wordnum].Split(seperator);
                    //string[] wordparameters = new string[split.Length];
                    //AllLessons[langnum][lessonnum][wordnum]
                    if(wordparameters[4]==""){
//do nothing because there was no video
                    }else
                    {
                    GameObject.Find("/Udon Menu System/Video Container/"+sla.langshort[langnum]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(false);    
                    }
                }
                else
                {
                    Debug.Log ("Not a valid wordnumber int inputted into turnoffvideo"+sla.prevsign.Substring(3,2));
                }
            }
            else
            {
                Debug.Log ("Not a valid lessonnumber int inputted into turnoffvideo"+sla.prevsign.Substring(1,2));
            }
        }
        else
        {
            Debug.Log ("Not a valid langnumber int inputted into turnoffvideo"+sla.prevsign.Substring(0,1));
        }
    }
    }
    void DisplaySignSelectMenu(int langnum, int lessonnum){
      //  string[][][] AllLessons = new string[1][][];
     //   AllLessons[0]=ASLlessons;
        menuheadertext.text=sla.langshort[langnum]+" Lesson Menu";
        char seperator = ',';
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(sla.Alllessons[langnum][lessonnum].Length>x){
                
                string[] wordparameters = sla.Alllessons[langnum][lessonnum][x].Split(seperator);
                //string[] wordparameters = new string[split.Length]; 
                buttontext[x].text=wordparameters[0];


                switch (wordparameters[5]){//vr type
                    case "0":
                    indexicons[x].SetActive(true);
                    break;
                    case "1":
                    regvricons[x].SetActive(true);
                    break;
                    case "2":
                    bothvricons[x].SetActive(true);
                    break;
                    default:
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
                    break;
                }

            }else{
                buttons[x].SetActive(false);
            }
        }
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function... 
    }
    void DisplayLessonSelectMenu(int langnnum){
        
        menuheadertext.text=sla.langshort[langnnum]+" Lesson Menu";
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(sla.languages.Length>x){
                buttontext[x].text=sla.languages[x];
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
            }else{
                buttons[x].SetActive(false);
            }
        }
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function... 
    }
    void DisplayLanguageSelectMenu(){
        menuheadertext.text="VR Sign Language Select Menu";
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(sla.languages.Length>x){
                buttontext[x].text=sla.languages[x];
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
            }else{
                buttons[x].SetActive(false);
            }
        }
        
    }

void B0()       
{
buttonpushed(0);
}
void B1()
{        
buttonpushed(1);
}
void B2()
{
buttonpushed(2);
}
void B3()
{
buttonpushed(3);
}
void B4()
{
buttonpushed(4);
}
void B5()
{
buttonpushed(5);
}
void B6()
{
buttonpushed(6);
}
void B7()
{
buttonpushed(7);
}
void B8()
{
buttonpushed(8);
}
void B9()
{
buttonpushed(9);
}
void B10()
{
buttonpushed(10);
}
void B11()
{
buttonpushed(11);
}
void B12()
{
buttonpushed(12);
}
void B13()
{
buttonpushed(13);
}
void B14()
{
buttonpushed(14);
}
void B15()
{
buttonpushed(15);
}
void B16()
{
buttonpushed(16);
}
void B17()
{
buttonpushed(17);
}
void B18()
{
buttonpushed(18);
}
void B19()
{
buttonpushed(19);
}
void B20()
{
buttonpushed(20);
}
void B21()
{
buttonpushed(21);
}
void B22()
{
buttonpushed(22);
}
void B23()
{
buttonpushed(23);
}
void B24()
{
buttonpushed(24);
}
void B25()
{
buttonpushed(25);
}
void B26()
{
buttonpushed(26);
}
void B27()
{
buttonpushed(27);
}
void B28()
{
buttonpushed(28);
}
void B29()
{
buttonpushed(29);
}
void B30()
{
buttonpushed(30);
}
void B31()
{
buttonpushed(31);
}
void B32()
{
buttonpushed(32);
}
void B33()
{
buttonpushed(33);
}
void B34()
{
buttonpushed(34);
}
void B35()
{
buttonpushed(35);
}
void B36()
{
buttonpushed(36);
}
void B37()
{
buttonpushed(37);
}
void B38()
{
buttonpushed(38);
}
void B39()
{
buttonpushed(39);
}
void B40()
{
buttonpushed(40);
}
void B41()
{
buttonpushed(41);
}
void B42()
{
buttonpushed(42);
}
void B43()
{
buttonpushed(43);
}
void B44()
{
buttonpushed(44);
}
void B45()
{
buttonpushed(45);
}
void B46()
{
buttonpushed(46);
}
void B47()
{
buttonpushed(47);
}
void B48()
{
buttonpushed(48);
}
void B49()
{
buttonpushed(49);
}
void B50()
{
buttonpushed(50);
}
void B51()
{
buttonpushed(51);
}
void B52()
{
buttonpushed(52);
}
void B53()
{
buttonpushed(53);
}
void B54()
{
buttonpushed(54);
}
void B55()
{
buttonpushed(55);
}



}
