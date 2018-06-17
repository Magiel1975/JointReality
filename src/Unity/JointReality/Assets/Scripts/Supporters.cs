using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class Supporters : Singleton<Supporters>
{

    private TextToSpeech textToSpeech;
    List<SupportingText> supportingText = new List<SupportingText>();
    // Use this for initialization
    void Start()
    {
        textToSpeech = GetComponent<TextToSpeech>();
        InitializeSupportingText();
        SayWelcome();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.0001f && !textToSpeech.IsSpeaking())
        {
            textToSpeech.Voice = GetRandomVoice();
            textToSpeech.StartSpeaking(GetRandomSupportingText().Text);
        }
    }

    public void SayWelcome()
    {
        textToSpeech.Voice = GetRandomVoice();
        textToSpeech.StartSpeaking("Welcome to the Joints team experience. Your goal is to unlock the machine. We wich you luck!");
    }

    public void SayWinner()
    {
        textToSpeech.Voice = GetRandomVoice();
        textToSpeech.StartSpeaking("You have completed this mission. Congratulaions! Are you ready for the next step ");
    }

    SupportingText GetRandomSupportingText()
    {
        var r = Random.Range(0, supportingText.Count);
        return supportingText[r];
    }
    void InitializeSupportingText()
    {
        supportingText.Add(new SupportingText("You are doing well!"));
        supportingText.Add(new SupportingText("Not so fast"));
        supportingText.Add(new SupportingText("You have to pickup the Key object, and unlock the device"));
        supportingText.Add(new SupportingText("Select the joints to operate the robot"));
        supportingText.Add(new SupportingText("Each joint can go back or foreward"));

    }
    TextToSpeechVoice GetRandomVoice()
    {
        var r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                return TextToSpeechVoice.David;
            case 1:
                return TextToSpeechVoice.Mark;
            case 2:
                return TextToSpeechVoice.Zira;
        }
        return TextToSpeechVoice.Default;
    }
    class SupportingText
    {
        public SupportingText(string text)
        {
            Text = text;

        }
        public string Text { get; set; }
        public TextToSpeechVoice Voice { get; set; }
    }

}
