//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RohiniTravels.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RohiniTravelsEntities : DbContext
    {
        public RohiniTravelsEntities()
            : base("name=RohiniTravelsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StudentFeesTransactionDetail> StudentFeesTransactionDetails { get; set; }
        public virtual DbSet<StudentMaster> StudentMasters { get; set; }
        public virtual DbSet<InstituteMaster> InstituteMasters { get; set; }
        public virtual DbSet<ServicesMaster> ServicesMasters { get; set; }
    
        public virtual ObjectResult<PROC_GET_STUD_REG_PENDING_LST_Result> PROC_GET_STUD_REG_PENDING_LST()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PROC_GET_STUD_REG_PENDING_LST_Result>("PROC_GET_STUD_REG_PENDING_LST");
        }
    }
}
