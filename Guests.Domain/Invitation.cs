using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guests.Domain
{
    public class Invitation
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int GuestId { get; set; }
        public InvitationStatus Status { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? RespondedAt { get; set; }

        public Party Party { get; set; }
        public Guest Guest { get; set; }
    }
    public enum InvitationStatus
    {
        Invited,
        Confirmed,
        Declined,
        Maybe
    }
}
