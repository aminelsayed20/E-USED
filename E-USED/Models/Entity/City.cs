using E_USED.Repository;
using SellingUsedThings.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_USED.Models.Entity
{
    public class City : IaddID
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
