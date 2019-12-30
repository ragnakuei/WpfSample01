using System;
using System.Windows.Markup;

namespace WpfSample01.Samples.K
{
    public class FilterStringConverterExtension : MarkupExtension {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return new FilterStringConverter();
        }
    }
}