namespace SafetyBP.Domain.Entities
{
    public class SafetyCameraResponse
    {
        public bool CameraNotAvailable { get; set; }
        public bool PrivilegesNotGranted { get; set; }
        public string PathFile { get; set; }
        public string Content { get; set; }


        public SafetyCameraResponse()
        {
            CameraNotAvailable = false;
            PathFile = Content = string.Empty;
        }
        
    }
}
