using System;
using UnityEngine;
using UnityEngine.UI;

public class Magic8Ball : MonoBehaviour
{
    string[] phrases = new string[]
    {

        "As I see it, yes",
        "Ask again later",
         "Better not tell you now",
         "Cannot predict now",
         "Concentrate and ask again",
         "Don’t count on it",
         "It is certain",
         "It is decidedly so",
         "Most likely",
         "My reply is no",
         "My sources say no",
         "Outlook not so good",
         "Outlook good",
         "Reply hazy, try again",
         "Signs point to yes",
         "Very doubtful",
         "Without a doubt",
         "Yes",
         "Yes – definitely",
         "You may rely on it"
    };
    public Text phraseBox;
    public Button shakeButton;
    public Text attemptBox;
    public int attempts = 3;

    public void Start()
    {
        attemptBox.text = attempts.ToString();
    }
    public void Shake()
    {
        if (attempts >= 1)
        {
            attempts--;

            shakeButton.interactable = false;
            phraseBox.text = phrases.Random();
            attemptBox.text = attempts.ToString(); 

            var alphaFade = CurveFactory.Create(0f, 1f);
            var scaleFade = CurveFactory.Create(0.5f, 1f);

            Action<float> alphaTick = (t) => phraseBox.SetAlpha(alphaFade.Evaluate(t));
            Action<float> scaleTick = (t) => phraseBox.SetAlpha(scaleFade.Evaluate(t));

            StartCoroutine(CoroutineFactory.Create(1f, alphaTick + scaleTick, () => shakeButton.interactable = true));
            Debug.Log("Shaking Magic ball.");
        }
        else if (attempts == 0)
        {
            phraseBox.text = "Oops! Watch a video to earn more attempts";
            attemptBox.text = attempts.ToString();
            Debug.Log("No more attempts left");
        }
    }

    internal void rewardEarned()
    {
        //throw new NotImplementedException();
        attempts++;
        attemptBox.text = attempts.ToString();
    }


    //NEW for saving the game
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        attempts = data.attempts;
    }
}
