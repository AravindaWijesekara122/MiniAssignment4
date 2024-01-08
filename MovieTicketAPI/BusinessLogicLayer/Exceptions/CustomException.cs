using System.Runtime.Serialization;

namespace BusinessLogicLayer.Exceptions
{
    [Serializable]
    internal class CustomException : Exception
    {
        public CustomException(string? message) : base(message)
        {
        }

    }
}