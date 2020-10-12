using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SubtitleEngine : MonoBehaviour
{
	static TextAsset textFile = null;
    private float CutSceneEngineOn = 1;
    private float CutSceneTime = 0;
    private int CurrentCutSceneSeq = 1;
	private string[] CutsceneTimeLines;
	private string[] CutsceneTextLines;
	private string[] CutsceneVideoLines;
	private string[] CutsceneAudioLines;
	private string[] CutsceneFuncLines;
	private Sprite img1;
	public Text Text;
	public GameObject MyImage;	
	public string SongName;
    // Start is called before the first frame update
    void Start()
    {
		StartCutScene("ChristmasSongs",SongName);
    }
    // Update is called once per frame
    void Update()
    {
		
        if (CutSceneEngineOn == 1)
        {
            CutSceneTime += Time.deltaTime;
        }
		
        if (CutSceneTime == float.Parse(CutsceneTimeLines[CurrentCutSceneSeq])|| CutSceneTime > float.Parse(CutsceneTimeLines[CurrentCutSceneSeq])) 
        {
			Text.text = CutsceneTextLines[CurrentCutSceneSeq];
			PlayVideo();
			if (CutsceneAudioLines[CurrentCutSceneSeq] != "")
			{
	       	 	PlayAudioClip(CutsceneAudioLines[CurrentCutSceneSeq]);
			}

	       	RunFunction(CutsceneFuncLines[CurrentCutSceneSeq]);
				
			// this syncs the cut scene time, accounting for any errors
		    CutSceneTime = float.Parse(CutsceneTimeLines[CurrentCutSceneSeq]);
			// update sequence
			CurrentCutSceneSeq = CurrentCutSceneSeq +1;	
        }
    }
    void StartCutScene(string TextFile, string SceneID)
    {
		CutSceneEngineOn = 1;
		CutsceneTimeLines = LoadCSData(TextFile, SceneID, 2).ToString().Split('\n');
		CutsceneVideoLines = LoadCSData(TextFile, SceneID, 3).ToString().Split('\n');
		CutsceneTextLines = LoadCSData(TextFile, SceneID, 4).ToString().Split('\n');
		CutsceneAudioLines = LoadCSData(TextFile, SceneID, 5).ToString().Split('\n');
		CutsceneFuncLines = LoadCSData(TextFile, SceneID, 6).ToString().Split('\n');
		// must be called after initilizing variables.
    }
    void PlayAudioClip(string AudioName)
    {

      AudioSource audioSource = gameObject.AddComponent<AudioSource>();
      gameObject.GetComponent<AudioSource>().clip = Resources.Load(AudioName) as AudioClip;
      gameObject.GetComponent<AudioSource>().Play();	
    }
    public void RunFunction(string Function)
	{
		if (Function.StartsWith("PAUSE")) 
		{
			CutSceneEngineOn = 0;
		}
		if (Function.StartsWith("END")) 
		{
			EndCutScene();	
		}
	}
    void PlayVideo()
    {
	 	 img1 = Resources.Load<Sprite>("Images/" + CutsceneVideoLines[CurrentCutSceneSeq]);
	 	 MyImage.GetComponent<Image>().sprite = img1;
    }
    void EndCutScene()
    {
		SceneManager.LoadScene(0);
		Text.text = "";
		CutSceneEngineOn = 0;
		CutSceneTime = 0;
		CurrentCutSceneSeq= 0;
		
    }
    public string LoadCSData(string CutSceneFile, string CutSceneID, int IndexNum)
	{
		string csdata = "";
	  	string tempcsdata = "";
	  	try
	  	{

			var textFile = Resources.Load<TextAsset>(CutSceneFile);
			string[] lines = textFile.ToString().Split('\n');	

			foreach (string line in lines)
			{
			    if (line.Contains("|"+ CutSceneID + "|"))
			    {
		  		    string[] col = line.Split('|');
	  			    tempcsdata = csdata;
					csdata = tempcsdata + "\n" + col[IndexNum];
			    }
			}		
	  	}
	  	catch
	  	{
			Debug.Log("Cutscene text file loading failed");
	  	}
		return csdata;
    }
}