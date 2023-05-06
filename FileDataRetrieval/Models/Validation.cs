namespace FileDataRetrieval.Models
{
    public class Validation
    {
        public bool IsUnique { get; set; }
        public bool IsRequired { get; set; }
        public bool HaveValidation { get; set; }
        public string AttributeId { get; set; }
        public object IsRequiredMessage { get; set; }
        public object CreatedBy { get; set; }
        public object CreationDate { get; set; }
        public object ModifiedBy { get; set; }
        public object ModificationDate { get; set; }
        public object DeletedBy { get; set; }
        public object DeletionDate { get; set; }
        public string Id { get; set; }
        public int MaestroBlocksEntityState { get; set; }
    }
}
