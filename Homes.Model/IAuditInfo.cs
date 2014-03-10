using System;

namespace Homes.Model
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}