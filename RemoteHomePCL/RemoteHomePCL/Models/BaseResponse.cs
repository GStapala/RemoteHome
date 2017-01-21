namespace RemoteHomePCL.Models
{
    public class BaseResponse<T>
    {
        /// <summary>
        ///     true - response passed
        ///     false - something wrong
        /// </summary>
        public bool AnyErrors => !string.IsNullOrEmpty(ErrorMessage);

        public string ErrorMessage { get; set; }
        public T ObjectReturn { get; set; }
    }
}