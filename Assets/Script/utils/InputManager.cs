using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; } 
    
    public event Action onLeftArrowPressStarted;
    public event Action onLeftArrowPressCanceled;
    
    public event Action onRightArrowPressStarted;
    public event Action onRightArrowPressCanceled;
    
    public event Action onKeyQPressStarted;
    public event Action onKeyQPressCanceled;
    
    public event Action onKeyDPressStarted;
    public event Action onKeyDPressCanceled;
    
    public event Action onKeySpacePressStarted;
    
    public event Action onKeyIPressStarted;
    
    public event Action onMiddleMouseButtonPressStarted;
    public event Action onMiddleMouseButtonPressCanceled;
    
    public event Action onKeyFPressStarted;
    public event Action onKeyFPressCanceled;
    
    public event Action onKeyMPressStarted;
    public event Action onKeyMPressCanceled;

    public event Action<float> onMiddleMousseScroll;
    
    public event Action onLeftMouseButtonPressStarted;
    public event Action onLeftMouseButtonPressCanceled;
    
    public event Action onRightMouseButtonPressStarted;
    public event Action onRightMouseButtonPressCanceled;
    
    public event Action onEscapeButtonPressStarted;
    
    public event Action<Vector2> onMouseDelta;
    
    public event Action<Vector2> onMousePosition;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void OnMiddleMouseButtonPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onMiddleMouseButtonPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onMiddleMouseButtonPressCanceled?.Invoke();
        }
    }
    
    public void OnMiddleMouseScroll(InputAction.CallbackContext _context)
    {
        float _scrollValue = _context.ReadValue<Vector2>().y;
        onMiddleMousseScroll?.Invoke(_scrollValue);
    }
    
    public void OnLeftMouseButtonPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onLeftMouseButtonPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onLeftMouseButtonPressCanceled?.Invoke();
        }
    }
    
    public void OnRightMouseButtonPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onRightMouseButtonPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onRightMouseButtonPressCanceled?.Invoke();
        }
    }
    
    public void OnEscapeButtonPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onEscapeButtonPressStarted?.Invoke();
        }
    }

    public void OnKeyQPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        { 
            onKeyQPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onKeyQPressCanceled?.Invoke();
        }
    }
    
    public void OnKeyFPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        { 
            onKeyFPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onKeyFPressCanceled?.Invoke();
        }
    }
    
    public void OnKeyMPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        { 
            onKeyMPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onKeyMPressCanceled?.Invoke();
        }
    }

    public void OnKeyDPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onKeyDPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onKeyDPressCanceled?.Invoke();
        }
    }

    public void OnKeyIPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onKeyIPressStarted?.Invoke();
        }
    }

    public void OnRightArrowPressStarted(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onRightArrowPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onRightArrowPressCanceled?.Invoke();
        }
    }

    public void OnLeftArrowPressStarted(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onLeftArrowPressStarted?.Invoke();
        }
        else if (_context.canceled)
        {
            onLeftArrowPressCanceled?.Invoke();
        }
    }

    public void OnSpacePressStarted(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            onKeySpacePressStarted?.Invoke();
        }
    }
    
    public void OnMouseDelta(InputAction.CallbackContext _context)
    {
        onMouseDelta?.Invoke(_context.ReadValue<Vector2>());
    }
    
    public void OnMousePosition(InputAction.CallbackContext _context)
    {
        onMousePosition?.Invoke(_context.ReadValue<Vector2>());
    }
}
