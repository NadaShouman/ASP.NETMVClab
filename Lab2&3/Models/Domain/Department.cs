using System.Text.Json;

namespace Lab2.Models.Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        #region Initial List

        private static List<Department> _departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":"b3617127-2b58-438b-b5cc-ac3c3d9e5a21","Name":"Automotive \u0026 Baby"},{"Id":"5346da07-28c3-452a-815b-7b2731ff6146","Name":"Beauty \u0026 Health"},{"Id":"8c975e5d-6ec1-4930-8d46-f3ddd2ee076b","Name":"Electronics"}]""") ?? new();

        #endregion

        public static List<Department> GetDepartments() => _departments;

    }
}
