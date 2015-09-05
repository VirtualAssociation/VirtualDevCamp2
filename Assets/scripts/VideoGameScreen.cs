using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class VideoGameScreen : MonoBehaviour {

	public Sprite CorridorImage;
	public Sprite ElevatorImage;
	public Sprite LittleGirlImage;
	public Sprite MonsterImage;
	public Sprite BansheeImage;
	public Sprite DoorImage;

	public float InitialScreenDuration = 2.0f;
	public float Acceleration = 0.01f;
	private float _currentTime;
	private float _currentScreenDuration;

	private VideoGameScreenEnum _currentVideoScreenView;
	private Sprite[] _sprites;
	private int _currentImageIndex;
	private Image _currentImage;

	private Dictionary<VideoGameScreenEnum, Dictionary<GameActionEnum, int>> _actionsValues;

	// Use this for initialization
	void Start ()
	{
		_currentVideoScreenView = VideoGameScreenEnum.VGS_CORRIDOR;

		_sprites = new Sprite[6];
		_sprites [0] = CorridorImage;
		_sprites [1] = ElevatorImage;
		_sprites [2] = LittleGirlImage;
		_sprites [3] = MonsterImage;
		_sprites [4] = BansheeImage;
		_sprites [5] = DoorImage;
		_currentImageIndex = 0;
		_currentImage = GetComponent<Image> ();
		UpdateCurrentImage ();

		SetupActionsValues ();

		_currentTime = 0.0f;
		_currentScreenDuration = InitialScreenDuration;
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
	
		if (Time.time - _currentTime > _currentScreenDuration) {

			int newIndex = _currentImageIndex;
			do {
				newIndex = (int)(Mathf.Floor(Random.Range(0.0f, 5.999f)));
			}
			while(newIndex == _currentImageIndex);
			_currentImageIndex = newIndex;
			UpdateCurrentImage ();
			_currentTime = Time.time;
			_currentScreenDuration = InitialScreenDuration - Time.time / 60.0f * Acceleration; // Fixé pour une durée de 2min.
			Debug.Log (_currentScreenDuration);
		}
			

	}

	void UpdateCurrentImage()
	{
		_currentImage.sprite = _sprites[_currentImageIndex];
	}


}
