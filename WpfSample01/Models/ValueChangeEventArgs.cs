namespace WpfSample01.Models
{
    public class ValueChangeEventArgs<T>
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
}