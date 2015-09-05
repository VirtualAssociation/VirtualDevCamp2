using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class VideoGameScreen : MonoBehaviour {

	public Image CorridorImage;
	public Image ElevatorImage;
	public Image LittleGirlImage;
	public Image MonsterImage;
	public Image BansheeImage;
	public Image DoorImage;

	public int StartingInterval = 3;

	private VideoGameScreenEnum _currentVideoScreenView;

	private Dictionary<VideoGameScreenEnum, Dictionary<GameActionEnum, int>> _actionsValues;

	// Use this for initialization
	void Start ()
	{
		_currentVideoScreenView = VideoGameScreenEnum.VGS_CORRIDOR;

		SetupActionsValues ();
	}

	void SetupActionsValues()
	{

		_actionsValues = new Dictionary<VideoGameScreenEnum, Dictionary<GameActionEnum, int>>();

		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] = new Dictionary<GameActionEnum, int>();
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] = new Dictionary<GameActionEnum, int>();
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] = new Dictionary<GameActionEnum, int>();
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] = new Dictionary<GameActionEnum, int>();
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] = new Dictionary<GameActionEnum, int>();
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] = new Dictionary<GameActionEnum, int>();

		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_CORRIDOR] [GameActionEnum.GA_CAT] = 0;
		
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_ELEVATOR] [GameActionEnum.GA_CAT] = 0;
		
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_MONSTER] [GameActionEnum.GA_CAT] = 0;
		
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_LITTLE_GIRL] [GameActionEnum.GA_CAT] = 0;
		
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_BANSHEE] [GameActionEnum.GA_CAT] = 0;
		
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_CHAIR] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_SCREAM] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_WHISPER] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_BOARD] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_CABLE] = 0;
		_actionsValues [VideoGameScreenEnum.VGS_DOOR] [GameActionEnum.GA_CAT] = 0;
	}

	// Update is called once per frame
	void Update () {
	

		int newIndex = (int)(Time.time / StartingInterval);
		Debug.Log (newIndex);

	}


}
