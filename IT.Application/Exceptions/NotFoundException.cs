namespace IT.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException(IT.Domain.Entity entity) : base($"An object of type '{nameof(entity)}' with ID '{entity.Id}' could not be found.") {
        }
        public NotFoundException(string message) : base(message) {
        }
    }
}