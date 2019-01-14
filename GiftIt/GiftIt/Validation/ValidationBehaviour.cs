using GiftIt.Validation.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace GiftIt.Validation
{
    public class ValidationBehavior : Behavior<View>
    {
        IErrorStyle _style = new BasicErrorStyle();
        View _view;
        public string PropertyName { get; set; }
        public bool IsValidated { get; set; } = false;
        public ObservableCollection<IValidationRule> Validators { get; set; } = new ObservableCollection<IValidationRule>();

        public bool Validate()
        {
            bool isValid = true;
            string errorMessage = "";

            foreach (IValidationRule validator in Validators)
            {
                bool result = validator.Check(_view.GetType()
                                       .GetProperty(PropertyName)
                                       .GetValue(_view) as string);
                isValid = isValid && result;
                
                if (!result)
                {
                    errorMessage = validator.ValidationMessage;
                    break;
                }                
            }

            if (!isValid)
            {
                _style.ShowError(_view, errorMessage);

                return false;
            }
            else
            {
                _style.RemoveError(_view);
                IsValidated = true;

                return true;
            }
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            _view = bindable as View;
            _view.PropertyChanged += OnPropertyChanged;
            _view.Unfocused += OnUnFocused;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            _view.PropertyChanged -= OnPropertyChanged;
            _view.Unfocused -= OnUnFocused;
        }
        void OnUnFocused(object sender, FocusEventArgs e)
        {
            Validate();
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName)
            {
                Validate();
            }
        }
    }
}
