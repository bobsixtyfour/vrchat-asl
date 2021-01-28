using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;

public class bobskeyboard : UdonSharpBehaviour
{
    public Text chatlinebuffer;
    public Text chathistory;

    //public InputField kbinput;
    private VRCPlayerApi _localPlayer;
    bool shift=false;
    bool CapsLock=false;
    [SerializeField] //this shows private fields in the inspector
    private Color _defaultColor = new Color(0x00, 0x60, 0xff, 0x00) / 0x100;
    [SerializeField]
    private Color _clickedColor = new Color(0x00, 0x60, 0xff, 0x80) / 0x100;
    Transform _eventTriggersParent;
    public VRC.SDKBase.VRCStation station;
    [HideInInspector]
    public VRCPlayerApi seated;
    void Start()
    {
        
    }
    void Update()
    {
        if(seated == Networking.LocalPlayer){//handles keyboard input only if player is in a chair.
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){

            }else{//shift key is not down.

            }
        }

        
    }

    public void _pushed_chair()
    {
        if (seated == null)
        {
            station.UseStation(Networking.LocalPlayer);
        }
        else if(seated == Networking.LocalPlayer)
        {
            station.ExitStation(Networking.LocalPlayer);
        }
    }

    public override void OnStationEntered(VRC.SDKBase.VRCPlayerApi player){
        seated = player;
    }
    public override void OnStationExited(VRC.SDKBase.VRCPlayerApi player){ 
        if(seated == player)
        {
            seated = null;
        }
    }

    public void _pushed_Backspace(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Backspace");
    }
    public void network_pushed_Backspace(){
        if(chatlinebuffer.text.Length>0){
            chatlinebuffer.text=chatlinebuffer.text.Substring(0,chatlinebuffer.text.Length-1);
        }
    }
    public void _pushed_Return(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Return");
    }
    public void network_pushed_Return(){
        chathistory.text+="\n"+chatlinebuffer.text;
        chatlinebuffer.text="";
    }
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            _localPlayer = player;
        }
        chathistory.text+=$"\n[{DateTime.Now:HH:mm:ss}] {player.displayName} joined.";
    }
    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        chathistory.text+=$"\n[{DateTime.Now:HH:mm:ss}] {player.displayName} left.";
    }

public void _pushed_shift(){
    
    shift=!shift;
    _eventTriggersParent.Find("key_LShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
_eventTriggersParent.Find("key_RShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
}

public void _pushed_Shift(){
_pushed_shift();
}











public void _pushed_A(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_A");
_pushed_shift();
}else{
    Debug.Log("a pushed");
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_A");      
}
}

public void network_pushed_A(){
chatlinebuffer.text+="a";
}

public void network_pushed_Upper_A(){
chatlinebuffer.text+="A";
}

public void _pushed_B(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_B");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_B");
}
}

public void network_pushed_B(){
chatlinebuffer.text+="b";
}

public void network_pushed_Upper_B(){
chatlinebuffer.text+="B";
}

public void _pushed_C(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_C");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_C");
}
}

public void network_pushed_C(){
chatlinebuffer.text+="c";
}

public void network_pushed_Upper_C(){
chatlinebuffer.text+="C";
}

public void _pushed_D(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_D");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_D");
}
}

public void network_pushed_D(){
chatlinebuffer.text+="d";
}

public void network_pushed_Upper_D(){
chatlinebuffer.text+="D";
}

public void _pushed_E(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_E");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_E");
}
}

public void network_pushed_E(){
chatlinebuffer.text+="e";
}

public void network_pushed_Upper_E(){
chatlinebuffer.text+="E";
}

public void _pushed_F(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_F");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_F");
}
}

public void network_pushed_F(){
chatlinebuffer.text+="f";
}

public void network_pushed_Upper_F(){
chatlinebuffer.text+="F";
}

public void _pushed_G(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_G");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_G");
}
}

public void network_pushed_G(){
chatlinebuffer.text+="g";
}

public void network_pushed_Upper_G(){
chatlinebuffer.text+="G";
}

public void _pushed_H(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_H");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_H");
}
}

public void network_pushed_H(){
chatlinebuffer.text+="h";
}

public void network_pushed_Upper_H(){
chatlinebuffer.text+="H";
}

public void _pushed_I(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_I");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_I");
}
}

public void network_pushed_I(){
chatlinebuffer.text+="i";
}

public void network_pushed_Upper_I(){
chatlinebuffer.text+="I";
}

public void _pushed_J(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_J");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_J");
}
}

public void network_pushed_J(){
chatlinebuffer.text+="j";
}

public void network_pushed_Upper_J(){
chatlinebuffer.text+="J";
}

public void _pushed_K(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_K");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_K");
}
}

public void network_pushed_K(){
chatlinebuffer.text+="k";
}

public void network_pushed_Upper_K(){
chatlinebuffer.text+="K";
}

public void _pushed_L(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_L");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_L");
}
}

public void network_pushed_L(){
chatlinebuffer.text+="l";
}

public void network_pushed_Upper_L(){
chatlinebuffer.text+="L";
}

public void _pushed_M(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_M");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_M");
}
}

public void network_pushed_M(){
chatlinebuffer.text+="m";
}

public void network_pushed_Upper_M(){
chatlinebuffer.text+="M";
}

public void _pushed_N(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_N");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_N");
}
}

public void network_pushed_N(){
chatlinebuffer.text+="n";
}

public void network_pushed_Upper_N(){
chatlinebuffer.text+="N";
}

public void _pushed_O(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_O");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_O");
}
}

public void network_pushed_O(){
chatlinebuffer.text+="o";
}

public void network_pushed_Upper_O(){
chatlinebuffer.text+="O";
}

public void _pushed_P(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_P");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_P");
}
}

public void network_pushed_P(){
chatlinebuffer.text+="p";
}

public void network_pushed_Upper_P(){
chatlinebuffer.text+="P";
}

public void _pushed_Q(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Q");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Q");
}
}

public void network_pushed_Q(){
chatlinebuffer.text+="q";
}

public void network_pushed_Upper_Q(){
chatlinebuffer.text+="Q";
}

public void _pushed_R(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_R");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_R");
}
}

public void network_pushed_R(){
chatlinebuffer.text+="r";
}

public void network_pushed_Upper_R(){
chatlinebuffer.text+="R";
}

public void _pushed_S(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_S");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_S");
}
}

public void network_pushed_S(){
chatlinebuffer.text+="s";
}

public void network_pushed_Upper_S(){
chatlinebuffer.text+="S";
}

public void _pushed_T(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_T");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_T");
}
}

public void network_pushed_T(){
chatlinebuffer.text+="t";
}

public void network_pushed_Upper_T(){
chatlinebuffer.text+="T";
}

public void _pushed_U(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_U");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_U");
}
}

public void network_pushed_U(){
chatlinebuffer.text+="u";
}

public void network_pushed_Upper_U(){
chatlinebuffer.text+="U";
}

public void _pushed_V(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_V");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_V");
}
}

public void network_pushed_V(){
chatlinebuffer.text+="v";
}

public void network_pushed_Upper_V(){
chatlinebuffer.text+="V";
}

public void _pushed_W(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_W");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_W");
}
}

public void network_pushed_W(){
chatlinebuffer.text+="w";
}

public void network_pushed_Upper_W(){
chatlinebuffer.text+="W";
}

public void _pushed_X(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_X");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_X");
}
}

public void network_pushed_X(){
chatlinebuffer.text+="x";
}

public void network_pushed_Upper_X(){
chatlinebuffer.text+="X";
}

public void _pushed_Y(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Y");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Y");
}
}

public void network_pushed_Y(){
chatlinebuffer.text+="y";
}

public void network_pushed_Upper_Y(){
chatlinebuffer.text+="Y";
}

public void _pushed_Z(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Z");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Z");
}
}

public void network_pushed_Z(){
chatlinebuffer.text+="z";
}

public void network_pushed_Upper_Z(){
chatlinebuffer.text+="Z";
}

public void _pushed_Alpha0(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightParen");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha0");
}
}

public void network_pushed_Alpha0(){
chatlinebuffer.text+="0";
}

public void network_pushed_RightParen(){
chatlinebuffer.text+=")";
}

public void _pushed_Alpha1(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Exclaim");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha1");
}
}

public void network_pushed_Alpha1(){
chatlinebuffer.text+="1";
}

public void network_pushed_Exclaim(){
chatlinebuffer.text+="!";
}

public void _pushed_Alpha2(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_At");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha2");
}
}

public void network_pushed_Alpha2(){
chatlinebuffer.text+="2";
}

public void network_pushed_At(){
chatlinebuffer.text+="@";
}

public void _pushed_Alpha3(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Hash");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha3");
}
}

public void network_pushed_Alpha3(){
chatlinebuffer.text+="3";
}

public void network_pushed_Hash(){
chatlinebuffer.text+="#";
}

public void _pushed_Alpha4(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Dollar");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha4");
}
}

public void network_pushed_Alpha4(){
chatlinebuffer.text+="4";
}

public void network_pushed_Dollar(){
chatlinebuffer.text+="$";
}

public void _pushed_Alpha5(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Percent");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha5");
}
}

public void network_pushed_Alpha5(){
chatlinebuffer.text+="5";
}

public void network_pushed_Percent(){
chatlinebuffer.text+="%";
}

public void _pushed_Alpha6(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Caret");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha6");
}
}

public void network_pushed_Alpha6(){
chatlinebuffer.text+="6";
}

public void network_pushed_Caret(){
chatlinebuffer.text+="^";
}

public void _pushed_Alpha7(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Ampersand");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha7");
}
}

public void network_pushed_Alpha7(){
chatlinebuffer.text+="7";
}

public void network_pushed_Ampersand(){
chatlinebuffer.text+="&";
}

public void _pushed_Alpha8(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Asterisk");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha8");
}
}

public void network_pushed_Alpha8(){
chatlinebuffer.text+="8";
}

public void network_pushed_Asterisk(){
chatlinebuffer.text+="*";
}

public void _pushed_Alpha9(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftParen");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha9");
}
}

public void network_pushed_Alpha9(){
chatlinebuffer.text+="9";
}

public void network_pushed_LeftParen(){
chatlinebuffer.text+="(";
}

public void _pushed_Minus(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Underscore");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Minus");
}
}

public void network_pushed_Minus(){
chatlinebuffer.text+="-";
}

public void network_pushed_Underscore(){
chatlinebuffer.text+="_";
}

public void _pushed_Equals(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Plus");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Equals");
}
}

public void network_pushed_Equals(){
chatlinebuffer.text+="=";
}

public void network_pushed_Plus(){
chatlinebuffer.text+="+";
}

public void _pushed_LeftBracket(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftCurlyBracket");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftBracket");
}
}

public void network_pushed_LeftBracket(){
chatlinebuffer.text+="[";
}

public void network_pushed_LeftCurlyBracket(){
chatlinebuffer.text+="{";
}

public void _pushed_RightBracket(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightCurlyBracket");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightBracket");
}
}

public void network_pushed_RightBracket(){
chatlinebuffer.text+="]";
}

public void network_pushed_RightCurlyBracket(){
chatlinebuffer.text+="}";
}

public void _pushed_Backslash(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Pipe");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Backslash");
}
}

public void network_pushed_Backslash(){
chatlinebuffer.text+="\\";
}

public void network_pushed_Pipe(){
chatlinebuffer.text+="|";
}

public void _pushed_Semicolon(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Colon");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Semicolon");
}
}

public void network_pushed_Semicolon(){
chatlinebuffer.text+=";";
}

public void network_pushed_Colon(){
chatlinebuffer.text+=":";
}

public void _pushed_Quote(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_DoubleQuote");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Quote");
}
}

public void network_pushed_Quote(){
chatlinebuffer.text+="'";
}

public void network_pushed_DoubleQuote(){
chatlinebuffer.text+="\"";
}

public void _pushed_Comma(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Less");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Comma");
}
}

public void network_pushed_Comma(){
chatlinebuffer.text+=",";
}

public void network_pushed_Less(){
chatlinebuffer.text+="<";
}

public void _pushed_Period(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Greater");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Period");
}
}

public void network_pushed_Period(){
chatlinebuffer.text+=".";
}

public void network_pushed_Greater(){
chatlinebuffer.text+=">";
}

public void _pushed_Slash(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Question");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Slash");
}
}

public void network_pushed_Slash(){
chatlinebuffer.text+="/";
}

public void network_pushed_Question(){
chatlinebuffer.text+="?";
}

public void _pushed_BackQuote(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Tilde");
_pushed_shift();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_BackQuote");
}
}

public void network_pushed_BackQuote(){
chatlinebuffer.text+="`";
}

public void network_pushed_Tilde(){
chatlinebuffer.text+="~";
}

public void _pushed_CapsLock(){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_CapsLock");
}

public void network_pushed_CapsLock(){
chatlinebuffer.text+="";
}

public void _pushed_Tab(){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Tab");
}

public void network_pushed_Tab(){
chatlinebuffer.text+="     ";
}


public void _pushed_Space(){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Space");
}

public void network_pushed_Space(){
chatlinebuffer.text+=" ";
}





}
