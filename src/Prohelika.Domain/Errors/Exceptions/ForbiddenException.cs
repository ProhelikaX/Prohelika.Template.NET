namespace Prohelika.Domain.Errors.Exceptions;

public class ForbiddenException(string? message = default) : Exception(message);