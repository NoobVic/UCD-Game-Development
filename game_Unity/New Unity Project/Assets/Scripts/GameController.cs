using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int gameState;	// if 0, the game is running
	public int gameModel;	// Game modes: (0: Education +)  (1: -) (2: *) (3: /) (4: Challenge easy) (5: hard)
	public int Hp;
	public int HpValue;
	public GameObject Tank;
	public GameObject CurTank = null;
	UIManager uiManager = UIManager.getInstance();
	public string[] questionNumList = new string[4];
	public int[] questionTotalList = new int[4];
	public int[] modelHp = new int[6]{0,0,0,0,10,5};
	public string[] Hints = new string[4];
	public GameObject[] pointCubes = new GameObject[4];
	private int currentIndex;
	private int ShotNum;
	private int SuccessNum;
	private int FailNum;
	private int NormalQuestionCount = 0;
	private static GameController instance = new GameController();

	private GameController(){}

	void Start () {
		instance.gameState = 0;
		instance.Hp = 0;
		instance.gameModel = 0;
		instance.HpValue = 0;
		instance.Tank = Tank;
		instance.questionNumList = questionNumList;
		instance.questionTotalList = questionTotalList;
		instance.pointCubes = pointCubes;
		instance.currentIndex = currentIndex;
		instance.ShotNum = 0;
		instance.SuccessNum = 0;
		instance.FailNum = 0;
		instance.modelHp = modelHp;
		instance.Hints = Hints;
	}
	
	void Update () {
		
	}

	public static GameController getInstance(){
		return instance;
	}

	public void SetGameState( int gameState ){
		instance.gameState = gameState;
		if(gameState == 1){
			uiManager.gameOver.gameObject.SetActive(true);
		}
	}

	public void SetGameModel( int gameModel ){
		instance.gameModel = gameModel;
		if(instance.CheckNormalModel()){
			NormalQuestionCount = 0;
			uiManager.SetHint(instance.Hints[instance.gameModel]);
		}
		uiManager.HintObj.gameObject.SetActive(instance.CheckNormalModel());
		uiManager.LeftTimeObj.gameObject.SetActive(!instance.CheckNormalModel());
		uiManager.HpObj.gameObject.SetActive(!instance.CheckNormalModel());
	}

	// Check whether the current mode is NormalMode(Education mode in display)
	public bool CheckNormalModel( ){
		if(instance.gameModel < 4){
			return true;
		}
		else{
			return false;
		}
	}

	//SetUp the HP max
	public void SetHp( int Hp ){
		instance.Hp = Hp;
		instance.HpValue = Hp;
	}
	public int GetHp( ){
		return instance.Hp;
	}

	public void SetHpValue( int hpValue ){
		instance.HpValue = hpValue;
		uiManager.SetHpSlider(hpValue);
		if (hpValue<=0)
		{
			instance.SetGameState(1);
		}
	}

	public void SetShotCount( ){
		instance.ShotNum += 1;
		uiManager.SetShotNum(instance.ShotNum);
	}

	public void SetSuccessCount( ){
		instance.SuccessNum += 1;
		uiManager.SetSuccessNum(instance.SuccessNum);
	}

	public void SetFailCount( ){
		instance.FailNum += 1;
		uiManager.SetFailNum(instance.FailNum);
	}

	public void ReStart( ){
		instance.ShotNum = 0;
		instance.SuccessNum = 0;
		instance.FailNum = 0;
		uiManager.SetShotNum(instance.ShotNum);
		uiManager.SetSuccessNum(instance.SuccessNum);
		uiManager.SetFailNum(instance.FailNum);
	}

	public void CreatTank(){
		uiManager.gameOver.gameObject.SetActive(false);
		uiManager.gameStart.gameObject.SetActive(false);
		if (CurTank)
		{
			Destroy(CurTank.gameObject);
			CurTank = null;
		}
		GameObject clone;
		clone = (GameObject)Instantiate(instance.Tank);
		CurTank = clone;
		instance.SetGameState(0);
		if (!instance.CheckNormalModel())
		{
			instance.CreatQuestion();
		}
		else{
			instance.CreatNormalQuestion();
		}
		instance.ReStart();
		instance.SetHp(modelHp[instance.gameModel]);
		uiManager.SetHpSlider(modelHp[instance.gameModel]);
	}

	public void StartNormalGame(){
		uiManager.gameStart.gameObject.SetActive(false);
	}

	public void StartEndlessGame(){
		uiManager.gameStart.gameObject.SetActive(false);
	}

	public void CreatQuestion(){
        // create random question for challenge mode
		int firstNum = Random.Range(0,10);
		int secondNum = Random.Range(1,10);
		int Sign = Random.Range(0,2);
		int missNum = Random.Range(0,3);
		int finalNum = 0;
		finalNum = instance.GetFinalNum(Sign, firstNum, secondNum);
		instance.CreatQuestionNumList(firstNum, Sign, secondNum, finalNum, missNum);
	}

	public void CreatQuestion(int sign){
        // create question for education mode
		int firstNum = Random.Range(0,10);
		int secondNum = Random.Range(1,10);
		int Sign = sign;
		int missNum = Random.Range(0,3);
		if(missNum == 1){
			missNum = 3;
		}
		int finalNum = 0;
		finalNum = instance.GetFinalNum(Sign, firstNum, secondNum);
		instance.CreatQuestionNumList(firstNum, Sign, secondNum, finalNum, missNum);
	}

	public void CreatNormalQuestion(){
        // when it is the 10th question, end.
		if(NormalQuestionCount>8){
			instance.SetGameState(1);
			return;
		}
        // when it is division, use the same generator with multiplication
		if (instance.gameModel == 3)
		{
			instance.CreatQuestion(2);
		}
		else{
			instance.CreatQuestion(instance.gameModel);
		}
		NormalQuestionCount += 1;
	}

	public void CreatQuestionNumList(int firstNum, int Sign, int secondNum, int finalNum, int missNum){
		string[] SignList = new string[]{"+","-","*","/"};
		string[] questionList = new string[4];
		int[] questiontotalList = new int[4];
		int TempSign; // to distinguish Multi and Division
		if (instance.CheckNormalModel() )
		{
            // If it is multiplication, assign TempSign to 0
			if(instance.gameModel == 2){
				TempSign = 0;
			}
			else{
				TempSign = 1;
			}
		}
		else{
			TempSign = Random.Range(0,1);
		}
        // If to generate division quesiton
		if (Sign == 2 & TempSign == 1)
		{
			questionList[0] = finalNum.ToString();
			questiontotalList[0] = finalNum;
			questionList[1] = SignList[3];
			questiontotalList[1] = 3;
			questionList[2] = secondNum.ToString();
			questiontotalList[2] = secondNum;
			questionList[3] = firstNum.ToString();
			questiontotalList[3] = firstNum;
            // replace an random position with question mark
			questionList[missNum] = "?";
		}
        // other types
		else{
			questionList[0] = firstNum.ToString();
			questiontotalList[0] = firstNum;
			questionList[1] = SignList[Sign];
			questiontotalList[1] = Sign;
			questionList[2] = secondNum.ToString();
			questiontotalList[2] = secondNum;
			questionList[3] = finalNum.ToString();
			questiontotalList[3] = finalNum;
			questionList[missNum] = "?";
		}
		instance.questionNumList = questionList;
		instance.questionTotalList = questiontotalList;
		uiManager.SetQuestionShow(questionList);
		instance.CreatPointCubes(missNum);
	}

    // calculate solution for 2 given number and 1 given sign
	public int GetFinalNum(int Sign, int firstNum, int secondNum){
		int finalNum = 0;
		if ( Sign == 0){
			finalNum = firstNum + secondNum;
		}
		else if(Sign == 1){
			finalNum = firstNum - secondNum;
		}
		else if(Sign == 2){
			finalNum = firstNum * secondNum;
		}
		return finalNum;
	}
	public void CreatPointCubes(int missNum){
		string[] SignList = new string[]{"+","-","*","/"};
        // the postion of correct answer
		int TrueNum = Random.Range(0,3);
		instance.currentIndex = TrueNum;
        // use for generate wrong answer
		int Sign = Random.Range(0,3);
        // if the sign is missed
		if(missNum == 1){
			instance.currentIndex = instance.questionTotalList[missNum];
			for (int i = 0; i < 4; i++)
			{
				pointCube pointCube =  instance.pointCubes[i].transform.GetComponent<pointCube>();
				pointCube.SetPoint(SignList[i]);
			}
		}
		else{
			for (int i = 0; i < 4; i++)
			{
				int secondNum = Random.Range(1,10);
				pointCube pointCube =  instance.pointCubes[i].transform.GetComponent<pointCube>();
				if (i == TrueNum) // to put the correct solution
				{
					pointCube.SetPoint(instance.questionTotalList[missNum].ToString());
				}
				else{ //generate wrong answer
					int MisNum = instance.GetFinalNum(Sign, instance.questionTotalList[missNum], secondNum);
					if (MisNum == instance.questionTotalList[missNum])
					{
						MisNum += 2;
					}
					pointCube.SetPoint(MisNum.ToString());
				}
			}
		}
	}
    // check whether the answer is correct
	public bool CheckAnswer(int Index){
		if (instance.currentIndex == Index)
		{
			instance.SetSuccessCount();
			return true;
		}
		else{
			instance.SetFailCount();
			return false;
		}
	}

	public void ShowLeftTime(float leftTime){
		uiManager.ShowLeftTime(leftTime);
	}
}
