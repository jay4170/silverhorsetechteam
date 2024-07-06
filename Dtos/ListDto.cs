    namespace silverhorse.Dtos
{
    public class ListResponseDto<T>
    {
        public List<T> List { get; set; }
        public int TotalNumOfRows { get; set; } = 0;
    }
}
