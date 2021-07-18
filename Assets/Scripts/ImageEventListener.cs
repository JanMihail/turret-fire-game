using UnityEngine;
using UnityEngine.EventSystems;

public class ImageEventListener : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
{
	public void OnBeginDrag(PointerEventData data)
	{
		Debug.Log("OnBeginDrag called.");
	}

	public void OnCancel(BaseEventData data)
	{
		Debug.Log("OnCancel called.");
	}

	public void OnDeselect(BaseEventData data)
	{
		Debug.Log("OnDeselect called.");
	}

	public void OnDrag(PointerEventData data)
	{
		Debug.Log("OnDrag called.");
	}

	public void OnDrop(PointerEventData data)
	{
		Debug.Log("OnDrop called.");
	}

	public void OnEndDrag(PointerEventData data)
	{
		Debug.Log("OnEndDrag called.");
	}

	public void OnInitializePotentialDrag(PointerEventData data)
	{
		Debug.Log("OnInitializePotentialDrag called.");
	}

	public void OnMove(AxisEventData data)
	{
		Debug.Log("OnMove called.");
	}

	public void OnPointerClick(PointerEventData data)
	{
		Debug.Log("OnPointerClick called.");
	}

	public void OnPointerDown(PointerEventData data)
	{
		Debug.Log("OnPointerDown called.");
	}

	public void OnPointerEnter(PointerEventData data)
	{
		Debug.Log("OnPointerEnter called.");
	}

	public void OnPointerExit(PointerEventData data)
	{
		Debug.Log("OnPointerExit called.");
	}

	public void OnPointerUp(PointerEventData data)
	{
		Debug.Log("OnPointerUp called.");
	}

	public void OnScroll(PointerEventData data)
	{
		Debug.Log("OnScroll called.");
	}

	public void OnSelect(BaseEventData data)
	{
		Debug.Log("OnSelect called.");
	}

	public void OnSubmit(BaseEventData data)
	{
		Debug.Log("OnSubmit called.");
	}

	public void OnUpdateSelected(BaseEventData data)
	{
		Debug.Log("OnUpdateSelected called.");
	}
}
