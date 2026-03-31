using System;

namespace InputSystem
{
    public interface IDirectionInputHandler : IInputHandler
    {
        public event Action<InputDirection> DirectionPerformed;
    }
}