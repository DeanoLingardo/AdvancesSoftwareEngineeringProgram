using System;

public class LoopUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.Loop) && shape.Equals(ShapeType.Square);
    }

    public void DoSomething()
    {
        throw new NotImplementedException();
    }
}