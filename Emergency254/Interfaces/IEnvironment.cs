using System.Drawing;
using Emergency254.Models;

namespace Emergency254.Interfaces
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
