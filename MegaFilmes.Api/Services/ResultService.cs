using FluentValidation.Results;
using MegaFilmes.Api.Services.Error;

namespace MegaFilmes.Api.Services;

public class ResultService
{
    public bool Success { get; set; } = true;
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }
    public int Status { get; set; }

    public static ICollection<ErrorValidation> CreateErrors(ValidationResult validationResult)
    {
        return validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList();
    }
    public static ResultService RequestError(string message,  ValidationResult validationResult)
    {
        return new ResultService
        {
            Success = false,
            Message = message,
            Status = 400,
            Errors = CreateErrors(validationResult)
        };
    }

    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
    {
        return new ResultService<T>
        {
            Success = false,
            Message = message,
            Status = 400,
            Errors = CreateErrors(validationResult)
        };
    }

    public static ResultService Fail(string message, int status = 404) => new ResultService { Success = false, Message = message, Status = status };
    public static ResultService<T> Fail<T>(string message, int status = 404) => new ResultService<T> { Success = false, Message = message, Status = status };

    public static ResultService Ok(string message, int status = 200) => new ResultService { Message = message, Success = true, Status = status };
    public static ResultService<T> Ok<T>(T data, int status = 200) => new ResultService<T> { Data = data, Success = true, Status = status };
}

public class ResultService<T> : ResultService
{
    public T Data { get; set; }
}
