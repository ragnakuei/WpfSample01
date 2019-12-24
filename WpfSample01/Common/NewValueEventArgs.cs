using System;

namespace WpfSample01.Common
{
    public class NewValueEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
}