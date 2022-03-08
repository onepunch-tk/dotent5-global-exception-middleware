using System;
using System.Globalization;

namespace Server.API.ExceptionHelpers
{

    /// <summary>
    /// 사용자 정의 Exception
    /// </summary>
    public class CustomAppExeption : Exception
    {
        public CustomAppExeption() : base(){ }
        public CustomAppExeption(string message) : base(message) { }

        public CustomAppExeption(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
