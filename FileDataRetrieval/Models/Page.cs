namespace FileDataRetrieval.Models
{
    public class Page
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string FormJson { get; set; }
        public object PageLayoutId { get; set; }
        public object AccountCode { get; set; }
        public object ModelId { get; set; }
        public object OrientationId { get; set; }
        public int VersionNumber { get; set; }
        public object VersionNote { get; set; }
        public object OldVersions { get; set; }
        public string LayoutId { get; set; }
        public object PageLayout { get; set; }
        public bool IsUnauthorizedPage { get; set; }
        public object pageTemplateId { get; set; }
        public object pageTemplate { get; set; }
        public object PagesLayout { get; set; }
        public bool AnynomousPage { get; set; }
        public bool IsHomePage { get; set; }
        public bool IsMobile { get; set; }
        public object MobileAppId { get; set; }
        public object AppId { get; set; }
        public object TypeId { get; set; }
        public object PageContainerList { get; set; }
        public int PageContainerId { get; set; }
        public object Sequence { get; set; }
        public string MaestroThemeId { get; set; }
        public object MaestroThemeDto { get; set; }
        public string ClonedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object ModifiedBy { get; set; }
        public object ModificationDate { get; set; }
        public object DeletedBy { get; set; }
        public object DeletionDate { get; set; }
        public string Id { get; set; }
        public int MaestroBlocksEntityState { get; set; }
    }
}
