using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SoundScript : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    public void OnSoundChange()
    {
        if (but.image.sprite == OnSprite)
        {
            but.image.sprite = OffSprite;
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().mute = true;
        }
        else
        {
            but.image.sprite = OnSprite;
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().mute = false;
        }
    }
}