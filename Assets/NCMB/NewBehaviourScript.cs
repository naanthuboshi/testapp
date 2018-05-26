using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    private InputField inputField;
    private InputField inputFieldPassword;

    public GameObject InputFieldName;
    public GameObject LoginButton;
    public GameObject InputFieldPassword;
    public GameObject NewLoginButton;


    // Use this for initialization
    void Start()
    {
        inputField = InputFieldName.GetComponent<InputField>();
        inputFieldPassword = InputFieldPassword.GetComponent<InputField>();

    }
    /* public void InputLogger(){
        string inputValue = inputField.text;
        Debug.Log(inputValue);
        IniInputField();
        
    }
    void IntInputField(){
        inputField.text = "";
        inputFieldActivaInputField();
    }*/
    public void OnClick()
    {

        NCMBObject testClass = new NCMBObject("Login");


        testClass["Name"] = inputField.text;
        testClass["Password"] = inputFieldPassword.text;


        testClass.SaveAsync();

    }
    public void LoginClick()

    {
     //   string Name = testClass["Name"].ToString();
     //  string Password = testClass["Password"].ToString();

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Login");
        query.WhereEqualTo("Name", inputField.text);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //通信エラーが発生した
                UnityEngine.Debug.Log ("ログインできません " );
            }
            else
            {
                //通信に成功した
                if (objList.Count == 1)
                {

                    //データが一つの時
                    string Password = objList[0]["Password"].ToString();

                    if (Password == inputFieldPassword.text)
                    {
                        UnityEngine.Debug.Log("ログイン成功しました");
                    }

                    else
                    {

                        UnityEngine.Debug.Log("ログインに失敗しました");
                    }
                }

                else
                {
                    UnityEngine.Debug.Log("データが複数あります");
                }
            }
        });
    }






    // Update is called once per frame
    void Update()
    {


    }

}