using System;

public interface IUserOperationStrategy
{
    bool AppliesTo(string userOperationType, string shape);
    void DoSomething();
}