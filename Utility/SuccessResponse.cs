namespace OrderManagementSystem.Utility
{
    public class SuccessResponse
    {
        public bool success { get; set; }
        public dynamic data { get; set; }

        public SuccessResponse()
        {
            success = true;
        }

        public SuccessResponse(dynamic _data)
        {
            data = _data;
        }

        public SuccessResponse(bool _success, dynamic _data)
        {
            success = _success;
            data = _data;
        }
    }
}