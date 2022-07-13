using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FarmshareAdmin.Data
{
    /*
     * toList: converts model state errors to a plain c# structure
     * toModel: converts Data.Message list to model state errors
     */
    public class ModelErrorService
    {
        public class Error
        {
            public Error(string key, string message)
            {
                Key = key;
                Message = message;
            }

            public string Key { get; set; }
            public string Message { get; set; }
        }
        public List<Error> toList(ModelStateDictionary ModelState)
        {
            /*
             * Capture model errors to send to the client and display to the user
             */
            var errors = new List<Error>();
            var erroneousFields = ModelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new Error(fieldKey, error.ErrorMessage));
                errors.AddRange(fieldErrors);
            }
            return errors;
        }

        public static void toModel(List<Message> messages, ModelStateDictionary modelState)
        {
            foreach (var item in messages)
            {
                modelState.AddModelError("", item.content);
            }
        }
    }
}
