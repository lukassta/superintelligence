using UnityEngine;
using UnityEngine.EventSystems;

public class pipe : MonoBehaviour, IPointerClickHandler
{
    AudioSource audioData;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
