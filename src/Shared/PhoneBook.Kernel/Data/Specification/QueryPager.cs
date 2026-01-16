namespace PhoneBook.Kernel.Data.Specification
{
    public class QueryPager
    {
        private int pageNumber;
        private int pageSize;

        public int PageNumber
        {
            get => pageNumber;
            set
            {
                if (value < 0)
                    throw new ArgumentException("PageNumber can`t be less than 0");
                pageNumber = value;
            }
        }
        public int PageSize
        {
            get => pageSize;
            set
            {
                if (value < 0)
                    throw new ArgumentException("PageSize can`t be less than 0");

                pageSize = value;
            }
        }
        //public int TotalCount { get; internal set; }
    }


}
