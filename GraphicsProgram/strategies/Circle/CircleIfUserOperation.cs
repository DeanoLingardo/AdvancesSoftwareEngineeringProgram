using System.Drawing;
using System.Windows.Forms;

namespace GraphicsProgram.strategies.Circle
{
    public class CircleIfUserOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.If) && shape.Equals(ShapeType.Circle);
        }

        public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
        {
            MessageBox.Show("If statements are not coded yet.", "Uncomplete command", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}