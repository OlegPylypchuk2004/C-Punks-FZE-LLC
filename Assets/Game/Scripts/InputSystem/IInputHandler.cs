using System;

namespace InputSystem
{
    public interface IInputHandler
    {
        public event Action<InputDirection> Performed;
        
        public bool IsActive { get; set; }
    }
}