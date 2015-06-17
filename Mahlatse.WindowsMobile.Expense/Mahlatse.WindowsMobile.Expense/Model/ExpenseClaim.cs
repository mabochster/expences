using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahlatse.WindowsMobile.Expense.Model
{
    public class ExpenseClaim
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public int Sequence { get; set; }
        public bool AllowUserDelete { get; set; }
        public bool StatusId { get; set; }
        public int ModifiedUserId { get; set; }

        public override string ToString()
        {
            return this.Name + " , " + this.Amount.ToString("R#.##") + " , " + (this.Description.Length > 10 ? this.Description.Substring(0, 7) + "..." : this.Description);
        }
    }
}
