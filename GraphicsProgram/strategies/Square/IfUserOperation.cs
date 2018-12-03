using System;

public class IfUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.If) && shape.Equals(ShapeType.Square);
    }

    public void DoSomething()
    {
        throw new NotImplementedException();
    }
}