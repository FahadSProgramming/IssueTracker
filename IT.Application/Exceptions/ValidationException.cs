using FluentValidation.Results;

namespace IT.Application.Exceptions {
    public class ValidationException : Exception {
     public ValidationException() : base("One or more validation failures occurred.") {
        }
        public ValidationException(string message): base(message) {
        }

        public ValidationException(List<ValidationFailure> failures)
            : this() {
            var propertyNames = failures.Select(f => f.PropertyName).Distinct();
            Failures = new Dictionary<string, string[]> ();

            foreach(var property in propertyNames) {

                 var propertyFailures = failures
                    .Where(e => e.PropertyName == property)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(property, propertyFailures);
            }
        }
        public IDictionary<string, string[]> Failures { get; private set; }   
    }
}