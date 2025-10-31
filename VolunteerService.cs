using DisasterManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DisasterManagementApp.Services
{
    public class VolunteerService
    {
        public List<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
        public List<VolunteerAssignment> Assignments { get; set; } = new List<VolunteerAssignment>();

        public void AddVolunteer(Volunteer volunteer)
        {
            Volunteers.Add(volunteer);
        }

        public Volunteer GetVolunteerById(int id)
        {
            return Volunteers.FirstOrDefault(v => v.VolunteerID == id);
        }

        public void AssignVolunteer(int volunteerId, int projectId)
        {
            Assignments.Add(new VolunteerAssignment
            {
                AssignmentID = Assignments.Count + 1,
                VolunteerID = volunteerId,
                ProjectID = projectId,
                AssignedDate = System.DateTime.Now
            });
        }

        public List<VolunteerAssignment> GetAssignmentsForVolunteer(int volunteerId)
        {
            return Assignments.Where(a => a.VolunteerID == volunteerId).ToList();
        }
    }
}
