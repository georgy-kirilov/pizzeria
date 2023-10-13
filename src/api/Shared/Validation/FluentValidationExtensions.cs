using FluentValidation;

namespace Shared.Validation;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<TModel, TProperty> WithAlreadyExistsError<TModel, TProperty>(
        this IRuleBuilderOptions<TModel, TProperty> ruleBuilderOptions) =>
        ruleBuilderOptions
        .WithErrorCode("AlreadyExists")
        .WithMessage("'{PropertyName}' already exists.");

    public static IRuleBuilderOptions<TModel, TProperty> WithDoesNotExistError<TModel, TProperty>(
        this IRuleBuilderOptions<TModel, TProperty> ruleBuilderOptions) =>
        ruleBuilderOptions
        .WithErrorCode("DoesNotExist")
        .WithMessage("'{PropertyName}' does not exist.");
}
