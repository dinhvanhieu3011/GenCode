using System.ComponentModel.DataAnnotations.Schema;

namespace GenCode
{
    public class Store /*: BaseFullAuditedEntity<long>*/
    {
        public string Name { get; set; }
        public long? DocumentUploadId { get; set; }
        public string Description { get; set; }
        public string Field { get; set; }
        public string UserId { get; set; }
    }
    public class Order
    {
        public string OrderCode { get; set; }
        public string ShippingCode { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Packer { get; set; }
        public string Assignee { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string Platform { get; set; }
        public long RefId { get; set; }
        public bool Processed { get; set; }
    }
    public class OrderHistory
    {
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public string ShippingCode { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Packer { get; set; }
        public string Assignee { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string Platform { get; set; }
        public long RefId { get; set; }
        public bool Processed { get; set; }

    }
    public class RefundRequest
    {
        public long OrderId { get; set; }
        public string ReasonRefund { get; set; }         // Lý do hoàn tiền
        public string ReasonNote { get; set; }           // Ghi chú chi tiết lý do
        public string Checker { get; set; }              // Người kiểm tra
        public string Reviewer { get; set; }             // Người đánh giá
        public string EmployeeFeedback { get; set; }     // Phản hồi từ nhân viên
        public string FeedbackNote { get; set; }         // Ghi chú bổ sung cho phản hồi
        public List<long> DocumentUploadIds { get; set; } // Danh sách URL hình ảnh minh họa phản hồi
        public string Status { get; set; }
    }

    public class Video 
    {
        public string UrlOrigin { get; set; }
        public double Size { get; set; }
        public string Path { get; set; }
        public string Note { get; set; }
        public bool IsConverted { get; set; }
    }
    public class Platform 
    {
        public string Name { get; set; }

    }
    public class OrderStatus
    {
        public string Name { get; set; }

    }
    public class OrderState
    {
        public string Name { get; set; }

    }
    public class Field
    {
        public string Name { get; set; }

    }
    public class UserInfo
    {
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hometown { get; set; }
        public string Biography { set; get; }
        public string Education { set; get; }
        public string Career { set; get; }
        public string PhoneNumber { set; get; }
        public long? ThumbnailId { get; set; }
        public long? AvatarId { get; set; }
        public string UserId { get; set; }
    }
}