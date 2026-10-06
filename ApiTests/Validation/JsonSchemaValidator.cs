using System.Text.Json;
using Json.Schema;

namespace ApiTests.Validation;

public sealed class JsonSchemaValidator
{
    private static readonly EvaluationOptions Options = new() { OutputFormat = OutputFormat.List };
    private readonly JsonSchema _schema;

    public JsonSchemaValidator(string schemaFileName)
    {
        string schemaPath = Path.Combine(AppContext.BaseDirectory, "Schemas", schemaFileName);
        _schema = JsonSchema.FromFile(schemaPath);
    }

    public SchemaValidationResult Validate(string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        EvaluationResults results = _schema.Evaluate(document.RootElement, Options);

        List<string> errors = (results.Details ?? [])
            .Prepend(results)
            .Where(node => node.Errors is not null)
            .SelectMany(node => node.Errors!.Values)
            .ToList();

        return new SchemaValidationResult(results.IsValid, errors);
    }
}
