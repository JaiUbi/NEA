using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    GameObject[] myGameObjectArray;
    GameObject[] myGameObjectArray2;

    [Header("UI")] 
    public Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput; 
    public TMP_InputField emailRegInput;
    public TMP_InputField passwordRegInput;
    public TMP_InputField usernameRegInput;
    

    // Start is called before the first frame update
    void Start()
    {
        
        setObjectsActive();
        Login();
    }

    void setObjectsActive()
    {
        myGameObjectArray = GameObject.FindGameObjectsWithTag("LoginScreen");
          foreach (GameObject x in myGameObjectArray)
        {
            x.SetActive(true);

        }
        
        myGameObjectArray2 = GameObject.FindGameObjectsWithTag("RegisterScreen");
        foreach (GameObject y in myGameObjectArray2)
        {
            y.SetActive(false);

        }  
    }

    public void RegisterButton()
    {
        
        myGameObjectArray = GameObject.FindGameObjectsWithTag("LoginScreen");
        foreach (GameObject x in myGameObjectArray)
        {
            x.SetActive(false);

        }
        myGameObjectArray2 = GameObject.FindGameObjectsWithTag("RegisterScreen");
        foreach (GameObject y in myGameObjectArray2)
        {
            y.SetActive(true);

        }
    }
    
    public void onRegister()
    {
        
        if (passwordRegInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }
        if ((usernameRegInput.text.Length < 3) && (usernameRegInput.text.Length > 20))
        {
            messageText.text = "Username must be between 3 and 20 characters!";
            return;

        }

        var regrequest = new RegisterPlayFabUserRequest()
        {
            Username = usernameRegInput.text,
            Email = emailRegInput.text,
            Password = passwordRegInput.text,
            RequireBothUsernameAndEmail = true
            
            
        };

       
        

        PlayFabClientAPI.RegisterPlayFabUser(regrequest, OnRegisterSuccess, OnError);
        
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";


    }
    
    
    
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest()
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    }

    public void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful login");
        
      
        
    }
    
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest()
        {
            Email = emailInput.text,
            TitleId = "70A04"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset email sent!";
    }
    
    

    // Update is called once per frame
    void Login()
    {
        
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login");
    }


    void OnError(PlayFabError error)
    {
        Debug.Log("Error logging in");
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    
}
