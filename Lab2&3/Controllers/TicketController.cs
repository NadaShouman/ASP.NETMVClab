using Microsoft.AspNetCore.Mvc;
using Lab2.Models.View;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using Lab2.Models.Domain;
using System.Net.Sockets;

namespace Lab2.Controllers
{
    public class TicketController : Controller
    {
        private static readonly List<Ticket> _tickets = Ticket.GetTickets();

        public IActionResult GetAll()
        {
            var tickets = _tickets;
            return View(tickets);
        }

        public IActionResult GetDetails(Guid id)
        {
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);

            return View(ticket);
        }

        #region ADD

        [HttpGet]
        public IActionResult Add()
        {
            GetFormDataReady();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTicketVM ticketVM)
        {
            var selectedDevelopers = GetDevelopersByIds(ticketVM.DevelopersIds);

            var newTicket = new Ticket
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                IsClosed = ticketVM.IsClosed,
                Severity = ticketVM.Severity,
                Description = ticketVM.Description,
                Department = Department.GetDepartments().FirstOrDefault(d => d.Id == ticketVM.DepartmentId),
                Developers = selectedDevelopers
            };
            _tickets.Add(newTicket);
            return RedirectToAction(nameof(GetAll));
        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            GetFormDataReady();
            var ticketToEdit = _tickets.First(t => t.Id == id);

            var ticketVM = new EditTicketVM
            {
                Id = ticketToEdit.Id,
                IsClosed = ticketToEdit.IsClosed,
                Severity = ticketToEdit.Severity,
                Description = ticketToEdit.Description,
                DepartmentId = ticketToEdit.Department?.Id ?? new Guid(),
                DevelopersIds = ticketToEdit.Developers.Select(t => t.Id).ToList()

            };
            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            var selectedDevelopers = GetDevelopersByIds(ticketVM.DevelopersIds);

            var ticketToEdit = _tickets.First(d => d.Id == ticketVM.Id);

            ticketToEdit.IsClosed = ticketVM.IsClosed;
            ticketToEdit.Severity = ticketVM.Severity;
            ticketToEdit.Description = ticketVM.Description;
            ticketToEdit.Developers = selectedDevelopers;
            ticketToEdit.Department = Department.GetDepartments().FirstOrDefault(d => d.Id == ticketVM.DepartmentId);


            return RedirectToAction(nameof(GetAll));
        }
        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var ticketToDelete = _tickets.First(t => t.Id == id);
            _tickets.Remove(ticketToDelete);

            return RedirectToAction(nameof(GetAll));
        }

        #endregion


        #region Helpers

        private void GetFormDataReady()
        {
            #region Department
            var departments = Department.GetDepartments();
            var departmentsList = departments
                .Select(department => new SelectListItem(department.Name, department.Id.ToString()));

            ViewData["Departments"] = departmentsList;
            #endregion

            #region Developers
            var developers = Developer.GetDevelopers();
            var developersListItems = developers.Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.Id.ToString()));
            ViewData["Developers"] = developersListItems;

            #endregion
        }




        private static List<Developer> GetDevelopersByIds(List<Guid> selectedDevelopersIds)
        {
            var developers = Developer.GetDevelopers();
            var selectedDevelopers = developers
                .Where(d => selectedDevelopersIds.Contains(d.Id))
                .ToList();
            return selectedDevelopers;
        }
        #endregion

    }
}
