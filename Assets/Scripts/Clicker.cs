using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using TMPro;

public class Clicker : MonoBehaviour
{
	public GUISkin UISkin;
	public int helper;
	public int betterhelper;
	public int superhelper;
	public int megahelper;
	public AudioClip clicksound;
	public AudioClip shopsound;
	public AudioClip closesound;
	public AudioClip musicsound;
	public TMP_Text twitText;
	public Text scoreText;
	public Text multiText;
	public TMP_Text userNameText;
	public Text replyCounter;
	public Text likeCounter;
	public Text replyCounterSaver;
	public Text likeCounterSaver;
	public TMP_Text saverTwitText;
	public string[] saverTwitContent;
	public GameObject shopPanel;
	public GameObject resetPanel;
	public GameObject quitPanel;
	public GameObject thingToClick;
	public GameObject userAvatar;
	public Sprite[] lolNFTs;
	public string[] userNames;
	public string[] dumbTwits;
	private int score;
	private int multiplier;
	private bool isshop;
	private bool music = true;
	private bool isreset;
	private bool isquit;
	private string emojiStore;

	void Awake()
	{
		emojiStore = "😀😃😄😁😆😅😂🤣😊😉😍😋😎☹";
		emojiStore = emojiStore + "";

		Screen.SetResolution (1280, 720, false);

		shopPanel.SetActive(false);
		resetPanel.SetActive(false);
		quitPanel.SetActive(false);

		replyCounter.text = Random.Range(1, 99).ToString() + "K";
		likeCounter.text = Random.Range(1, 420).ToString();
		replyCounterSaver.text = Random.Range(100, 666).ToString();
		likeCounterSaver.text = Random.Range(40, 999).ToString() + "K";

		twitText.text = "No ones dares right click save my new NFT.\nThey know I'm the real OG!😎";

		saverTwitText.text = "😀 Just saved and shared your PNG\nThanks for the new pfp kekw";

		var maxNames = userNames.Length;
		userNameText.text = userNames[Random.Range(0, maxNames)];

		var maxImages = lolNFTs.Length;
		thingToClick.GetComponent<Image>().sprite = lolNFTs[Random.Range(0, maxImages)];
		userAvatar.GetComponent<Image>().sprite = thingToClick.GetComponent<Image>().sprite;
	}

	void Update()
	{
		score = PlayerPrefs.GetInt ("score");
		multiplier = PlayerPrefs.GetInt ("multi");
		helper = PlayerPrefs.GetInt ("helper1");
		betterhelper = PlayerPrefs.GetInt ("helper2");
		superhelper = PlayerPrefs.GetInt ("helper3");
		megahelper = PlayerPrefs.GetInt ("helper4");

		scoreText.text = score.ToString();

		if (multiplier <= 0)
		{
			multiText.text = "500";
		}
		else
		{
			multiText.text = multiplier.ToString() + "K";
		}
	}

	public void DoAClick()
    {
		PlayerPrefs.SetInt("score", score + 1 + multiplier);
		GetComponent<AudioSource>().PlayOneShot(clicksound);

		var maxSaverTwits = saverTwitContent.Length;
		saverTwitText.text = "I just saved and shared your PNG\n" + saverTwitContent[Random.Range(0, maxSaverTwits)];

		var maxTwits = dumbTwits.Length;
		twitText.text = dumbTwits[Random.Range(0, maxTwits)];

		var maxNames = userNames.Length;
		userNameText.text = userNames[Random.Range(0, maxNames)];

		var maxImages = lolNFTs.Length;
		thingToClick.GetComponent<Image>().sprite = lolNFTs[Random.Range(0, maxImages)];
		userAvatar.GetComponent<Image>().sprite = thingToClick.GetComponent<Image>().sprite;

		replyCounter.text = Random.Range(1, 99).ToString() + "K";
		likeCounter.text = Random.Range(1, 420).ToString();

		replyCounterSaver.text = Random.Range(100, 666).ToString();
		likeCounterSaver.text = Random.Range(40, 999).ToString() + "K";
	}

	public void DoShop()
    {
		if (isshop)
		{
			isshop = false;
			GetComponent<AudioSource>().PlayOneShot(closesound);
			shopPanel.SetActive(false);
		}
		else if(!isshop)
        {
			isshop = true;
			GetComponent<AudioSource>().PlayOneShot(closesound);
			shopPanel.SetActive(true);
		}
	}

	public void HelperOne()
    {
		if(score >= 100)
		{
			PlayerPrefs.SetInt("multi", multiplier + 1);
			PlayerPrefs.SetInt("score", score - 100);
			PlayerPrefs.SetInt("helper1", helper + 1);
			GetComponent<AudioSource>().PlayOneShot(shopsound);
		}
	}

	public void HelperTwo()
	{
		if(score >= 300)
        {
			PlayerPrefs.SetInt("multi", multiplier + 5);
			PlayerPrefs.SetInt("score", score - 300);
			PlayerPrefs.SetInt("helper2", betterhelper + 1);
			GetComponent<AudioSource>().PlayOneShot(shopsound);
		}
	}

	public void HelperThree()
	{
		if(score >= 1000)
        {
			PlayerPrefs.SetInt("multi", multiplier + 20);
			PlayerPrefs.SetInt("score", score - 1000);
			PlayerPrefs.SetInt("helper3", superhelper + 1);
			GetComponent<AudioSource>().PlayOneShot(shopsound);
		}
	}

	public void HelperFour()
	{
		if(score >= 10000)
        {
			PlayerPrefs.SetInt("multi", multiplier + 100);
			PlayerPrefs.SetInt("score", score - 10000);
			PlayerPrefs.SetInt("helper4", megahelper + 1);
			GetComponent<AudioSource>().PlayOneShot(shopsound);
		}
	}

	public void MusicOnOff()
	{
		if (music == false)
		{
			GetComponent<AudioSource>().PlayOneShot(musicsound);
			music = true;

		}
		else if (music == true)
		{
			music = false;
			GetComponent<AudioSource>().Stop();
		}
	}

	public void Mute()
    {
		if (GetComponent<AudioSource>().mute == true)
		{
			GetComponent<AudioSource>().mute = false;
		}
		else if (GetComponent<AudioSource>().mute == false)
		{
			GetComponent<AudioSource>().mute = true;
		}
	}

	public void ResetConfirm()
    {
        if (!isreset)
        {
			resetPanel.SetActive(true);
			isreset = true;
		}
		else if (isreset)
        {
			resetPanel.SetActive(false);
			isreset = false;
		}
    }

	public void ResetScores()
	{
		PlayerPrefs.DeleteAll();
		resetPanel.SetActive(false);
		isreset = false;
	}

	public void QuitConfirm()
	{
		if (!isquit)
		{
			quitPanel.SetActive(true);
			isquit = true;
		}
		else if (isquit)
		{
			quitPanel.SetActive(false);
			isquit = false;
		}
	}

	public void DoQuit()
	{
		Application.Quit();
	}

	public void QuitCancel()
    {
		quitPanel.SetActive(false);
		isquit = false;
	}
}