namespace BFS_DFS.Domain
{
    public class Truck
    {
        public Truck(double loadCapacity)
        {
            LoadCapacity = loadCapacity;
        }
        public Truck() { }

        public double LoadCapacity { get; set; }
    }
}
