namespace Carhub.Lib.Exceptions;

public abstract class CarhubDomainException(string message)
    : Exception(message);