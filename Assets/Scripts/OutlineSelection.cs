using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private LayerMask pistolLayerMask;
    private LayerMask chocolateLayerMask;
    private LayerMask sodaLayerMask;
    public static bool pistolCheckbox = false;
    public static bool chocolateCheckbox = false;
    public static bool sodaCheckbox = false;

    void Start()
    {
        pistolLayerMask = LayerMask.GetMask("Pistol");
        chocolateLayerMask = LayerMask.GetMask("Chocolate");
        sodaLayerMask = LayerMask.GetMask("Soda");
    }

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            SetOutlineEnabled(highlight, false);
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = GetSelectableParent(raycastHit.transform);

            if (highlight != null && highlight != selection)
            {
                SetOutlineEnabled(highlight, true);
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                // Check if the selected object is under the "Objective" layer
                if (IsInPistolLayer(highlight) || IsInChocolateLayer(highlight) || IsInSodaLayer(highlight))
                {
                    if (IsInPistolLayer(highlight))
                    {
                        pistolCheckbox = true;
                    }
                    if (IsInChocolateLayer(highlight))
                    {
                        chocolateCheckbox = true;
                    }
                    if (IsInSodaLayer(highlight))
                    {
                        sodaCheckbox = true;
                    }
                    // Disable the GameObject
                    highlight.gameObject.SetActive(false);
                }

                if (selection != null)
                {
                    SetOutlineEnabled(selection, false);
                }

                selection = highlight;
                SetOutlineEnabled(selection, true);

                highlight = null;
            }
            else
            {
                if (selection)
                {
                    SetOutlineEnabled(selection, false);
                    selection = null;
                }
            }
        }
    }

    void SetOutlineEnabled(Transform obj, bool enable)
    {
        Outline outline = obj.gameObject.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = enable;
        }
        else if (enable)
        {
            outline = obj.gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 7.0f;
            outline.enabled = true;
        }
    }

    Transform GetSelectableParent(Transform child)
    {
        Transform current = child;
        while (current != null)
        {
            if (current.CompareTag("Selectable"))
            {
                return current;
            }
            current = current.parent;
        }
        return null;
    }

    bool IsInPistolLayer(Transform obj)
    {
        return ((1 << obj.gameObject.layer) & pistolLayerMask) != 0;
    }
    bool IsInChocolateLayer(Transform obj)
    {
        return ((1 << obj.gameObject.layer) & chocolateLayerMask) != 0;
    }
    bool IsInSodaLayer(Transform obj)
    {
        return ((1 << obj.gameObject.layer) & sodaLayerMask) != 0;
    }
}