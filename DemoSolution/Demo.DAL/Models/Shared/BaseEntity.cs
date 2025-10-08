namespace Demo.DAL.Models.Shared
{
    public class BaseEntity
    {
        public int Id { get; set ; }
        public int CreatedBy { get; set; } // User Id
        public DateTime CreatedOn { get; set; } // Inserted Date
        public int LastModifiedBy { get; set; } // User Id
        public DateTime LastModifiedOn { get; set; } // Updated Date
        public bool IsDeleted { get; set; } // For Soft Delete
    }
}
