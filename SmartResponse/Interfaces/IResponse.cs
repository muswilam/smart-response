﻿using FluentValidation.Results;
using SmartResponse.Enums;
using SmartResponse.Models;
using System;
using System.Collections.Generic;

namespace SmartResponse.Interfaces
{
    public interface IResponse<T> // where T : class
    {
        bool IsSuccess { get; }
        List<ErrorModel> Errors { get; }
        T Data { get; }

        IResponse<T> Finish();
        IResponse<T> Finish(T data);

        IResponse<T> Finish(List<ValidationFailure> inputValidations = null);

        IResponse<T> Finish(MessageCode code, string? fieldName = null, params string[] labels);
        IResponse<T> Finish<Error, Label>(string code, string? fieldName = null, params string[] labels);

        IResponse<T> Finish(Exception ex);

        IResponse<T> AppendError(ErrorModel error);
        IResponse<T> AppendErrors(List<ErrorModel> errors);

        IResponse<T> AppendError(MessageCode code, string? fieldName = null, params string[] labels);
        IResponse<T> AppendError<Error, Label>(string code, string? fieldName = null, params string[] labels);

        IResponse<T> AppendError(ValidationFailure error);
        IResponse<T> AppendErrors(List<ValidationFailure> errors);
    }
}