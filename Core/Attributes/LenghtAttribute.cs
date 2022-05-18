using System.ComponentModel.DataAnnotations;

namespace Customer.Core.Attributes
{
    public sealed class LenghtAttribute : ValidationAttribute
    {
        private readonly int _minLenghtValue;
        private readonly int _maxLenghtValue;

        public LenghtAttribute(int minLenghtValue, int maxLenghtValue)
        {
            _minLenghtValue = minLenghtValue;
            _maxLenghtValue = maxLenghtValue;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var valueLength = value.ToString().Length;

            return valueLength >= _minLenghtValue && valueLength <= _maxLenghtValue;
        }
    }
}
