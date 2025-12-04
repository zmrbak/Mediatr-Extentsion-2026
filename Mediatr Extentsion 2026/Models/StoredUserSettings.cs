using System.Collections.Generic;

namespace Mediatr_Extentsion_2026.Models
{
    public class StoredUserSettings
    {
        public string InputFileName { get; set; } = string.Empty;
        public List<string> Imports { get; set; } = new List<string>();
        public List<TypeNameModel> ConstructorParameters { get; set; } = new List<TypeNameModel>();

        public bool ShouldCreateFolder { get; set; }
        public bool ShouldCreateValidationFile { get; set; }
        public bool ShouldCreateAutomapperFile { get; set; }
        public bool OneFileStyle { get; set; }
        public bool OneClassStyle { get; set; }
    }
}
