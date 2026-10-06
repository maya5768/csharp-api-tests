namespace ApiTests.Validation;

public sealed record SchemaValidationResult(bool IsValid, IReadOnlyList<string> Errors);
