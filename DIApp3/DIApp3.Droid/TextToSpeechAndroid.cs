using System.Collections.Generic;
using Android.Runtime;
using Android.Speech.Tts;
using Xamarin.Forms;
using DIApp3.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechAndroid))]
namespace DIApp3.Droid
{
  public class TextToSpeechAndroid : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
  {
    TextToSpeech speaker;
    string toSpeak;

    public TextToSpeechAndroid() { }

    public void OnInit([GeneratedEnum] OperationResult status)
    {
      if (status.Equals(OperationResult.Success))
      {
        var p = new Dictionary<string, string>();
        speaker.Speak(toSpeak, QueueMode.Flush, p);
      }
    }

    public void Speak(string text)
    {
      var ctx = Forms.Context; // useful for many Android SDK features
      toSpeak = text;
      if (speaker == null)
      {
        speaker = new TextToSpeech(ctx, this);
      }
      else
      {
        var p = new Dictionary<string, string>();
        speaker.Speak(toSpeak, QueueMode.Flush, p);
      }
    }
  }
}