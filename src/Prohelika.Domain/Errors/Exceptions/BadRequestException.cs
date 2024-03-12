namespace Prohelika.Domain.Errors.Exceptions;

public class BadRequestException(string? message = default): Exception(message);