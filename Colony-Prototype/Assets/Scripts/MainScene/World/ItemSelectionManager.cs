using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelectionManager : MonoBehaviour {
    private static ItemSelectionManager _instance;

    public static ItemSelectionManager instance {
        get { return _instance; }
    }

    public static bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current) {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    private GameObject currentObject;

    public ItemSelectionManager() {
        _instance = this;
    }

    private Dictionary<string, List<ClickableHandler>> handlers = new Dictionary<string, List<ClickableHandler>>();
    private List<ClickableHandler> globalHandlers = new List<ClickableHandler>();
    void Start() { }

    void Update() {
       if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject()) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Clickable")) {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Has clickeado en: " + clickedObject.name);
                if (currentObject != null) TellUnselect(currentObject);
                currentObject = clickedObject;
                TellClick(currentObject, currentObject);

            } else {
                if (currentObject != null) TellUnselect(currentObject);
                currentObject = null;
            }
        }
    }

    private void TellClick(GameObject clickedObject, GameObject target) {
        ExecuteEvents.Execute<ClickableHandler>(target, null, (x, y) => x.OnSelect(clickedObject));

        Clickable clickable = clickedObject.GetComponent<Clickable>();
        if (handlers.ContainsKey(clickable.type)) {
            List<ClickableHandler> handlerLists = handlers[clickable.type];
            handlerLists.ForEach(delegate(ClickableHandler handler) {
                handler.OnSelect(target);
            });
        }
        globalHandlers.ForEach(delegate(ClickableHandler handler) {
            handler.OnSelect(target);
        });
    }

    private void TellUnselect(GameObject target) {
        ExecuteEvents.Execute<ClickableHandler>(target, null, (x, y) => x.OnUnselect(target));
        
        Clickable clickable = target.GetComponent<Clickable>();
        if (handlers.ContainsKey(clickable.type)) {       
            List<ClickableHandler> handlerLists = handlers[clickable.type];
            handlerLists.ForEach(delegate(ClickableHandler handler) {
                handler.OnUnselect(target);
            });
        }
        globalHandlers.ForEach(delegate(ClickableHandler handler) {
            handler.OnUnselect(target);
        });
    }


    public void Subscribe(string clickableType, ClickableHandler handler) {
        if (!handlers.ContainsKey(clickableType)) handlers.Add(clickableType, new List<ClickableHandler>());
        List<ClickableHandler> list = handlers[clickableType];
        list.Add(handler);
    }

    public void Subscribe(ClickableHandler handler) {
        globalHandlers.Add(handler);
    }
}
