using System;

namespace OZE.AquariumApi.Exceptions {
    public class ExtractObjectIdException : Exception
    {
        public override string Message => "Exception during validate or parse object id from string";
    }
}
