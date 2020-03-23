using System;

namespace Products.Exceptions
{
    [Serializable]
    public class BlException : Exception
    {
        public BlException()
        {
        }

        public BlException(string message) : base(message)
        {
        }

        public BlException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}