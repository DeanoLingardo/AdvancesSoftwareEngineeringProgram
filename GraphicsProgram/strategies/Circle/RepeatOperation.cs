using System;

public class RepeatOperation : IUserOperationStrategy
{ 
	public bool AppliesTo(string userOperationType, string shape)
	{
        return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Circle);
	}

    public void DoSomething()
    {
        throw new NotImplementedException();
    }
}
