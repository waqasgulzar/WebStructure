using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entites.Entites.Base;
public class BaseEntity<T>
{
    #region Properties

    /// <summary>
    /// Id
    /// </summary>
    public T Id { get; set; }
    /// <summary>
    /// Record creation date and time in UTC format
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }
    /// <summary>
    /// Record modification date and time in UTC format
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; set; }
    /// <summary>
    /// Record created by
    /// </summary>
    public string CreatedBy { get; set; }
    /// <summary>
    /// Record Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }



    #endregion
}
