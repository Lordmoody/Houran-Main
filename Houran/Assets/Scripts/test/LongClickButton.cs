using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField]
	private float requiredHoldTime;

	public UnityEvent onLongClick;

	[SerializeField]
	private Image fillImage;
    public static bool timePassed = false;
	void Awake(){
		timePassed = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        timePassed = false;
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
                timePassed = true;
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
			fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
		}
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
		fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}

}
