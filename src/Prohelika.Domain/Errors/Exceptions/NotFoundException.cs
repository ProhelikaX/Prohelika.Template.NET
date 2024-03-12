namespace Prohelika.Domain.Errors.Exceptions;

public class NotFoundException(string? message = default) : Exception(message??"Entity not found");