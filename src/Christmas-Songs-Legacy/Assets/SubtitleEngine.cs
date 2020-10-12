using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SubtitleEngine : MonoBehaviour
{
	static TextAsset textFile = null;
    private float CutSceneEngineOn = 1;
    private float CutSceneTime = 0;
    private int CurrentCutSceneSeq = 1;
    public int CurrentTex = 0;
	private string[] CutsceneTimeLines;
	private string[] CutsceneTextLines;
	private string[] CutsceneVideoLines;
	private string[] CutsceneAudioLines;
	private string[] CutsceneFuncLines;
	//private Image img1;
	public GUIText Text;
	public GameObject MyImage;	
	public string SongName;
    public Texture2D tex1;
    public Texture2D tex2;
    public Texture2D tex3;
    public Texture2D tex4;
    public Texture2D tex5;
    public Texture2D tex6;
    public Texture2D tex7;
    public Texture2D tex8;
    public Texture2D tex9;
    public Texture2D tex10;
    public Texture2D tex11;
    public Texture2D tex12;
    public Texture2D tex13;


    // Start is called before the first frame update
    void Start()
    {
		StartCutScene("ChristmasSongs",SongName);
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            if (CutSceneEngineOn == 1)
            {
                CutSceneTime += Time.deltaTime;
            }
            
            if (CutSceneTime == float.Parse(CutsceneTimeLines[CurrentCutSceneSeq])|| CutSceneTime > float.Parse(CutsceneTimeLines[CurrentCutSceneSeq]))
            {
                //Text.text = CutsceneTextLines[CurrentCutSceneSeq];
                Text.text = wrapString(CutsceneTextLines[CurrentCutSceneSeq],30);
                
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
        catch
        {
            Application.LoadLevel(0);
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
    string wrapString(string msg, int width) {
        string[] words = msg.Split (" " [0]);
        string retVal = ""; //returning string
        string NLstr = "";  //leftover string on new line
        for (int index = 0 ; index < words.Length ; index++ ) {
            string word = words[index].Trim();
            //if word exceeds width
            if (words[index].Length >= width+2) {
                string[] temp = new string[5];
                int i = 0;
                while (words[index].Length > width) { //word exceeds width, cut it at widrh
                    temp[i] = words[index].Substring(0,width) +"\n"; //cut the word at width
                    words[index] = words[index].Substring(width);     //keep remaining word
                    i++;
                    if (words[index].Length <= width) { //the balance is smaller than width
                        temp[i] = words[index];
                        NLstr = temp[i];
                    }
                }
                retVal += "\n";
                for (int x = 0 ; x < i+1 ; x++) { //loops through temp array
                    retVal = retVal+temp[x];
                }
            }
            else if (index == 0) {
                retVal = words[0];
                NLstr = retVal;
            }
            else if (index > 0) {
                if (NLstr.Length + words[index].Length <= width ) {
                    retVal = retVal+" "+words[index];
                    NLstr = NLstr+" "+words[index]; //add the current line length
                }
                else if (NLstr.Length + words[index].Length > width) {
                    retVal = retVal+ "\n" + words[index];
                    NLstr = words[index]; //reset the line length
                }
            }
        }
        return retVal;
    }
    void PlayVideo()
    {
	 	// img1 = Resources.Load<Sprite>();
	 	// MyImage.GetComponent<GUITexture>().texture = Resources.Load("Images/" + CutsceneVideoLines[CurrentCutSceneSeq]) as Texture2D;;
        if (CurrentTex == 0)
        {
            MyImage.GetComponent<GUITexture>().texture = tex1;
        }
        if (CurrentTex == 1)
        {
            MyImage.GetComponent<GUITexture>().texture = tex2;
        }
        if (CurrentTex == 2)
        {
            MyImage.GetComponent<GUITexture>().texture = tex3;
        }
        if (CurrentTex == 3)
        {
            MyImage.GetComponent<GUITexture>().texture = tex4;
        }
        if (CurrentTex == 4)
        {
            MyImage.GetComponent<GUITexture>().texture = tex5;
        }
        if (CurrentTex == 5)
        {
            MyImage.GetComponent<GUITexture>().texture = tex6;
        }
        if (CurrentTex == 6)
        {
            MyImage.GetComponent<GUITexture>().texture = tex7;
        }
        if (CurrentTex == 7)
        {
            MyImage.GetComponent<GUITexture>().texture = tex8;
        }
        if (CurrentTex == 8)
        {
            MyImage.GetComponent<GUITexture>().texture = tex9;
        }
        if (CurrentTex == 9)
        {
            MyImage.GetComponent<GUITexture>().texture = tex10;
        }
        if (CurrentTex == 10)
        {
            MyImage.GetComponent<GUITexture>().texture = tex11;
        }
        if (CurrentTex == 11)
        {
            MyImage.GetComponent<GUITexture>().texture = tex12;
        }
        if (CurrentTex == 12)
        {
            MyImage.GetComponent<GUITexture>().texture = tex13;
        }
        CurrentTex = CurrentTex +1;

    }
    void EndCutScene()
    {
        Application.LoadLevel(0);
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

string songs = @"|JingleBells|0|Information about cutscene goes here||||
|JingleBells|0|winter-1391617_1920||JingleBells|||
|JingleBells|2|winter-1391617_1920|Dashing through the snow, In a one horse open sleigh, Over the fields we go, Laughing all the way, Bells on bobtails ring, Making spirits bright, What fun it is to ride and sing, A sleighing song tonight!||||
|JingleBells|19|jungle-3902531_1920|Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh, hey! Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh!|||
|JingleBells|35|sleigh-ride-549727_1920|A day or two ago, I thought Id take a ride, And soon, Miss Fanny Bright, Was seated by my side, The horse was lean and lank, Misfortune seemed his lot, He got into a drifted bank, And then we got upsot!||||
|JingleBells|50|winter-1060531_1920|Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh, hey! Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh!||||
|JingleBells|67|midnight-snow-1915907_1920|A day or two ago, The story I must tell, I went out on the snow, And on my back I fell; A gent was riding by, In a one horse open sleigh, He laughed as there I sprawling lie, But quickly drove away!||||
|JingleBells|82|bag-21467_1920|Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh, hey! Jingle bells, jingle bells, Jingle all the way, Oh, what fun it is to ride, In a one-horse open sleigh!|||
|JingleBells|99||||END||
|WeThreeKings|0|Information about cutscene goes here||||
|WeThreeKings|0|magi-3795282_1920||WeThreeKings|||
|WeThreeKings|21|starry-night-1082060|We Three Kings of Orient are, Bearing gifts we traverse afar, Field and fountain, Moor and mountain, Following yonder Star.||||
|WeThreeKings|40|switzerland-2051443_1920|O Star of Wonder, Star of Night, Star with Royal Beauty bright, Westward leading, Still proceeding, Guide us to Thy perfect Light.||||
|WeThreeKings|61|star-1099846_1920|Born a King on Bethlehem plain, Gold I bring to crown Him again, King for ever, Ceasing never, Over us all to reign.||||
|WeThreeKings|79|switzerland-2051443_1920|O Star of Wonder, Star of Night, Star with Royal Beauty bright, Westward leading, Still proceeding, Guide us to Thy perfect Light.||||
|WeThreeKings|99|christmas-1125147_1920|Frankincense to offer have I, Incense owns a Deity nigh: Prayer and praising, All men raising, Worship Him God on High.||||
|WeThreeKings|118|switzerland-2051443_1920|O Star of Wonder, Star of Night, Star with Royal Beauty bright, Westward leading, Still proceeding, Guide us to Thy perfect Light.||||
|WeThreeKings|138|advent-80125_1920|Myrrh is mine; its bitter perfume, Breathes a life of gathering gloom; Sorrowing, sighing, Bleeding, dying, Sealed in the stone cold tomb.||||
|WeThreeKings|156|switzerland-2051443_1920|O Star of Wonder, Star of Night, Star with Royal Beauty bright, Westward leading, Still proceeding, Guide us to Thy perfect Light.||||
|WeThreeKings|177|christmas-baubles-1078996_1920|Glorious now behold Him arise, King, and God, and Sacrifice; Heaven sings Hallelujah: Hallelujah the earth replies.||||
|WeThreeKings|196|switzerland-2051443_1920|O Star of Wonder, Star of Night, Star with Royal Beauty bright, Westward leading, Still proceeding, Guide us to Thy perfect Light.||||
|WeThreeKings|216|we-three-kings-photo|||||
|WeThreeKings|220||||END||
|AuldLangSyne|0|Information about cutscene goes here||||
|AuldLangSyne|0|new-years-eve-1953253_1920|Should auld acquaintance be forgot, And never brought to mind? Should auld acquaintance be forgot, And auld lang syne!|AuldLangSyne|||
|AuldLangSyne|28|fireworks-574739_1920|For auld lang syne, my dear, For auld lang syne.  Well tak a cup o kindness yet, For auld lang syne. ||||
|AuldLangSyne|64||||END||
|WeWishYou|0|Information about cutscene goes here||||
|WeWishYou|0|decoration-4713177_1920|We wish you a Merry Christmas, We wish you a Merry Christmas, We wish you a Merry Christmas, And a Happy New Year.|WeWishYou|||
|WeWishYou|63|christmas-bauble-1869989_1920|Good tidings to you, And all of your kin, Good tidings for Christmas, And a Happy New Year.||||
|WeWishYou|72|snowflakes-3971461_1920|We wish you a Merry Christmas, We wish you a Merry Christmas, We wish you a Merry Christmas, And a Happy New Year.||||
|WeWishYou|91|snowman-321034_1920|Good tidings to you, And all of your kin, Good tidings for Christmas, And a Happy New Year.||||
|WeWishYou|100|lichterkette-3834926_1920|We wish you a Merry Christmas, We wish you a Merry Christmas, We wish you a Merry Christmas, And a Happy New Year.||||
|WeWishYou|118|bank-2547356_1920|Good tidings to you, And all of your kin, Good tidings for Christmas, And a Happy New Year.||||
|WeWishYou|130|christmas-1125147_1920|||||
|WeWishYou|133||||END||
|SilentNight|0|Information about cutscene goes here||||
|SilentNight|0|winter-69927_1920||SilentNight|||
|SilentNight|11|winter-1732882_1920|Silent night, holy night. All is calm, all is bright. Round yon virgin Mother and Child. Holy infant so tender and mild, Sleep in heavenly peace, Sleep in heavenly peace||||
|SilentNight|69|cabin-2972634_1920|Silent night, holy night! Shepherds quake at the sight! Glories stream from heaven afar; Heavenly hosts sing Alleluia! Christ the Savior is born! Christ the Savior is born!||||
|SilentNight|127||||END||
|AngelsWeHaveHeard|0|Information about cutscene goes here||||
|AngelsWeHaveHeard|0|christmas-3840264_1920|Angels we have heard on high, Sweetly singing over the plains, And the mountains in reply, Echoing their joyous strains, Gloria in excelsis Deo!, Gloria in excelsis Deo!|AngelsWeHaveHeard|||
|AngelsWeHaveHeard|70|christmas-angel-4649685_1920|Shepherds, why this jubilee? Why your joyous strains prolong? What the gladsome tidings be? Which inspire your heavenly songs? Gloria in excelsis Deo! Gloria in excelsis Deo!||||
|AngelsWeHaveHeard|137|christmas-3866265_1920|||||
|AngelsWeHaveHeard|144||||END||";
			string[] lines = songs.Split('\n');

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
