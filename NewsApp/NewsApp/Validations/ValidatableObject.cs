using NewsApp.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace NewsApp.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        private readonly List<IValidationRule<T>> validations;
        private List<string> errors;
        private T value;
        private bool isValid;

        public List<IValidationRule<T>> Validations => validations;

        public List<string> Errors
        {
            get
            {
                return errors;
            }
            set
            {
                errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get { return isValid; }
            set
            {
                isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public ValidatableObject()
        {
            isValid = true;
            errors = new List<string>();
            validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = validations.Where(v => !v.Check(Value))
                                                    .Select(v => v.ValidationMessage);

            foreach (var error in errors)
            {
                Errors.Add(error);
            }

            IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
