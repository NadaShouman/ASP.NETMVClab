
using System.Text.Json;

namespace Lab2.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }

        public string Description { get; set; } = string.Empty;

        public Department? Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();



        #region Initial List

        private static List<Ticket> _developers = JsonSerializer.Deserialize<List<Ticket>>(
            """[{"Id":"33b26344-f25c-438a-968c-39a88a2e640a","Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.","IsClosed":false,"Severity":0,"Department":{"Id":"8c975e5d-6ec1-4930-8d46-f3ddd2ee076b","Name":"Electronics"},"Developers":[{"Id":"0b731ee0-a2a0-4120-8211-76b161f64535","FirstName":"Freddie","LastName":"Johnson"}]},{"Id":"1f85095b-2137-4c0b-b170-9dc5cb8008de","Description":"Qui voluptatem itaque ducimus quibusdam dolores vero sunt.","IsClosed":true,"Severity":0,"Department":{"Id":"b3617127-2b58-438b-b5cc-ac3c3d9e5a21","Name":"Automotive \u0026 Baby"},"Developers":[{"Id":"d9d44861-081b-4c33-a415-c3146b38aa5d","FirstName":"Geoffrey","LastName":"Abbott"},{"Id":"6001109e-314f-46dd-be5c-9703a1a4fb51","FirstName":"Sophia","LastName":"O\u0027Keefe"}]},{"Id":"2727d5ed-7064-42be-9f5e-f14ecf492997","Description":"Provident sed tenetur esse quidem debitis aut quisquam illum.","IsClosed":true,"Severity":0,"Department":{"Id":"8c975e5d-6ec1-4930-8d46-f3ddd2ee076b","Name":"Electronics"},"Developers":[{"Id":"dd56d068-ef7b-4226-91eb-35fb10aa2d6d","FirstName":"Angela","LastName":"McClure"},{"Id":"d9d44861-081b-4c33-a415-c3146b38aa5d","FirstName":"Geoffrey","LastName":"Abbott"}]},{"Id":"c768f414-08c6-42bc-9c28-1fc7085bc6b6","Description":"Ab atque alias et maiores dicta rerum officiis perferendis.","IsClosed":false,"Severity":2,"Department":{"Id":"b3617127-2b58-438b-b5cc-ac3c3d9e5a21","Name":"Automotive \u0026 Baby"},"Developers":[{"Id":"dd56d068-ef7b-4226-91eb-35fb10aa2d6d","FirstName":"Angela","LastName":"McClure"}]}]""") ?? new();

        #endregion

        public static List<Ticket> GetTickets() => _developers;

    }
}
