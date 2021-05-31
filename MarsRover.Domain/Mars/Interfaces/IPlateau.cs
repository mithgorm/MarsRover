
namespace MarsRover.Domain.Mars.Interfaces
{
    public interface IPlateau
    {
        void Define(int width, int height);

        int Height();

        int Width();
    }
}
