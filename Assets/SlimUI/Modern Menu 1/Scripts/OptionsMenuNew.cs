﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuNew : MonoBehaviour {

	public enum Platform {Desktop, Mobile};
	public Platform platform;

    #region default
    // toggle buttons
    [Header("MOBILE SETTINGS")]
	public GameObject leftLine;
	public GameObject rightLine;
	public GameObject mobileShadowofftextLINE;
	public GameObject mobileShadowlowtextLINE;
	public GameObject mobileShadowhightextLINE;

	[Header("VIDEO SETTINGS")]
	public GameObject ambientocclusiontext;
	public GameObject shadowofftextLINE;
	public GameObject shadowlowtextLINE;
	public GameObject shadowhightextLINE;
	public GameObject aaofftextLINE;
	public GameObject aa2xtextLINE;
	public GameObject aa4xtextLINE;
	public GameObject aa8xtextLINE;
	public GameObject vsynctext;
	public GameObject motionblurtext;
	public GameObject texturelowtextLINE;
	public GameObject texturemedtextLINE;
	public GameObject texturehightextLINE;
	public GameObject cameraeffectstext; 

	[Header("GAME SETTINGS")]
	public GameObject showhudtext;
	public GameObject tooltipstext;
	public GameObject difficultynormaltext;
	public GameObject difficultynormaltextLINE;
	public GameObject difficultyhardcoretext;
	public GameObject difficultyhardcoretextLINE;

	[Header("CONTROLS SETTINGS")]
	public GameObject invertmousetext;
    #endregion
    // sliders
    public GameObject musicSlider;

    private Data data;
	private float sliderValue = 0.0f;

    private void Awake()
    {
        data = GameObject.Find("Data").GetComponent<Data>();
    }
    public void Start(){
		if(data.Pc){
			difficultynormaltextLINE.gameObject.SetActive(true);
			difficultyhardcoretextLINE.gameObject.SetActive(false);
		}
		else
		{
			difficultyhardcoretextLINE.gameObject.SetActive(true);
			difficultynormaltextLINE.gameObject.SetActive(false);
		}

		// check slider values
		musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
		
		// check tool tip value
		if(PlayerPrefs.GetInt("ToolTips")==0){
			tooltipstext.GetComponent<TMP_Text>().text = "off";
		}
		else{
			tooltipstext.GetComponent<TMP_Text>().text = "on";
		}
	}
	public void  Update (){
		sliderValue = musicSlider.GetComponent<Slider>().value;
	}
	public void MusicSlider (){
		PlayerPrefs.SetFloat("MusicVolume", sliderValue);
	}

	// the playerprefs variable that is checked to enable hud while in game
	public void  ShowHUD (){
		if(PlayerPrefs.GetInt("ShowHUD")==0){
			PlayerPrefs.SetInt("ShowHUD",1);
			showhudtext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("ShowHUD")==1){
			PlayerPrefs.SetInt("ShowHUD",0);
			showhudtext.GetComponent<TMP_Text>().text = "off";
		}
	}

	// show tool tips like: 'How to Play' control pop ups
	public void  ToolTips (){
		if(PlayerPrefs.GetInt("ToolTips")==0){
			PlayerPrefs.SetInt("ToolTips",1);
			tooltipstext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("ToolTips")==1){
			PlayerPrefs.SetInt("ToolTips",0);
			tooltipstext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  NormalDifficulty (){
		difficultyhardcoretextLINE.gameObject.SetActive(false);
		difficultynormaltextLINE.gameObject.SetActive(true);
        data.SetPlatform(true);
	}

	public void  HardcoreDifficulty (){
		difficultyhardcoretextLINE.gameObject.SetActive(true);
		difficultynormaltextLINE.gameObject.SetActive(false);
        data.SetPlatform(false);
    }

    public void TriggerLeft()
    {
        leftLine.SetActive(true);
        rightLine.SetActive(false);
        data.SetHand(false);
    }
    public void TriggerRight()
    {
        leftLine.SetActive(false);
        rightLine.SetActive(true);
        data.SetHand(true);
    }
    public void vsync (){
		if(QualitySettings.vSyncCount == 0){
			QualitySettings.vSyncCount = 1;
			vsynctext.GetComponent<TMP_Text>().text = "on";
		}
		else if(QualitySettings.vSyncCount == 1){
			QualitySettings.vSyncCount = 0;
			vsynctext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  InvertMouse (){
		if(PlayerPrefs.GetInt("Inverted")==0){
			PlayerPrefs.SetInt("Inverted",1);
			invertmousetext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("Inverted")==1){
			PlayerPrefs.SetInt("Inverted",0);
			invertmousetext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  MotionBlur (){
		if(PlayerPrefs.GetInt("MotionBlur")==0){
			PlayerPrefs.SetInt("MotionBlur",1);
			motionblurtext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("MotionBlur")==1){
			PlayerPrefs.SetInt("MotionBlur",0);
			motionblurtext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  AmbientOcclusion (){
		if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
			PlayerPrefs.SetInt("AmbientOcclusion",1);
			ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
			PlayerPrefs.SetInt("AmbientOcclusion",0);
			ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  CameraEffects (){
		if(PlayerPrefs.GetInt("CameraEffects")==0){
			PlayerPrefs.SetInt("CameraEffects",1);
			cameraeffectstext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("CameraEffects")==1){
			PlayerPrefs.SetInt("CameraEffects",0);
			cameraeffectstext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  TexturesLow (){
		PlayerPrefs.SetInt("Textures",0);
		QualitySettings.masterTextureLimit = 2;
		texturelowtextLINE.gameObject.SetActive(true);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesMed (){
		PlayerPrefs.SetInt("Textures",1);
		QualitySettings.masterTextureLimit = 1;
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(true);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesHigh (){
		PlayerPrefs.SetInt("Textures",2);
		QualitySettings.masterTextureLimit = 0;
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(true);
	}
}