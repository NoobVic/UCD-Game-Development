using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text HpValue;
	public Slider Hp;
	public GameObject gameOver;
	public GameObject gameStart;
	public Button ReStart;
	public Button StartNormal;
	public Button StartEndless;
	public Button ReturnBtn;
	public Text questionShow;
	public Text ShotNum;
	public Text SuccessNum;
	public Text FailNum;
	public Text LeftTime;
	public GameObject LeftTimeObj;
	public GameObject HpObj;
	public GameObject ChooseObj;
	public GameObject StartEndlessObj;
	public Button EasyBtn;
	public Button HardBtn;
	public GameObject NormalObj;
	public GameObject StartNormalObj;
	public Button PlusBtn;
	public Button MinusBtn;
	public Button MulBtn;
	public Button DivBtn;
	public Text HintDes;
	public GameObject HintObj;

    public Joystick Joystick;

    GameController GameController = GameController.getInstance();
	
	private static UIManager instance = new UIManager();
	private UIManager(){}

	void Start(){
		instance.Hp = Hp;
		instance.HpValue = HpValue;
		instance.GameController = GameController;
		instance.gameOver = gameOver;
		instance.gameStart = gameStart;
		ReStart.onClick.AddListener(ReturnHome);
		StartNormal.onClick.AddListener(StartNormalGame);
		StartEndless.onClick.AddListener(ChooseObjClick);
		ReturnBtn.onClick.AddListener(ReturnHome);
		instance.questionShow = questionShow;
		instance.ShotNum = ShotNum;
		instance.SuccessNum = SuccessNum;
		instance.FailNum = FailNum;
		instance.LeftTime = LeftTime;
		instance.LeftTimeObj = LeftTimeObj;
		instance.HpObj = HpObj;
		instance.ChooseObj = ChooseObj;
		instance.StartEndlessObj = StartEndlessObj;
		EasyBtn.onClick.AddListener(StartEndlessGame);
		HardBtn.onClick.AddListener(StartEndlessGameHard);
		instance.StartNormalObj = StartNormalObj;
		instance.NormalObj = NormalObj;
		PlusBtn.onClick.AddListener(StartPlusGame);
		MinusBtn.onClick.AddListener(StartMinusGame);
		MulBtn.onClick.AddListener(StartMulGame);
		DivBtn.onClick.AddListener(StartDivGame);
		instance.HintDes = HintDes;
		instance.HintObj = HintObj;
	}

    void Update()
    {
        GameController.Hori = Joystick.Horizontal;
        GameController.Verti = Joystick.Vertical;
    }

        public static UIManager getInstance(){
		return instance;
	}

	public void SetHpSlider(int hpValue){
		float hpSliderValue = (hpValue*1f)/(GameController.GetHp()*1f);
		instance.Hp.value = hpSliderValue;
		instance.HpValue.text = hpValue+"/"+GameController.GetHp();
	}

	public void SetShotNum(int ShotNum){
		instance.ShotNum.text = ShotNum.ToString();
	}

	public void SetSuccessNum(int SuccessNum){
		instance.SuccessNum.text = SuccessNum.ToString();
	}

	public void SetFailNum(int FailNum){
		instance.FailNum.text = FailNum.ToString();
	}
	public void SetHint(string hint){
		instance.HintDes.text = hint;
	}

	public void ReStartGame(){
		GameController.CreatTank();
	}

	public void StartNormalGame(){
		instance.StartNormalObj.gameObject.SetActive(false);
		instance.NormalObj.gameObject.SetActive(true);
	}

	public void StartPlusGame(){
		GameController.SetGameModel(0);
		GameController.CreatTank();
		instance.StartNormalObj.gameObject.SetActive(true);
		instance.NormalObj.gameObject.SetActive(false);
	}

	public void StartMinusGame(){
		GameController.SetGameModel(1);
		GameController.CreatTank();
		instance.StartNormalObj.gameObject.SetActive(true);
		instance.NormalObj.gameObject.SetActive(false);
	}

	public void StartMulGame(){
		GameController.SetGameModel(2);
		GameController.CreatTank();
		instance.StartNormalObj.gameObject.SetActive(true);
		instance.NormalObj.gameObject.SetActive(false);
	}

	public void StartDivGame(){
		GameController.SetGameModel(3);
		GameController.CreatTank();
		instance.StartNormalObj.gameObject.SetActive(true);
		instance.NormalObj.gameObject.SetActive(false);
	}

	public void StartEndlessGame(){
		GameController.SetGameModel(4);
		GameController.CreatTank();
		instance.StartEndlessObj.gameObject.SetActive(true);
		instance.ChooseObj.gameObject.SetActive(false);	
	}

	public void StartEndlessGameHard(){
		GameController.SetGameModel(5);
		GameController.CreatTank();
		instance.StartEndlessObj.gameObject.SetActive(true);
		instance.ChooseObj.gameObject.SetActive(false);
	}

	public void ChooseObjClick(){
		instance.StartEndlessObj.gameObject.SetActive(false);
		instance.ChooseObj.gameObject.SetActive(true);
	}


	public void ShowLeftTime(float leftTime){
		instance.LeftTime.text = leftTime.ToString();
	}

	public void ReturnHome(){
		GameController.SetGameState(1);
		instance.gameOver.gameObject.SetActive(false);
		instance.gameStart.gameObject.SetActive(true);
	}

	public void SetQuestionShow(string[] questionNumList){
		string question = " ";
		for (int i = 0; i < 4; i++)
		{
			if (i == 3)
			{
				question = string.Concat(question," = "+questionNumList[i]);
			}
			else{
				question = string.Concat(question," "+questionNumList[i]);
			}
		}
		instance.questionShow.text = question;
	}
}
