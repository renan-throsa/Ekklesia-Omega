using FluentValidation.Results;
using System.Net;

namespace Ekklesia.Application.Models
{
    public class OperationResultModel
    {
        public object Content { get; set; }
        public ValidationResult Result { get; set; }
        public bool IsValid => Result?.IsValid ?? true;
        public HttpStatusCode StatusCode { get; set; }

        public OperationResultModel()
        {

        }
        public OperationResultModel(ValidationResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public OperationResultModel(ValidationResult result) => Result = result;

        public OperationResultModel(object content) => Content = content;
    }
}
